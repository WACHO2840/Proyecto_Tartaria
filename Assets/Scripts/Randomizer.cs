using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections.Generic;

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
        else
        {
            Debug.Log("El jugador no puede pasar todavía");
        }
    }

    private void GenerateScenes()
    {
        // Usar un HashSet para rastrear los índices utilizados en general
        HashSet<int> usedIndices = new HashSet<int>();

        // Generar las 3 primeras escenas en el rango 2 a 11
        for (int i = 0; i < 3; i++)
        {
            int index = UnityEngine.Random.Range(2, 12); // El límite superior es exclusivo, por eso es 12
            while (usedIndices.Contains(index))
            {
                index = UnityEngine.Random.Range(2, 12);
            }
            scenesCheck[i] = index;
            usedIndices.Add(index);
            Debug.Log("Scene: " + index);
        }

        // Generar las 2 últimas escenas en el rango 11 a 16
        for (int i = 3; i < 5; i++)
        {
            int index = UnityEngine.Random.Range(11, 17); // El límite superior es exclusivo, por eso es 17
            while (usedIndices.Contains(index))
            {
                index = UnityEngine.Random.Range(11, 17);
            }
            scenesCheck[i] = index;
            usedIndices.Add(index);
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

    // Método para limpiar y reiniciar las estructuras de datos
    public void ResetArraysAndLists()
    {
        // Limpiar el array de escenas
        for (int i = 0; i < scenesCheck.Length; i++)
        {
            scenesCheck[i] = 0;
        }

        // Limpiar el array de objetos seleccionados
        for (int i = 0; i < selectedObjects.Length; i++)
        {
            selectedObjects[i] = null;
        }

        // Limpiar la lista de objetos chequeados
        objectsCheck.Clear();

        // Reiniciar el contador de etapas
        stages = 0;
    }
}
