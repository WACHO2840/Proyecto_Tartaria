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
    private int stages = 0; // Inicializamos la variable stages
    public GameObject[] objects;
    private readonly string[] positionNames = { "Position1", "Position2", "Position3" }; // Array con los nombres de los GameObjects vacíos
    private List<int> objectsCheck = new List<int>();
    private GameObject[] selectedObjects = new GameObject[5]; // Declaramos selectedObjects a nivel de clase
    #endregion

    private void Awake()
    {
        levelStart = transform.position;
    }

    private void Start()
    {
        GenerateScenes();
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
                // Cargar el siguiente nivel después de generar el objeto
                GenerateObjects();
                SceneManager.LoadScene(scenesCheck[stages]);
                stages++;
            }
            else if (stages == 5)
            {
                SceneManager.LoadScene(16); // Escena del jefe
            }
            this.transform.position = levelStart;

            // Desactivar el componente SpriteRenderer del objeto
            if (selectedObjects[stages - 1] != null)
            {
                SpriteRenderer spriteRenderer = selectedObjects[stages - 1].GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.enabled = false;
                }
            }
        }
    }

    private void GenerateScenes()
    {
        for (int i = 0; i < scenesCheck.Length; i++)
        {
            int index = UnityEngine.Random.Range(2, 16); // Asegúrate de obtener un índice válido para la escena
            while (scenesCheck.Contains(index))
            {
                index = UnityEngine.Random.Range(2, 16); // Evitar índices duplicados
            }
            scenesCheck[i] = index;
            Debug.Log("Scene: " + index);
        }
    }

    private void GenerateObjects()
    {
        // Si ya se han utilizado todos los objetos, reinicia la lista de índices utilizados
        if (objectsCheck.Count >= objects.Length)
        {
            objectsCheck.Clear();
        }

        // Obtener un índice aleatorio que no se haya utilizado previamente
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, objects.Length);
        } while (objectsCheck.Contains(randomIndex));

        // Registrar el índice utilizado
        objectsCheck.Add(randomIndex);
        Debug.Log("Random index: " + randomIndex);

        // Seleccionar aleatoriamente uno de los nombres de los GameObjects vacíos
        string positionName = positionNames[UnityEngine.Random.Range(0, positionNames.Length)];
        GameObject positionObject = GameObject.Find(positionName);

        if (positionObject != null)
        {
            // Instancia el objeto en la posición del GameObject vacío
            Instantiate(objects[randomIndex], positionObject.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No se encontró el GameObject vacío con el nombre: " + positionName);
        }
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int sceneIndex = System.Array.IndexOf(scenesCheck, scene.buildIndex);
        if (sceneIndex >= 0 && sceneIndex < objects.Length)
        {
            // Selecciona aleatoriamente uno de los nombres de los GameObjects vacíos
            string positionName = positionNames[UnityEngine.Random.Range(0, positionNames.Length)];
            GameObject positionObject = GameObject.Find(positionName);

            if (positionObject != null)
            {
                // Instancia el objeto en la posición del GameObject vacío
                selectedObjects[sceneIndex] = Instantiate(objects[sceneIndex], positionObject.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("No se encontró el GameObject vacío con el nombre: " + positionName);
            }
        }
    }

}
