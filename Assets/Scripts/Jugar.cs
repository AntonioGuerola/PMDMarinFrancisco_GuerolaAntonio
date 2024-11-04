using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugar : MonoBehaviour
{

    private bool hasSkipped = false;

    // Start is called before the first frame update
    void Start()
    {
        // Llama al método `JugarJuego` después de 35 segundos, solo si el usuario no ha saltado antes
        Invoke("JugarJuego", 35);
    }

    // Update is called once per frame
    void Update()
    {
        // Si el usuario presiona la tecla Tab y no ha saltado ya
        if (Input.GetKeyDown(KeyCode.Tab) && !hasSkipped)
        {
            hasSkipped = true;
            JugarJuego();
        }
    }

    private void JugarJuego()
    {
        // Cargar la escena solo si aún no se ha llamado
        if (!hasSkipped)
        {
            hasSkipped = true;
        }
        SceneManager.LoadScene("City");
    }
}
