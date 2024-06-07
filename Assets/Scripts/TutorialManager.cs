using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] panels; // Los paneles que se mostrarán secuencialmente
    public Button[] nextButtons; // Los botones para avanzar al siguiente panel
    public GameObject interactText; // El texto que muestra la letra 'E' para interactuar
    public GameObject healthBar; // Referencia al GameObject HealthBar

    private int currentPanelIndex = 0;
    private bool isPlayerInRange = false; // Para verificar si el jugador está en rango
    private Canvas canvas; // Referencia al Canvas

    void Start()
    {
        canvas = FindObjectOfType<Canvas>(); // Encuentra el Canvas en la escena
        HideAllPanels(); // Ocultar todos los paneles al inicio
        interactText.gameObject.SetActive(false); // Ocultar el texto de interacción al inicio

        // Asegúrate de que cada botón tenga asignado el método NextPanel
        for (int i = 0; i < nextButtons.Length; i++)
        {
            nextButtons[i].onClick.AddListener(NextPanel);
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShowCurrentPanel(); // Mostrar el panel de interacción
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true; // El jugador está en rango
            interactText.gameObject.SetActive(true); // Mostrar el texto de interacción
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false; // El jugador ha salido del rango
            HideAllPanels(); // Ocultar los paneles de interacción cuando el jugador se aleja
            interactText.gameObject.SetActive(false); // Ocultar el texto de interacción
        }
    }

    private void ShowCurrentPanel()
    {
        if (currentPanelIndex < panels.Length)
        {
            panels[currentPanelIndex].SetActive(true); // Mostrar el panel actual
        }
    }

    private void HideAllPanels()
    {
        // Ocultar todos los paneles del tutorial
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        // Mantener el HealthBar activo
        if (healthBar != null)
        {
            healthBar.SetActive(true);
        }

        // Reiniciar el índice del panel
        currentPanelIndex = 0;
    }
    //controla el paso entre los paneles de los npc del tutorial
    private void NextPanel()
    {
        if (currentPanelIndex < panels.Length - 1)
        {
            panels[currentPanelIndex].SetActive(false); // Ocultar el panel actual
            currentPanelIndex++;
            panels[currentPanelIndex].SetActive(true); // Mostrar el siguiente panel
        }
        else
        {
            HideAllPanels(); // Ocultar todos los paneles cuando se hayan mostrado todos
        }
    }
}
