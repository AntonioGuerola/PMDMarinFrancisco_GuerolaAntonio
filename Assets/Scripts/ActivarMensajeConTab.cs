using UnityEngine;
using UnityEngine.UI;

public class ActivarMensajeConTab : MonoBehaviour
{
[SerializeField] private Image huelgaBusStop;
    
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            huelgaBusStop.enabled = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            huelgaBusStop.enabled = false;
        }
    }

}