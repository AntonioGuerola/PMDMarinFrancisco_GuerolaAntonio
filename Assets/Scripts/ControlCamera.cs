using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{

    public float velocidadRotacion;
    public Transform player;
    public Transform target;
    float mouseX;
    float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        velocidadRotacion = 2.5f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * velocidadRotacion;
        mouseY -= Input.GetAxis("Mouse Y") * velocidadRotacion;
        mouseY = Mathf.Clamp(mouseY, -15, 40);
        transform.LookAt(target);
        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
