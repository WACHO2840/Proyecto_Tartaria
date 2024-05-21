using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] panels; // Los paneles que se mostrarán secuencialmente
    public Button[] nextButtons; // Los botones para avanzar al siguiente panel

    private int currentPanelIndex = 0;
    private bool isPlayerInRange = false; // Para verificar si el jugador está en rango
    private Canvas canvas; // Referencia al Canvas

    void Start()
    {
        canvas = FindObjectOfType<Canvas>(); // Encuentra el Canvas en la escena
        HideAllPanels(); // Ocultar todos los paneles al inicio

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
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false; // El jugador ha salido del rango
            HideAllPanels(); // Ocultar los paneles de interacción cuando el jugador se aleja
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
        // Ocultar todos los paneles dentro del Canvas
        foreach (Transform child in canvas.transform)
        {
            if (child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(false);
            }
        }

        // Reiniciar el índice del panel y asegurarse de que todos los paneles específicos estén ocultos
        currentPanelIndex = 0;
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }

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
