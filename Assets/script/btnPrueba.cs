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

    // M�todo que se llama cuando se presiona el bot�n
    public void OnButtonClick()
    {
        // Cambiar a la nueva escena
        SceneManager.LoadScene("NombreDeTuNuevaEscena");
    }
    

}
