using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlPlayer : MonoBehaviour
{
    [SerializeField] private Image pressFItem;
    [SerializeField] private Image closeDoorGirl;
    [SerializeField] private Image pressFDoor;

    CharacterController controlador;
    float velocidad;
    float gravedad;
    Vector3 direccion;

    int item;

    float salto;

    public Animator animDoor;
    Animator anim;

    public GameObject camaraItem, camaraDoor, luzMechero, Mechero, Car, Player, MainCamera;

    bool abrirPuerta = true;
    bool isInCloseDoorGirlTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        controlador = GetComponent<CharacterController>();
        velocidad = 5f;
        gravedad = -9.8f;
        salto = 2.5f;
        item = 0;

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

        if (isInCloseDoorGirlTrigger && Input.GetKeyDown(KeyCode.F))
        {
            if (item == 0)
            {
                pressFDoor.enabled = false;
                closeDoorGirl.enabled = true; // Muestra mensaje de advertencia
            }
            else if (item == 1)
            {
                pressFDoor.enabled = false;
                closeDoorGirl.enabled = false;
                Invoke("toCredits", 1f); // Cambia de escena
            }
        }
    }


    private void AnimPlayer()
    {

        if (velocidad == 0f)
        {
            anim.SetBool("Idle", true);
        }

        else if (Input.GetKey(KeyCode.R))
        {
            velocidad = 10f;
            anim.SetBool("IsRunning", true);
            anim.SetBool("IsWalking", false);
            anim.SetBool("Idle", false);
        }
        else if (!Input.GetKey(KeyCode.R) && velocidad > 0f)
        {
            velocidad = 5f;
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsRunning", false);
            anim.SetBool("Idle", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("IsJumping", true);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("LightOn", true);
            luzMechero.SetActive(true);
            Mechero.SetActive(true);

        }
        else
        {
            anim.SetBool("LightOn", false);
            luzMechero.SetActive(false);
            Mechero.SetActive(false);

        }
    }

    void OnTriggerStay(Collider objeto)
    {
        if ((objeto.gameObject.tag == "Item") && (Input.GetKeyDown(KeyCode.F)))
        {
            item = 1;
            pressFItem.enabled = false;
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

        if ((objeto.gameObject.tag == "Car") && (Input.GetKeyDown(KeyCode.F)))
        {
            Player.SetActive(false);
            MainCamera.SetActive(true);
        }

        if (objeto.gameObject.tag == "CloseDoorGirl")
        {
            pressFDoor.enabled = true;
            isInCloseDoorGirlTrigger = true;
        }
    }

    private void OnTriggerExit(Collider objeto)
    {
        /*if (objeto.gameObject.CompareTag("CloseDoorGirl"))
        {
            pressFDoor.enabled = false;
            closeDoorGirl.enabled = false;
            isInCloseDoorGirlTrigger = false;
        }*/
    }

    private void ApagarCamaraItem()
    {
        camaraItem.SetActive(false);
    }

    private void toCredits()
    {
        SceneManager.LoadScene("Creditos");
    }

    private void InteriorHospital()
    {
        SceneManager.LoadScene("Mecanicas");
    }
}