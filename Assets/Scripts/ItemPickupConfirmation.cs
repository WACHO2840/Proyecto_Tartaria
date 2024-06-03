/*using UnityEngine;
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

    private PickUp currentPickUpItem;

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

    public void ShowConfirmationDialog(PickUp pickUpItem)
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
        exangeText.text = "�Quieres cambiar este objeto por un objeto aleatorio en tu mochila?";
        exangeDialog.SetActive(true);
    }

    private void OnYesButtonClicked()
    {
        if (PickUp.itemsCollected < PickUp.maxItems)
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
        currentPickUpItem.ReplaceRandomItemInMochila();
        exangeDialog.SetActive(false); // Ocultar la dialog de intercambio
        HideConfirmationDialog(); // Restaurar el estado original
    }

    private void OnExangeNoButtonClicked()
    {
        exangeDialog.SetActive(false); // Ocultar la dialog de intercambio
        HideConfirmationDialog(); // Restaurar el estado original
    }

    public void HideAllDialogs()
    {
        confirmationDialog.SetActive(false);
        fullMochilaDialog.SetActive(false);
        exangeDialog.SetActive(false);
        PlayerMovement.instance.canMove = true; // Habilitar movimiento
        currentPickUpItem = null;
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
*/

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

    private PickUp currentPickUpItem;

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

    public void ShowConfirmationDialog(PickUp pickUpItem)
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
        exangeText.text = "¿Quieres cambiar este objeto por un objeto aleatorio en tu mochila?";
        exangeDialog.SetActive(true);
    }

    private void OnYesButtonClicked()
    {
        if (PickUp.itemsCollected < PickUp.maxItems)
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
        currentPickUpItem.ReplaceRandomItemInMochila();
        currentPickUpItem.MakeInvisibleAndUninteractable(); // Hacer el objeto recogido invisible e invulnerable
        exangeDialog.SetActive(false); // Ocultar la dialog de intercambio
        HideConfirmationDialog(); // Restaurar el estado original
    }

    private void OnExangeNoButtonClicked()
    {
        exangeDialog.SetActive(false); // Ocultar la dialog de intercambio
        HideConfirmationDialog(); // Restaurar el estado original
    }

    public void HideAllDialogs()
    {
        confirmationDialog.SetActive(false);
        fullMochilaDialog.SetActive(false);
        exangeDialog.SetActive(false);
        PlayerMovement.instance.canMove = true; // Habilitar movimiento
        currentPickUpItem = null;
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
