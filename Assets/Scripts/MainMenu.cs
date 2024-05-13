using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2); // Cambiar a la escena de tutorial
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Cambiar a la escena de tutorial
    }

    public void BossRush()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // Cambiar a la escena de pelea contra el jefe
    }

    public void Exit()
    {
        Application.Quit(); // Cerrar la aplicacion
    }
}
