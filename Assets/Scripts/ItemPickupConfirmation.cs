/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickupConfirmation : MonoBehaviour
{
    public GameObject confirmationDialog; // Referencia al Panel del cuadro de diálogo de confirmación
    public Text confirmationText; // Referencia al Texto del cuadro de diálogo de confirmación
    public Button yesButton; // Referencia al Botón "Sí" en la dialog de confirmación
    public Button noButton; // Referencia al Botón "No" en la dialog de confirmación

    public GameObject fullMochilaDialog; // Panel para el cuadro de diálogo cuando la mochila está llena
    public Text fullMochilaText; // Referencia al Texto del cuadro de diálogo cuando la mochila está llena
    public Button fullMochilaYesButton; // Referencia al Botón "Sí" en el diálogo cuando la mochila está llena
    public Button fullMochilaNoButton; // Referencia al Botón "No" en el diálogo cuando la mochila está llena

    public GameObject exangeDialog; // Panel para el cuadro de diálogo de intercambio
    public Text exangeText; // Referencia al Texto del cuadro de diálogo de intercambio
    public Button exangeYesButton; // Referencia al Botón "Sí" en el diálogo de intercambio
    public Button exangeNoButton; // Referencia al Botón "No" en el diálogo de intercambio

    private PickUpGeneric currentPickUpItem;

    void Start()
    {
        if (confirmationDialog == null || confirmationText == null || yesButton == null || noButton == null ||
            fullMochilaDialog == null || fullMochilaText == null || fullMochilaYesButton == null || fullMochilaNoButton == null ||
            exangeDialog == null || exangeText == null || exangeYesButton == null || exangeNoButton == null)
        {
            Debug.LogError("Una o más referencias no están configuradas en el inspector");
        }

        confirmationDialog.SetActive(false); // Asegúrate de que el cuadro de confirmación esté oculto al inicio
        fullMochilaDialog.SetActive(false); // Asegúrate de que el cuadro de diálogo de mochila llena esté oculto al inicio
        exangeDialog.SetActive(false); // Asegúrate de que el cuadro de diálogo de intercambio esté oculto al inicio

        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
        fullMochilaYesButton.onClick.AddListener(OnFullMochilaYesButtonClicked);
        fullMochilaNoButton.onClick.AddListener(OnFullMochilaNoButtonClicked);
        exangeYesButton.onClick.AddListener(OnExangeYesButtonClicked);
        exangeNoButton.onClick.AddListener(OnExangeNoButtonClicked);
    }

    public void ShowConfirmationDialog(PickUpGeneric pickUpItem)
    {
        currentPickUpItem = pickUpItem;
        confirmationText.text = "¿Quieres recoger el objeto?";
        confirmationDialog.SetActive(true);
        PlayerMovement.instance.canMove = false; // Deshabilitar movimiento
    }

    public void ShowFullMochilaDialog()
    {
        fullMochilaText.text = "La mochila está llena. ¿Quieres cambiar un objeto por el nuevo?";
        fullMochilaDialog.SetActive(true);
    }

    public void ShowExangeDialog()
    {
        exangeText.text = "¿Quieres cambiar este objeto por el último objeto en tu mochila?";
        exangeDialog.SetActive(true);
    }

    private void OnYesButtonClicked()
    {
        if (PickUpGeneric.itemsCollected < PickUpGeneric.maxItems)
        {
            currentPickUpItem.CollectItem();
            HideConfirmationDialog();
        }
        else
        {
            confirmationDialog.SetActive(false); // Ocultar la primera dialog
            ShowFullMochilaDialog(); // Mostrar el diálogo de mochila llena
        }
    }

    private void OnNoButtonClicked()
    {
        HideConfirmationDialog();
    }

    private void OnFullMochilaYesButtonClicked()
    {
        fullMochilaDialog.SetActive(false); // Ocultar la dialog de mochila llena
        ShowExangeDialog(); // Mostrar la dialog de intercambio
    }

    private void OnFullMochilaNoButtonClicked()
    {
        fullMochilaDialog.SetActive(false); // Ocultar la dialog de mochila llena
        HideConfirmationDialog(); // Restaurar el estado original
    }

    private void OnExangeYesButtonClicked()
    {
        // Reemplazar el último objeto en la mochila con el nuevo objeto
        if (PickUpGeneric.mochila.Count > 0)
        {
            PickUpGeneric.mochila[PickUpGeneric.mochila.Count - 1] = currentPickUpItem.GetItem();
        }
        exangeDialog.SetActive(false); // Ocultar la dialog de intercambio
        HideConfirmationDialog(); // Restaurar el estado original
    }

    private void OnExangeNoButtonClicked()
    {
        exangeDialog.SetActive(false); // Ocultar la dialog de intercambio
        HideConfirmationDialog(); // Restaurar el estado original
    }

    private void HideConfirmationDialog()
    {
        confirmationDialog.SetActive(false);
        fullMochilaDialog.SetActive(false);
        exangeDialog.SetActive(false);
        PlayerMovement.instance.canMove = true; // Habilitar movimiento
        currentPickUpItem = null;
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickupConfirmation : MonoBehaviour
{
    public GameObject confirmationDialog; // Referencia al Panel del cuadro de diálogo de confirmación
    public Text confirmationText; // Referencia al Texto del cuadro de diálogo de confirmación
    public Button yesButton; // Referencia al Botón "Sí" en la dialog de confirmación
    public Button noButton; // Referencia al Botón "No" en la dialog de confirmación

    public GameObject fullMochilaDialog; // Panel para el cuadro de diálogo cuando la mochila está llena
    public Text fullMochilaText; // Referencia al Texto del cuadro de diálogo cuando la mochila está llena
    public Button fullMochilaYesButton; // Referencia al Botón "Sí" en el diálogo cuando la mochila está llena
    public Button fullMochilaNoButton; // Referencia al Botón "No" en el diálogo cuando la mochila está llena

    public GameObject exangeDialog; // Panel para el cuadro de diálogo de intercambio
    public Text exangeText; // Referencia al Texto del cuadro de diálogo de intercambio
    public Button exangeYesButton; // Referencia al Botón "Sí" en el diálogo de intercambio
    public Button exangeNoButton; // Referencia al Botón "No" en el diálogo de intercambio

    private PickUpGeneric currentPickUpItem;

    void Start()
    {
        if (confirmationDialog == null || confirmationText == null || yesButton == null || noButton == null ||
            fullMochilaDialog == null || fullMochilaText == null || fullMochilaYesButton == null || fullMochilaNoButton == null ||
            exangeDialog == null || exangeText == null || exangeYesButton == null || exangeNoButton == null)
        {
            Debug.LogError("Una o más referencias no están configuradas en el inspector");
        }

        confirmationDialog.SetActive(false); // Asegúrate de que el cuadro de confirmación esté oculto al inicio
        fullMochilaDialog.SetActive(false); // Asegúrate de que el cuadro de diálogo de mochila llena esté oculto al inicio
        exangeDialog.SetActive(false); // Asegúrate de que el cuadro de diálogo de intercambio esté oculto al inicio

        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
        fullMochilaYesButton.onClick.AddListener(OnFullMochilaYesButtonClicked);
        fullMochilaNoButton.onClick.AddListener(OnFullMochilaNoButtonClicked);
        exangeYesButton.onClick.AddListener(OnExangeYesButtonClicked);
        exangeNoButton.onClick.AddListener(OnExangeNoButtonClicked);
    }

    public void ShowConfirmationDialog(PickUpGeneric pickUpItem)
    {
        currentPickUpItem = pickUpItem;
        confirmationText.text = "¿Quieres recoger el objeto?";
        confirmationDialog.SetActive(true);
        PlayerMovement.instance.canMove = false; // Deshabilitar movimiento
    }

    public void ShowFullMochilaDialog()
    {
        fullMochilaText.text = "La mochila está llena. ¿Quieres cambiar un objeto por el nuevo?";
        fullMochilaDialog.SetActive(true);
    }

    public void ShowExangeDialog()
    {
        exangeText.text = "¿Quieres cambiar este objeto por el último objeto en tu mochila?";
        exangeDialog.SetActive(true);
    }

    private void OnYesButtonClicked()
    {
        if (PickUpGeneric.itemsCollected < PickUpGeneric.maxItems)
        {
            currentPickUpItem.CollectItem();
            HideConfirmationDialog();
        }
        else
        {
            confirmationDialog.SetActive(false); // Ocultar la primera dialog
            ShowFullMochilaDialog(); // Mostrar el diálogo de mochila llena
        }
    }

    private void OnNoButtonClicked()
    {
        HideConfirmationDialog();
    }

    private void OnFullMochilaYesButtonClicked()
    {
        fullMochilaDialog.SetActive(false); // Ocultar la dialog de mochila llena
        ShowExangeDialog(); // Mostrar la dialog de intercambio
    }

    private void OnFullMochilaNoButtonClicked()
    {
        fullMochilaDialog.SetActive(false); // Ocultar la dialog de mochila llena
        HideConfirmationDialog(); // Restaurar el estado original
    }

    private void OnExangeYesButtonClicked()
    {
        currentPickUpItem.ReplaceLastItemInMochila();
        exangeDialog.SetActive(false); // Ocultar la dialog de intercambio
        HideConfirmationDialog(); // Restaurar el estado original
    }

    private void OnExangeNoButtonClicked()
    {
        exangeDialog.SetActive(false); // Ocultar la dialog de intercambio
        HideConfirmationDialog(); // Restaurar el estado original
    }

    private void HideConfirmationDialog()
    {
        confirmationDialog.SetActive(false);
        fullMochilaDialog.SetActive(false);
        exangeDialog.SetActive(false);
        PlayerMovement.instance.canMove = true; // Habilitar movimiento
        currentPickUpItem = null;
    }
}

