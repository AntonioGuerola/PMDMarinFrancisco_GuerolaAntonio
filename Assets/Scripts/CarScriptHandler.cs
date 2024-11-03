using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarScriptHandler : MonoBehaviour
{

private Retrovisor retrovisor;
private CarController carController;
private CarUserControl carUserControl;
private CarAudio carAudio;


private void Start()
{
    retrovisor = this.GetComponent<Retrovisor>();
    carController = this.GetComponent<CarController>();
    carUserControl = this.GetComponent<CarUserControl>();
    carAudio = this.GetComponent<CarAudio>();
    }
    void OnTriggerStay(Collider objeto)
    {

        if((objeto.gameObject.tag == "Player") && (Input.GetKeyDown(KeyCode.F))){
            retrovisor.enabled = true;
            carController.enabled = true;
            carUserControl.enabled = true;
            carAudio.enabled = true;
        }

    }
}