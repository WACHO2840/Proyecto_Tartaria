/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject[] panels; // Array de paneles en el Canvas
    private int currentPanelIndex = 0; // Índice del panel actualmente visible
    private bool isPlayerNearby = false; // Bandera para verificar si el jugador está cerca

    private Collider2D playerCollider;

    void Start()
    {
        HideAllPanels();
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ShowPanel(0); // Mostrar el primer panel cuando se presiona la tecla E cerca del NPC
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            playerCollider = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            playerCollider = null;
        }
    }

    private void HideAllPanels()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }

    private void ShowPanel(int index)
    {
        if (index >= 0 && index < panels.Length)
        {
            HideAllPanels();
            panels[index].SetActive(true);
            currentPanelIndex = index;

            Button nextButton = panels[index].GetComponentInChildren<Button>();
            if (nextButton != null)
            {
                nextButton.onClick.RemoveAllListeners();
                nextButton.onClick.AddListener(ShowNextPanel);
            }
        }
    }

    private void ShowNextPanel()
    {
        int nextPanelIndex = currentPanelIndex + 1;
        if (nextPanelIndex < panels.Length)
        {
            ShowPanel(nextPanelIndex);
        }
        else
        {
            HideAllPanels(); // Ocultar todos los paneles si no hay más paneles
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject[] panels; // Array de paneles en el Canvas
    public Button yesButton; // Botón de "Sí" para el intercambio de objetos
    public Button noButton; // Botón de "No" para el intercambio de objetos
    private int currentPanelIndex = 0; // Índice del panel actualmente visible
    private bool isPlayerNearby = false; // Bandera para verificar si el jugador está cerca

    private GameObject player;

    void Start()
    {
        HideAllPanels();

        if (yesButton != null)
        {
            yesButton.onClick.AddListener(OnYesButtonClicked);
            Debug.Log("Yes button assigned and listener added.");
        }
        else
        {
            Debug.LogError("yesButton no está asignado en el inspector.");
        }

        if (noButton != null)
        {
            noButton.onClick.AddListener(OnNoButtonClicked);
            Debug.Log("No button assigned and listener added.");
        }
        else
        {
            Debug.LogError("noButton no está asignado en el inspector.");
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ShowPanel(0); // Mostrar el primer panel cuando se presiona la tecla E cerca del NPC
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            player = other.gameObject;
            Debug.Log("Player entered NPC interaction zone.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            player = null;
            Debug.Log("Player exited NPC interaction zone.");
        }
    }

    private void HideAllPanels()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }

    private void ShowPanel(int index)
    {
        if (index >= 0 && index < panels.Length)
        {
            HideAllPanels();
            panels[index].SetActive(true);
            currentPanelIndex = index;

            Button nextButton = panels[index].GetComponentInChildren<Button>();
            if (nextButton != null)
            {
                nextButton.onClick.RemoveAllListeners();
                if (index == 1)
                {
                    nextButton.onClick.AddListener(ShowExchangePanel);
                }
                else
                {
                    nextButton.onClick.AddListener(ShowNextPanel);
                }
            }
        }
    }

    private void ShowNextPanel()
    {
        int nextPanelIndex = currentPanelIndex + 1;
        if (nextPanelIndex < panels.Length)
        {
            ShowPanel(nextPanelIndex);
        }
        else
        {
            HideAllPanels(); // Ocultar todos los paneles si no hay más paneles
        }
    }

    private void ShowExchangePanel()
    {
        HideAllPanels();
        panels[1].SetActive(true);
    }

    private void OnYesButtonClicked()
    {
        Debug.Log("Yes button clicked.");
        ExchangeItem();
        HideAllPanels();
    }

    private void OnNoButtonClicked()
    {
        Debug.Log("No button clicked.");
        HideAllPanels();
    }

    private void ExchangeItem()
    {
        if (player == null)
        {
            Debug.LogError("player es nulo.");
            return;
        }

        PickUp pickUp = player.GetComponent<PickUp>();
        if (pickUp != null)
        {
            Debug.Log("Starting item exchange.");
            pickUp.ExchangeRandomItem();
            LogMochilaContents();
        }
        else
        {
            Debug.LogError("El componente PickUp no está presente en el jugador.");
        }
    }

    private void LogMochilaContents()
    {
        Debug.Log("Contenido actual de la mochila:");
        foreach (var item in PickUp.mochila)
        {
            Debug.Log(item.Name);
        }
    }
}

