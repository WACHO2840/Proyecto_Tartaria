using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTutorial : MonoBehaviour
{
    // Detectar final del nivel tutorial 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LevelEnd"))
        {
                SceneManager.LoadScene(0); // Vuelta al menu principal
        }
    }
    
}
