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
    private int stages = 0;
    public GameObject[] objects;
    private readonly string[] positionNames = { "Position1", "Position2", "Position3" };
    private List<int> objectsCheck = new List<int>();
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
        SceneManager.sceneLoaded += OnSceneLoaded;
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

            // Desactivar el objeto de la escena anterior
            if (stages > 1 && selectedObjects[stages - 2] != null)
            {
                selectedObjects[stages - 2].SetActive(false);
            }
        }
    }

    private void GenerateScenes()
    {
        for (int i = 0; i < scenesCheck.Length; i++)
        {
            int index = UnityEngine.Random.Range(2, 16);
            while (scenesCheck.Contains(index))
            {
                index = UnityEngine.Random.Range(2, 16);
            }
            scenesCheck[i] = index;
            Debug.Log("Scene: " + index);
        }
    }

    private void GenerateObjects()
    {
        List<int> availableIndexes = Enumerable.Range(0, objects.Length).ToList();

        for (int i = 0; i < selectedObjects.Length; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, availableIndexes.Count);
            selectedObjects[i] = objects[availableIndexes[randomIndex]];
            availableIndexes.RemoveAt(randomIndex);
            Debug.Log("Selected object for scene " + (i + 1) + ": " + selectedObjects[i].name);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int sceneIndex = System.Array.IndexOf(scenesCheck, scene.buildIndex);
        if (sceneIndex >= 0 && sceneIndex < selectedObjects.Length)
        {
            string positionName = positionNames[UnityEngine.Random.Range(0, positionNames.Length)];
            GameObject positionObject = GameObject.Find(positionName);

            if (positionObject != null && selectedObjects[sceneIndex] != null)
            {
                GameObject instantiatedObject = Instantiate(selectedObjects[sceneIndex], positionObject.transform.position, Quaternion.identity);
                instantiatedObject.SetActive(true);
                selectedObjects[sceneIndex] = instantiatedObject; // Actualiza el array con la instancia activada
            }
            else
            {
                if (positionObject == null)
                {
                    Debug.LogWarning("No se encontró el GameObject vacío con el nombre: " + positionName);
                }
                if (selectedObjects[sceneIndex] == null)
                {
                    Debug.LogWarning("El objeto seleccionado para la escena es null en el índice: " + sceneIndex);
                }
            }
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}