using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1); // Cambiar a la escena de juego
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(18); // Cambiar a la escena de tutorial
    }

    public void BossRush()
    {
        SceneManager.LoadScene(17); // Cambiar a la escena de pelea contra el jefe
    }

    public void Exit()
    {
        Application.Quit(); // Cerrar la aplicacion
    }
}
