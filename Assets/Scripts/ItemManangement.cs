using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManangement : MonoBehaviour
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
