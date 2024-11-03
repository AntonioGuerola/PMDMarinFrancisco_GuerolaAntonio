using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScriptHandler : MonoBehaviour
{
private Retrovisor retrovisor;


private void Start()
{
    retrovisor = this.GetComponent<Retrovisor>();
    }
    void OnTriggerStay(Collider objeto)
    {

        if((objeto.gameObject.tag == "Player") && (Input.GetKeyDown(KeyCode.F))){
            retrovisor.enabled = true;
        }

    }
}
