using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luz : MonoBehaviour
{
    public GameObject bomb;
    public GameObject bomb1;
    bool si = true;
    bool si1 = true;
    // Start is called before the first frame update
    void Start()
    {
      
    }
 void Update()
    {
if(si==true){
      Invoke("luzoff",2);
}
if(si==false){
      Invoke("luzon",0);
}
if(si1==true){
      Invoke("luzoff1",0);
}
if(si1==false){
      Invoke("luzon1",2);
}
    }
    void luzoff(){
        bomb.SetActive(false);
        si = false;
    }
     void luzon(){
        bomb.SetActive(true);
        si = true;
    }
       void luzoff1(){
        bomb1.SetActive(false);
        si1 = false;
    }
     void luzon1(){
        bomb1.SetActive(true);
        si1 = true;
    }
    
}

