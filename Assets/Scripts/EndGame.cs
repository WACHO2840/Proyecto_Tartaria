using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Asigna esto en el Inspector
    [SerializeField] private GameObject screen;

    private void Awake()
    {
        if (screen == null)
        {
            screen = transform.Find("MainMenu").gameObject;
            if (screen == null)
            {
                Debug.LogError("El GameObject de la pantalla no pudo ser encontrado.");
            }
        }
    }

    private void Start()
    {
        if (screen != null)
        {
            screen.SetActive(false);
        }
    }

    public void FinalScreenSet()
    {
        if (screen != null)
        {
            screen.SetActive(true);
        }
    }

    public void FinalScreenUnset()
    {
        if (screen != null)
        {
            screen.SetActive(false);
        }
    }

    public void MainMenu()
    {
        Debug.Log("MainMenu llamado");
        FinalScreenSet();
        SceneManager.LoadScene(0); // Cambiar a la escena de juego
    }
}
