using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorToOpener : MonoBehaviour
{

    [SerializeField] private Image pressF;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay(Collider objeto)
    {
        if (objeto.CompareTag("Player") && (Input.GetKeyDown(KeyCode.F)))
        {
            pressF.enabled = false;
            CambiarEscenaInteriorHospital();
        }
    }

    private void CambiarEscenaInteriorHospital()
    {
        SceneManager.LoadScene("hospital");
    }
}
