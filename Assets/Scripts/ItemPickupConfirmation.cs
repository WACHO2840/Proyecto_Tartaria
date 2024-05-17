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

    public GameObject secondDialog; // Panel para el cuadro de di�logo secundario
    public Text secondDialogText; // Referencia al Texto del cuadro de di�logo secundario
    public Button secondDialogOkButton; // Referencia al Bot�n "OK" en la dialog secundaria

    private PickUpGeneric currentPickUpItem;

    void Start()
    {
        confirmationDialog.SetActive(false); // Aseg�rate de que el cuadro de confirmaci�n est� oculto al inicio
        secondDialog.SetActive(false); // Aseg�rate de que el cuadro secundario est� oculto al inicio

        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
        secondDialogOkButton.onClick.AddListener(OnSecondDialogOkButtonClicked);
    }

    public void ShowConfirmationDialog(PickUpGeneric pickUpItem)
    {
        currentPickUpItem = pickUpItem;
        confirmationText.text = "�Quieres recoger el objeto?";
        confirmationDialog.SetActive(true);
        PlayerMovement.instance.canMove = false; // Deshabilitar movimiento
    }

    private void OnYesButtonClicked()
    {
        if (Inventory.instance.items.Count < Inventory.instance.maxItems)
        {
            currentPickUpItem.CollectItem();
            HideConfirmationDialog();
        }
        else
        {
            confirmationDialog.SetActive(false); // Ocultar la primera dialog
            ShowSecondDialog(); // Mostrar la segunda dialog
        }
    }

    private void OnNoButtonClicked()
    {
        HideConfirmationDialog();
    }

    private void ShowSecondDialog()
    {
        secondDialogText.text = "La mochila est� llena. �Quieres soltar un objeto para recoger el nuevo?"; // Texto de la segunda dialog
        secondDialog.SetActive(true);
    }

    private void OnSecondDialogOkButtonClicked()
    {
        secondDialog.SetActive(false); // Ocultar la segunda dialog
        HideConfirmationDialog(); // Restaurar el estado original
    }

    private void HideConfirmationDialog()
    {
        confirmationDialog.SetActive(false);
        PlayerMovement.instance.canMove = true; // Habilitar movimiento
        currentPickUpItem = null;
    }
}
*/

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

    public GameObject secondDialog; // Panel para el cuadro de di�logo secundario
    public Text secondDialogText; // Referencia al Texto del cuadro de di�logo secundario
    public Button secondDialogOkButton; // Referencia al Bot�n "OK" en la dialog secundaria

    private PickUpGeneric currentPickUpItem;

    void Start()
    {
        confirmationDialog.SetActive(false); // Aseg�rate de que el cuadro de confirmaci�n est� oculto al inicio
        secondDialog.SetActive(false); // Aseg�rate de que el cuadro secundario est� oculto al inicio

        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
        secondDialogOkButton.onClick.AddListener(OnSecondDialogOkButtonClicked);
    }

    public void ShowConfirmationDialog(PickUpGeneric pickUpItem)
    {
        currentPickUpItem = pickUpItem;
        confirmationText.text = "�Quieres recoger el objeto?";
        confirmationDialog.SetActive(true);
        PlayerMovement.instance.canMove = false; // Deshabilitar movimiento
    }

    private void OnYesButtonClicked()
    {
        if (Inventory.instance.items.Count < Inventory.instance.maxItems)
        {
            currentPickUpItem.CollectItem();
            HideConfirmationDialog();
        }
        else
        {
            confirmationDialog.SetActive(false); // Ocultar la primera dialog
            ShowSecondDialog(); // Mostrar la segunda dialog
        }
    }

    private void OnNoButtonClicked()
    {
        HideConfirmationDialog();
    }

    private void ShowSecondDialog()
    {
        secondDialogText.text = "La mochila est� llena. �Quieres soltar un objeto para recoger el nuevo?"; // Texto de la segunda dialog
        secondDialog.SetActive(true);
    }

    private void OnSecondDialogOkButtonClicked()
    {
        secondDialog.SetActive(false); // Ocultar la segunda dialog
        HideConfirmationDialog(); // Restaurar el estado original
    }

    private void HideConfirmationDialog()
    {
        confirmationDialog.SetActive(false);
        PlayerMovement.instance.canMove = true; // Habilitar movimiento
        currentPickUpItem = null;
    }
}
