using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void Play()
    {
        Debug.Log("Jugar");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); // Cambiar a la siguiente escena
    }

    public void Settings()
    {
        Debug.Log("Ajustes");

    }

    public void Exit()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
