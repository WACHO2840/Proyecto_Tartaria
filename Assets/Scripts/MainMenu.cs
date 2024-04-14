using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("Jugar");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2); // Cambiar a la escena de tutorial
    }

    public void Settings()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Cambiar a la siguiente escena
        Debug.Log("Ajustes");
    }

    public void Exit()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    public void ExitSettings()
    {
        Debug.Log("Salir de ajustes");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // Cambiar a la escena de menu principal
    }

    public void Volume()
    {

    }
}
