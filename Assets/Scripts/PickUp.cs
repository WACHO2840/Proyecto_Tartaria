using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PickUp : MonoBehaviour
{
    public static int itemsCollected = 0;
    public static int maxItems = 3; // Maximum number of items that can be collected
    public static List<Item> mochila = new List<Item>();

    public bool isToroide;
    public bool isElectron;
    public bool isLenguaDeFuego;
    public bool isRocaVolcanica;
    public bool isPalanca;
    public bool isCrocks;
    public bool isDurumDoble;
    private bool isCollected = false;
    private Collider2D playerCollider;

    public GameObject interactKeyUI; // Drag your UI object here through the inspector
    public ItemPickupConfirmation itemPickupConfirmation; // Drag the ItemPickupConfirmation object here through the inspector

    void Start()
    {
        interactKeyUI.SetActive(false); // Make sure UI is turned off on start
    }

    void Update()
    {
        if (playerCollider != null && Input.GetKeyDown(KeyCode.E) && !isCollected)
        {
            itemPickupConfirmation.ShowConfirmationDialog(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollider = other; // Store player collider reference to use in Update method
            interactKeyUI.SetActive(true); // Show UI when player enters the trigger zone
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollider = null; // Clear player collider reference when leaving the trigger zone
            interactKeyUI.SetActive(false); // Hide UI when player exits the trigger zone
        }
    }

    public void CollectItem()
    {
        if (isCollected)
        {
            return; // Avoid re-collecting the same item
        }

        if (itemsCollected < maxItems)
        {
            AddItemToInventory();
        }
        else
        {
            itemPickupConfirmation.ShowFullMochilaDialog(); // Show dialog to replace an item
        }
    }

    public void AddItemToInventory()
    {
        itemsCollected++; // Increment the number of items collected
        isCollected = true; // Mark this object as collected to prevent re-collection

        Item newItem = GetItem(); // Obtener el nuevo objeto basado en el tipo
        if (newItem != null)
        {
            mochila.Add(newItem);
            LogMochilaContents();
        }

        MakeInvisibleAndUninteractable();
    }

    public void ReplaceRandomItemInMochila()
    {
        if (mochila.Count > 0)
        {
            int randomIndex = Random.Range(0, mochila.Count);
            Item oldItem = mochila[randomIndex];
            RemoveItemEffect(oldItem); // Eliminar el efecto del objeto reemplazado

            Item newItem = GetItem();
            mochila[randomIndex] = newItem;
            LogMochilaContents();
        }

        MakeInvisibleAndUninteractable();
    }

    private void MakeInvisibleAndUninteractable()
    {
        GetComponent<Collider2D>().enabled = false;
        if (GetComponent<Renderer>() != null)
        {
            GetComponent<Renderer>().enabled = false;
        }

        interactKeyUI.SetActive(false); // Hide the interaction UI
    }

    private void LogMochilaContents()
    {
        Debug.Log("Contenido actual de la mochila:");
        foreach (var item in mochila)
        {
            Debug.Log(item.Name);
        }
    }

    public Item GetItem()
    {
        Item newItem = null;

        PlayerAttack playerAttack = playerCollider.GetComponent<PlayerAttack>();
        PlayerHealth playerHealth = playerCollider.GetComponent<PlayerHealth>();
        PlayerMovement playerMovement = playerCollider.GetComponent<PlayerMovement>();

        if (isToroide)
        {
            newItem = new Item("Toroide", "Aumenta el daño");
            playerAttack.IncreaseDamage(15);
            Debug.Log("Toroide pillado");
        }
        else if (isElectron)
        {
            newItem = new Item("Electron", "Aumenta la velocidad de ataque");
            playerAttack.IncreaseAttackSpeed(1);
            Debug.Log("Electron pillado");
        }
        else if (isLenguaDeFuego)
        {
            newItem = new Item("Lengua de Fuego", "Aumenta la velocidad de ataque");
            playerAttack.IncreaseAttackSpeed(1);
            Debug.Log("Lengua de Fuego pillado");
        }
        else if (isRocaVolcanica)
        {
            newItem = new Item("Roca Volcánica", "Incrementa el daño");
            playerAttack.IncreaseDamage(10);
            Debug.Log("Roca Volcánica pillado");
        }
        else if (isPalanca)
        {
            newItem = new Item("Palanca", "Aumenta el daño");
            playerAttack.IncreaseDamage(20);
            Debug.Log("Palanca pillado");
        }
        else if (isDurumDoble)
        {
            newItem = new Item("Durum Doble", "Aumenta la salud");
            playerHealth.IncreaseHealth(100);
            Debug.Log("Durum Doble pillado");
        }
        else if (isCrocks)
        {
            newItem = new Item("Crocks", "Permite doble salto");
            playerMovement.EnableDoubleJump();
            Debug.Log("Crocks pillado");
        }

        return newItem;
    }

    private void RemoveItemEffect(Item item)
    {
        PlayerAttack playerAttack = playerCollider.GetComponent<PlayerAttack>();
        PlayerHealth playerHealth = playerCollider.GetComponent<PlayerHealth>();
        PlayerMovement playerMovement = playerCollider.GetComponent<PlayerMovement>();

        switch (item.Name)
        {
            case "Toroide":
                playerAttack.IncreaseDamage(-15);
                Debug.Log("Toroide soltado");
                break;
            case "Electron":
                playerAttack.IncreaseAttackSpeed(-1);
                Debug.Log("Electron soltado");
                break;
            case "Lengua de Fuego":
                playerAttack.IncreaseAttackSpeed(-1);
                Debug.Log("Lengua de Fuego soltado");
                break;
            case "Roca Volcánica":
                playerAttack.IncreaseDamage(-10);
                Debug.Log("Roca Volcánica soltado");
                break;
            case "Palanca":
                playerAttack.IncreaseDamage(-20);
                Debug.Log("Palanca soltado");
                break;
            case "Durum Doble":
                playerHealth.IncreaseHealth(-100);
                Debug.Log("Durum Doble soltado");
                break;
            case "Crocks":
                playerMovement.DisableDoubleJump();
                Debug.Log("Crocks soltado");// Deshabilita el doble salto
                break;
        }
    }

    public void ReplaceItem(int index)
    {
        if (index >= 0 && index < mochila.Count)
        {
            Item oldItem = mochila[index];
            RemoveItemEffect(oldItem); // Eliminar el efecto del objeto reemplazado
            mochila.RemoveAt(index);
            AddItemToInventory();
        }
    }

    public int GetNumberItems()
    {
        return itemsCollected;
    }
}
