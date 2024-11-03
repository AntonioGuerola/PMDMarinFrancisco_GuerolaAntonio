using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retrovisor : MonoBehaviour
{
    public GameObject retrovisor;
    // Start is called before the first frame update
    void Start()
    {
        retrovisor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightShift)){
            retrovisor.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.RightShift))
        {
            retrovisor.SetActive(false);
        }
    }
}
