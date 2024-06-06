using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    [SerializeField] private List<int> scenesToReload;

    private void Awake()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName != "LevelTutorial") 
        {
            DontDestroyOnLoad(transform.root.gameObject);
        }

        if (screen == null)
        {
            screen = transform.Find("WinGame").gameObject;
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

    public void WinScreenSet()
    {
        if (screen != null)
        {
            screen.SetActive(true);
            StartCoroutine(WaitAndReloadScenes());
            PickUp.mochila.Clear();
            PickUp.itemsCollected = 0;
        }
    }

    public void WinScreenUnset()
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
        WinScreenUnset();
        MainMenu();
    }

    private IEnumerator ReloadScenes()
    {
        foreach (int sceneIndex in scenesToReload)
        {
            SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
            yield return null;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        KeepOnLoad[] keepOnLoadObjects = FindObjectsOfType<KeepOnLoad>();

        GameObject playerObject = GameObject.FindWithTag("Player");

        foreach (KeepOnLoad keepOnLoad in keepOnLoadObjects)
        {
            if (keepOnLoad.gameObject != playerObject)
            {
                Destroy(keepOnLoad.gameObject);
            }
        }

        Destroy(playerObject);
    }
}
