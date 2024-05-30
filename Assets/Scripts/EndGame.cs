using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Asigna esto en el Inspector
    [SerializeField] private GameObject screen;
    [SerializeField] private List<int> scenesToReload; // Lista de índices de escenas que deben ser recargadas

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
            StartCoroutine(WaitAndReloadScenes());
        }
    }

    public void FinalScreenUnset()
    {
        if (screen != null)
        {
            screen.SetActive(false);
        }
    }

    private IEnumerator WaitAndReloadScenes()
    {
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(ReloadScenes());
        FinalScreenUnset();
        MainMenu();
    }


    private IEnumerator ReloadScenes()
    {
        // Buscar el objeto llamado "UI" y almacenarlo para que no sea destruido
        foreach (int sceneIndex in scenesToReload)
        {
            SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
            yield return null; // Esperar un frame para asegurarse de que la escena se haya cargado completamente
        }

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0); // Cambiar a la escena de menú principal
        KeepOnLoad[] keepOnLoadObjects = FindObjectsOfType<KeepOnLoad>();

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
