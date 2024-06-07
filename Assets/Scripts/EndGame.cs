using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Asigna esto en el Inspector
    [SerializeField] private GameObject screen;
    [SerializeField] private List<int> scenesToReload; // Lista de �ndices de escenas que deben ser recargadas

    private void Awake()
    {
        if (screen == null)
        {
            // Almacenar el GameObject de la pantalla final
            screen = transform.Find("EndGame").gameObject;
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
            // Desactivar el GameObject al iniciar 
            screen.SetActive(false);
        }
    }

    public void FinalScreenSet()
    {
        if (screen != null)
        {
            // Activar el GameObject y reiniciar el juego
            screen.SetActive(true);
            StartCoroutine(WaitAndReloadScenes());
            //Limpiar la mochila
            PickUp.mochila.Clear();
            PickUp.itemsCollected = 0;
        }
    }

    public void FinalScreenUnset()
    {
        if (screen != null)
        {
            // Desactivar GameObject
            screen.SetActive(false);
        }
    }

    private IEnumerator WaitAndReloadScenes()
    {
        // Iniciar contador y reiniciar escenas
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(ReloadScenes());
        FinalScreenUnset();
        MainMenu();
    }


    private IEnumerator ReloadScenes()
    {
        foreach (int sceneIndex in scenesToReload)
        {
            SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
            yield return null; // Esperar un frame para asegurarse de que la escena se haya cargado completamente
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0); // Cambiar a la escena de men� principal
        KeepOnLoad[] keepOnLoadObjects = FindObjectsOfType<KeepOnLoad>(); // Array de GameObjects a borrar

        // Buscar el GameObject "Player"
        GameObject playerObject = GameObject.FindWithTag("Player");

        // Destruir cada objeto encontrado excepto el objeto "Player"
        foreach (KeepOnLoad keepOnLoad in keepOnLoadObjects)
        {
            if (keepOnLoad.gameObject != playerObject)
            {
                Destroy(keepOnLoad.gameObject);
            }
        }

        // Destruir el GameObject "Player"
        Destroy(playerObject);
    }

}
