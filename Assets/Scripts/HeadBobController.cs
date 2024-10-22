using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobController : MonoBehaviour
{
    [SerializeField] private bool enable = true;
    [SerializeField, Range(0, 0.1f)] private float amplitude = 0.008f;
    [SerializeField, Range(0, 30f)] private float frequency = 8.0f;
    [SerializeField] private Transform _camera = null;
    [SerializeField] private Transform _cameraHolder = null;
    private float _toggleSpeed = 3.0f;
    private Vector3 _startPos;
    private CharacterController _controller;

    private void Awake(){
        _controller = GetComponent<CharacterController>();
        _startPos = _camera.localPosition;
    }

    void Update(){
        if(!enable) return;
        CheckMotion();
        ResetPosition();
        _camera.LookAt(FocusTarget());
    }

    private void CheckMotion(){
        float speed = new Vector3(_controller.velocity.x, 0, _controller.velocity.z).magnitude;
        if(speed < _toggleSpeed) return;
        if(!_controller.isGrounded) return;
        PlayMotion(FootStepMotion());
    }

    private Vector3 FootStepMotion(){
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency) * amplitude;
        pos.x += Mathf.Cos(Time.time * frequency / 2) * amplitude * 2;
        return pos;
    }

    private void ResetPosition(){
        if(_camera.localPosition == _startPos) return;
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, _startPos, 1 * Time.deltaTime);
    }

    private Vector3 FocusTarget(){
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + _cameraHolder.localPosition.y, transform.position.z);
        pos += _cameraHolder.forward * 15.0f;
        return pos;
    }

    private void PlayMotion(Vector3 motion){
        _camera.localPosition += motion; 
}

}
