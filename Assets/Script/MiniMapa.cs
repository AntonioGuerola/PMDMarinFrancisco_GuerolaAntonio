using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapa : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject miniMap;
    void Start()
    {
        miniMap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
        miniMap.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
        miniMap.SetActive(false);
        }
    }
}
