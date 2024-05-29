/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCExchange : MonoBehaviour
{
    public GameObject firstDialogPanel;
    public GameObject secondDialogPanel;
    public Button nextButton;
    public Button yesButton;
    public Button noButton;
    private Collider2D playerCollider;

    void Start()
    {
        firstDialogPanel.SetActive(false);
        secondDialogPanel.SetActive(false);

        nextButton.onClick.AddListener(ShowSecondDialog);
        yesButton.onClick.AddListener(RemoveLastItemFromMochila);
        noButton.onClick.AddListener(CloseDialog);
    }

    void Update()
    {
        if (playerCollider != null && Input.GetKeyDown(KeyCode.E))
        {
            ShowFirstDialog();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollider = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollider = null;
            CloseDialog();
        }
    }

    private void ShowFirstDialog()
    {
        firstDialogPanel.SetActive(true);
    }

    private void ShowSecondDialog()
    {
        firstDialogPanel.SetActive(false);
        secondDialogPanel.SetActive(true);
    }

    private void RemoveLastItemFromMochila()
    {
        if (playerCollider != null)
        {
            PickUp pickUp = playerCollider.GetComponent<PickUp>();
            if (pickUp != null)
            {
                if (PickUp.mochila.Count > 0)
                {
                    int lastIndex = PickUp.mochila.Count - 1;
                    Item oldItem = PickUp.mochila[lastIndex];
                    pickUp.RemoveItemEffect(oldItem); // Eliminar el efecto del objeto reemplazado
                    PickUp.mochila.RemoveAt(lastIndex);
                    PickUp.itemsCollected--; // Decrementa el contador de items
                    Debug.Log("Item eliminado: " + oldItem.Name);
                }
                else
                {
                    Debug.Log("La mochila está vacía.");
                }

                pickUp.LogMochilaContents(); // Mostrar el contenido de la mochila después de la eliminación
            }
        }
        CloseDialog();
    }

    private void CloseDialog()
    {
        firstDialogPanel.SetActive(false);
        secondDialogPanel.SetActive(false);
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCExchange : MonoBehaviour
{
    private Collider2D playerCollider;

    void Update()
    {
        if (playerCollider != null && Input.GetKeyDown(KeyCode.E))
        {
            RemoveLastItemFromMochila();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollider = other;
            Debug.Log("Jugador detectado");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollider = null;
            Debug.Log("Jugador fuera de rango");
        }
    }

    private void RemoveLastItemFromMochila()
    {
        if (playerCollider != null)
        {
            PickUp pickUp = playerCollider.GetComponent<PickUp>();
            if (pickUp != null)
            {
                if (PickUp.mochila.Count > 0)
                {
                    int lastIndex = PickUp.mochila.Count - 1;
                    Item oldItem = PickUp.mochila[lastIndex];
                    pickUp.RemoveItemEffect(oldItem); // Eliminar el efecto del objeto reemplazado
                    PickUp.mochila.RemoveAt(lastIndex);
                    PickUp.itemsCollected--; // Decrementa el contador de items
                    Debug.Log("Item eliminado: " + oldItem.Name);
                }
                else
                {
                    Debug.Log("La mochila está vacía.");
                }

                pickUp.LogMochilaContents(); // Mostrar el contenido de la mochila después de la eliminación
            }
        }
    }
}

