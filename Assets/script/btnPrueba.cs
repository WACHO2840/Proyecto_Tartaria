using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnPrueba : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnButtonClick();
        }

    }

    // Método que se llama cuando se presiona el botón
    public void OnButtonClick()
    {
        // Cambiar a la nueva escena
        SceneManager.LoadScene("NombreDeTuNuevaEscena");
    }
    

}
