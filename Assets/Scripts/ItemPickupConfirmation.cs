/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickupConfirmation : MonoBehaviour
{
    public GameObject confirmationDialog; // Referencia al Panel del cuadro de di�logo de confirmaci�n
    public Text confirmationText; // Referencia al Texto del cuadro de di�logo de confirmaci�n
    public Button yesButton; // Referencia al Bot�n "S�" en la dialog de confirmaci�n
    public Button noButton; // Referencia al Bot�n "No" en la dialog de confirmaci�n

    public GameObject fullMochilaDialog; // Panel para el cuadro de di�logo cuando la mochila est� llena
    public Text fullMochilaText; // Referencia al Texto del cuadro de di�logo cuando la mochila est� llena
    public Button fullMochilaYesButton; // Referencia al Bot�n "S�" en el di�logo cuando la mochila est� llena
    public Button fullMochilaNoButton; // Referencia al Bot�n "No" en el di�logo cuando la mochila est� llena

    public GameObject exangeDialog; // Panel para el cuadro de di�logo de intercambio
    public Text exangeText; // Referencia al Texto del cuadro de di�logo de intercambio
    public Button exangeYesButton; // Referencia al Bot�n "S�" en el di�logo de intercambio
    public Button exangeNoButton; // Referencia al Bot�n "No" en el di�logo de intercambio

    private PickUpGeneric currentPickUpItem;

    void Start()
    {
        if (confirmationDialog == null || confirmationText == null || yesButton == null || noButton == null ||
            fullMochilaDialog == null || fullMochilaText == null || fullMochilaYesButton == null || fullMochilaNoButton == null ||
            exangeDialog == null || exangeText == null || exangeYesButton == null || exangeNoButton == null)
        {
            Debug.LogError("Una o m�s referencias no est�n configuradas en el inspector");
        }

        confirmationDialog.SetActive(false); // Aseg�rate de que el cuadro de confirmaci�n est� oculto al inicio
        fullMochilaDialog.SetActive(false); // Aseg�rate de que el cuadro de di�logo de mochila llena est� oculto al inicio
        exangeDialog.SetActive(false); // Aseg�rate de que el cuadro de di�logo de intercambio est� oculto al inicio

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
        confirmationText.text = "�Quieres recoger el objeto?";
        confirmationDialog.SetActive(true);
        PlayerMovement.instance.canMove = false; // Deshabilitar movimiento
    }

    public void ShowFullMochilaDialog()
    {
        fullMochilaText.text = "La mochila est� llena. �Quieres cambiar un objeto por el nuevo?";
        fullMochilaDialog.SetActive(true);
    }

    public void ShowExangeDialog()
    {
        exangeText.text = "�Quieres cambiar este objeto por el �ltimo objeto en tu mochila?";
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
            ShowFullMochilaDialog(); // Mostrar el di�logo de mochila llena
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
        // Reemplazar el �ltimo objeto en la mochila con el nuevo objeto
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
    public GameObject confirmationDialog; // Referencia al Panel del cuadro de di�logo de confirmaci�n
    public Text confirmationText; // Referencia al Texto del cuadro de di�logo de confirmaci�n
    public Button yesButton; // Referencia al Bot�n "S�" en la dialog de confirmaci�n
    public Button noButton; // Referencia al Bot�n "No" en la dialog de confirmaci�n

    public GameObject fullMochilaDialog; // Panel para el cuadro de di�logo cuando la mochila est� llena
    public Text fullMochilaText; // Referencia al Texto del cuadro de di�logo cuando la mochila est� llena
    public Button fullMochilaYesButton; // Referencia al Bot�n "S�" en el di�logo cuando la mochila est� llena
    public Button fullMochilaNoButton; // Referencia al Bot�n "No" en el di�logo cuando la mochila est� llena

    public GameObject exangeDialog; // Panel para el cuadro de di�logo de intercambio
    public Text exangeText; // Referencia al Texto del cuadro de di�logo de intercambio
    public Button exangeYesButton; // Referencia al Bot�n "S�" en el di�logo de intercambio
    public Button exangeNoButton; // Referencia al Bot�n "No" en el di�logo de intercambio

    private PickUpGeneric currentPickUpItem;

    void Start()
    {
        if (confirmationDialog == null || confirmationText == null || yesButton == null || noButton == null ||
            fullMochilaDialog == null || fullMochilaText == null || fullMochilaYesButton == null || fullMochilaNoButton == null ||
            exangeDialog == null || exangeText == null || exangeYesButton == null || exangeNoButton == null)
        {
            Debug.LogError("Una o m�s referencias no est�n configuradas en el inspector");
        }

        confirmationDialog.SetActive(false); // Aseg�rate de que el cuadro de confirmaci�n est� oculto al inicio
        fullMochilaDialog.SetActive(false); // Aseg�rate de que el cuadro de di�logo de mochila llena est� oculto al inicio
        exangeDialog.SetActive(false); // Aseg�rate de que el cuadro de di�logo de intercambio est� oculto al inicio

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
        confirmationText.text = "�Quieres recoger el objeto?";
        confirmationDialog.SetActive(true);
        PlayerMovement.instance.canMove = false; // Deshabilitar movimiento
    }

    public void ShowFullMochilaDialog()
    {
        fullMochilaText.text = "La mochila est� llena. �Quieres cambiar un objeto por el nuevo?";
        fullMochilaDialog.SetActive(true);
    }

    public void ShowExangeDialog()
    {
        exangeText.text = "�Quieres cambiar este objeto por el �ltimo objeto en tu mochila?";
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
            ShowFullMochilaDialog(); // Mostrar el di�logo de mochila llena
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

