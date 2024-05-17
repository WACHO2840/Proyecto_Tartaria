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

    public GameObject secondDialog; // Panel para el cuadro de diálogo secundario
    public Text secondDialogText; // Referencia al Texto del cuadro de diálogo secundario
    public Button secondDialogOkButton; // Referencia al Botón "OK" en la dialog secundaria

    private PickUpGeneric currentPickUpItem;

    void Start()
    {
        confirmationDialog.SetActive(false); // Asegúrate de que el cuadro de confirmación esté oculto al inicio
        secondDialog.SetActive(false); // Asegúrate de que el cuadro secundario esté oculto al inicio

        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
        secondDialogOkButton.onClick.AddListener(OnSecondDialogOkButtonClicked);
    }

    public void ShowConfirmationDialog(PickUpGeneric pickUpItem)
    {
        currentPickUpItem = pickUpItem;
        confirmationText.text = "¿Quieres recoger el objeto?";
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
        secondDialogText.text = "La mochila está llena. ¿Quieres soltar un objeto para recoger el nuevo?"; // Texto de la segunda dialog
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
    public GameObject confirmationDialog; // Referencia al Panel del cuadro de diálogo de confirmación
    public Text confirmationText; // Referencia al Texto del cuadro de diálogo de confirmación
    public Button yesButton; // Referencia al Botón "Sí" en la dialog de confirmación
    public Button noButton; // Referencia al Botón "No" en la dialog de confirmación

    public GameObject secondDialog; // Panel para el cuadro de diálogo secundario
    public Text secondDialogText; // Referencia al Texto del cuadro de diálogo secundario
    public Button secondDialogOkButton; // Referencia al Botón "OK" en la dialog secundaria

    private PickUpGeneric currentPickUpItem;

    void Start()
    {
        confirmationDialog.SetActive(false); // Asegúrate de que el cuadro de confirmación esté oculto al inicio
        secondDialog.SetActive(false); // Asegúrate de que el cuadro secundario esté oculto al inicio

        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
        secondDialogOkButton.onClick.AddListener(OnSecondDialogOkButtonClicked);
    }

    public void ShowConfirmationDialog(PickUpGeneric pickUpItem)
    {
        currentPickUpItem = pickUpItem;
        confirmationText.text = "¿Quieres recoger el objeto?";
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
        secondDialogText.text = "La mochila está llena. ¿Quieres soltar un objeto para recoger el nuevo?"; // Texto de la segunda dialog
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
