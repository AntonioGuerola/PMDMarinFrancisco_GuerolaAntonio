using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorManagement : MonoBehaviour
{
[SerializeField] private Image pressF;
    
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            pressF.enabled = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            pressF.enabled = false;
        }
    }
}
