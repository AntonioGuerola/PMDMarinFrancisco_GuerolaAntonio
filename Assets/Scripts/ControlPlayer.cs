using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPlayer : MonoBehaviour
{

    CharacterController controlador;
    float velocidad;
    float gravedad;
    Vector3 direccion;

    float salto;

    public Animator animDoor;
    Animator anim;

    public GameObject camaraItem, camaraDoor, luzMechero;

    bool abrirPuerta = true;

    // Start is called before the first frame update
    void Start()
    {
        controlador = GetComponent<CharacterController>();
        velocidad = 5f;
        gravedad = -9.8f;
        salto = 2.5f;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (abrirPuerta == false)
        {
            controlador.Move(Vector3.zero);
        }
        else
        {
            if (controlador.isGrounded)
            {
                direccion.x = Input.GetAxis("Horizontal");
                direccion.z = Input.GetAxis("Vertical");
                direccion = transform.TransformDirection(new Vector3(direccion.x, 0, direccion.z));
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    direccion.y = salto;
                }
            }
            direccion.y += gravedad * Time.deltaTime;
            controlador.Move(direccion * velocidad * Time.deltaTime);

            AnimPlayer();
        }
    }


    private void AnimPlayer()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidad = 10f;
            anim.SetBool("IsRunning", true);
        }
        else
        {
            velocidad = 5f;
            anim.SetBool("IsWalking", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Jump", true);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("LightOn", true);
            luzMechero.SetActive(true);

        }
        else
        {
            anim.SetBool("LightOn", false);
            luzMechero.SetActive(false);

        }
    }

    void OnTriggerStay(Collider objeto)
    {
        if ((objeto.gameObject.tag == "Item") && (Input.GetKeyDown(KeyCode.E)))
        {
            anim.SetTrigger("TakingItem");
            camaraItem.SetActive(true);
            Destroy(objeto.gameObject, 1f);
            Invoke("ApagarCamaraItem", 2f);
        }

        if ((objeto.gameObject.tag == "Door") && (Input.GetKeyDown(KeyCode.F)))
        {
            abrirPuerta = false;
            animDoor.SetTrigger("OpenDoor");
            anim.SetTrigger("OpeningDoor");
            camaraDoor.SetActive(true);
            Invoke("InteriorHospital", 3f);
        }
    }

    private void ApagarCamaraItem()
    {
        camaraItem.SetActive(false);
    }

    private void InteriorHospital()
    {
        SceneManager.LoadScene("Mecanicas");
    }
}
