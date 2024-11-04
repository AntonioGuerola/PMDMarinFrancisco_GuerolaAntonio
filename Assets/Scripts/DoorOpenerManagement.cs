using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpenerManagement : MonoBehaviour
{
[SerializeField] private Image closeDoor;
[SerializeField] private Image pressF;

private void Start()
{
    
    }
    void OnTriggerStay(Collider objeto)
    {
        if((objeto.gameObject.tag == "Player") && (Input.GetKeyDown(KeyCode.F))){
            closeDoor.enabled = true;
            pressF.enabled = false;
        }
    }

        void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            closeDoor.enabled = false;
        }
    }
}
