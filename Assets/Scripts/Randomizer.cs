using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Randomizer : MonoBehaviour
{
    #region Variables
    private float sceneCooldown = 1f;
    private float sceneTimer = 0f;
    private bool nextScene = false;
    private Vector2 levelStart;
    private int[] scenesCheck = new int[5];
    private int stages;
    public GameObject[] objects;
    private GameObject[] selectedObjects = new GameObject[5];
    #endregion

    private void Awake()
    {
        levelStart = transform.position;
    }

    private void Start()
    {
        GenerateScenes();
        GenerateObjects();
        SceneManager.sceneLoaded += OnSceneLoaded; // Suscribirse al evento de carga de escena
    }

    private void Update()
    {
        if (nextScene)
        {
            sceneTimer += Time.deltaTime;
            if (sceneTimer >= sceneCooldown)
            {
                nextScene = false;
                sceneTimer = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LevelEnd") && !nextScene)
        {
            nextScene = true;

            if (stages < 5)
            {
                SceneManager.LoadScene(scenesCheck[stages]);
                stages++;
            }
            else if (stages == 5)
            {
                SceneManager.LoadScene(16); // Escena del jefe
            }
            this.transform.position = levelStart;
        }
    }

    private void GenerateScenes()
    {
        for (int i = 0; i < scenesCheck.Length; i++)
        {
            int index = UnityEngine.Random.Range(2, SceneManager.sceneCountInBuildSettings); // Asegúrate de obtener un índice válido para la escena
            while (scenesCheck.Contains(index))
            {
                index = UnityEngine.Random.Range(2, SceneManager.sceneCountInBuildSettings); // Evitar índices duplicados
            }
            scenesCheck[i] = index;
            Debug.Log("Scene: " + index);
        }
    }

    private void GenerateObjects()
    {
        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, objects.Length); // Obtener un índice aleatorio para seleccionar un objeto
            selectedObjects[i] = objects[randomIndex];
            Debug.Log(objects[randomIndex]);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int sceneIndex = System.Array.IndexOf(scenesCheck, scene.buildIndex);
        if (sceneIndex >= 0 && sceneIndex < selectedObjects.Length)
        {
            GameObject emptyObject = GameObject.Find("Position"); // Obtener el GameObject vacío correspondiente a la escena
            if (emptyObject != null)
            {
                Instantiate(selectedObjects[sceneIndex], emptyObject.transform.position, Quaternion.identity); // Instanciar el objeto en la posición del GameObject vacío
            }
            else
            {
                Debug.LogWarning("No se encontró el GameObject vacío 'Posicion" + sceneIndex + "'.");
            }
        }
        else
        {
            Debug.LogWarning("Índice de escena fuera de rango.");
        }
    }
}
