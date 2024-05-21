using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] panels; // Los paneles que se mostrar�n secuencialmente
    public Button[] nextButtons; // Los botones para avanzar al siguiente panel

    private int currentPanelIndex = 0;
    private bool isPlayerInRange = false; // Para verificar si el jugador est� en rango
    private Canvas canvas; // Referencia al Canvas

    void Start()
    {
        canvas = FindObjectOfType<Canvas>(); // Encuentra el Canvas en la escena
        HideAllPanels(); // Ocultar todos los paneles al inicio

        // Aseg�rate de que cada bot�n tenga asignado el m�todo NextPanel
        for (int i = 0; i < nextButtons.Length; i++)
        {
            nextButtons[i].onClick.AddListener(NextPanel);
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShowCurrentPanel(); // Mostrar el panel de interacci�n
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true; // El jugador est� en rango
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false; // El jugador ha salido del rango
            HideAllPanels(); // Ocultar los paneles de interacci�n cuando el jugador se aleja
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

        // Reiniciar el �ndice del panel y asegurarse de que todos los paneles espec�ficos est�n ocultos
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
