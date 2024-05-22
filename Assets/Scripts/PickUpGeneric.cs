/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGeneric : MonoBehaviour
{
    public static int itemsCollected = 0;
    public static int maxItems = 3; // Maximum number of items that can be collected
    public static List<Item> mochila = new List<Item>();

    public bool isToroide;
    public bool isElectron;
    public bool isLenguaDeFuego;
    public bool isRocaVolcanica;
    public bool isLlaveCorroida;
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

        PlayerAttack playerAttack = playerCollider.GetComponent<PlayerAttack>();
        PlayerHealth playerHealth = playerCollider.GetComponent<PlayerHealth>();
        PlayerMovement playerMovement = playerCollider.GetComponent<PlayerMovement>();

        Item newItem = null;

        // Implement effects based on the type of item
        if (isToroide)
        {
            playerAttack.hasToroide = true;
            playerAttack.IncreaseDamage(5, 0);
            Debug.Log("OBJ Toroide pillado");
            newItem = new Item("Toroide", "Aumenta el daño");
        }
        else if (isElectron)
        {
            playerAttack.hasElectron = true;
            Debug.Log("OBJ Electron pillado");
            newItem = new Item("Electron", "Aumenta la velocidad de ataque");
        }
        else if (isLenguaDeFuego)
        {
            playerAttack.hasLenguaDeFuego = true;
            playerAttack.IncreaseAttackSpeed(0.5f, 0);
            Debug.Log("OBJ Lengua De Fuego pillado");
            newItem = new Item("Lengua de Fuego", "Aumenta la velocidad de ataque");
        }
        else if (isRocaVolcanica)
        {
            playerAttack.hasRocaVolcanica = true;
            Debug.Log("OBJ Roca Volcánica pillado");
            newItem = new Item("Roca Volcánica", "Incrementa el daño");
        }
        else if (isLlaveCorroida)
        {
            Debug.Log("OBJ Llave Corroida pillado");
            newItem = new Item("Llave Corroida", "Llave especial");
        }
        else if (isPalanca)
        {
            playerAttack.IncreaseDamage(10, 0);
            Debug.Log("OBJ Palanca pillado");
            newItem = new Item("Palanca", "Aumenta el daño");
        }
        else if (isDurumDoble)
        {
            playerHealth.IncreaseHealth(25);
            Debug.Log("OBJ Durum pillado");
            newItem = new Item("Durum Doble", "Aumenta la salud");
        }
        else if (isCrocks)
        {
            playerMovement.EnableDoubleJump();
            Debug.Log("Crocks recogidos, doble salto activado.");
            newItem = new Item("Crocks", "Permite doble salto");
        }

        if (newItem != null)
        {
            mochila.Add(newItem);
        }

        // Make the object invulnerable and invisible
        GetComponent<Collider2D>().enabled = false;
        if (GetComponent<Renderer>() != null)
        {
            GetComponent<Renderer>().enabled = false;
        }

        interactKeyUI.SetActive(false); // Hide the interaction UI
    }

    public Item GetItem()
    {
        PlayerAttack playerAttack = playerCollider.GetComponent<PlayerAttack>();
        PlayerHealth playerHealth = playerCollider.GetComponent<PlayerHealth>();
        PlayerMovement playerMovement = playerCollider.GetComponent<PlayerMovement>();

        Item newItem = null;

        if (isToroide)
        {
            newItem = new Item("Toroide", "Aumenta el daño");
        }
        else if (isElectron)
        {
            newItem = new Item("Electron", "Aumenta la velocidad de ataque");
        }
        else if (isLenguaDeFuego)
        {
            newItem = new Item("Lengua de Fuego", "Aumenta la velocidad de ataque");
        }
        else if (isRocaVolcanica)
        {
            newItem = new Item("Roca Volcánica", "Incrementa el daño");
        }
        else if (isLlaveCorroida)
        {
            newItem = new Item("Llave Corroida", "Llave especial");
        }
        else if (isPalanca)
        {
            newItem = new Item("Palanca", "Aumenta el daño");
        }
        else if (isDurumDoble)
        {
            newItem = new Item("Durum Doble", "Aumenta la salud");
        }
        else if (isCrocks)
        {
            newItem = new Item("Crocks", "Permite doble salto");
        }

        return newItem;
    }

    public void ReplaceItem(int index)
    {
        if (index >= 0 && index < mochila.Count)
        {
            mochila.RemoveAt(index);
            itemsCollected--;
            AddItemToInventory();
        }
    }

    public int GetNumberItems()
    {
        return itemsCollected;
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGeneric : MonoBehaviour
{
    public static int itemsCollected = 0;
    public static int maxItems = 3; // Maximum number of items that can be collected
    public static List<Item> mochila = new List<Item>();

    public bool isToroide;
    public bool isElectron;
    public bool isLenguaDeFuego;
    public bool isRocaVolcanica;
    public bool isLlaveCorroida;
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

        PlayerAttack playerAttack = playerCollider.GetComponent<PlayerAttack>();
        PlayerHealth playerHealth = playerCollider.GetComponent<PlayerHealth>();
        PlayerMovement playerMovement = playerCollider.GetComponent<PlayerMovement>();

        Item newItem = GetItem(); // Obtener el nuevo objeto basado en el tipo
        if (newItem != null)
        {
            mochila.Add(newItem);
            LogMochilaContents();
        }

        MakeInvisibleAndUninteractable();
    }

    public void ReplaceLastItemInMochila()
    {
        if (mochila.Count > 0)
        {
            mochila[mochila.Count - 1] = GetItem();
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

        if (isToroide)
        {
            newItem = new Item("Toroide", "Aumenta el daño");
        }
        else if (isElectron)
        {
            newItem = new Item("Electron", "Aumenta la velocidad de ataque");
        }
        else if (isLenguaDeFuego)
        {
            newItem = new Item("Lengua de Fuego", "Aumenta la velocidad de ataque");
        }
        else if (isRocaVolcanica)
        {
            newItem = new Item("Roca Volcánica", "Incrementa el daño");
        }
        else if (isLlaveCorroida)
        {
            newItem = new Item("Llave Corroida", "Llave especial");
        }
        else if (isPalanca)
        {
            newItem = new Item("Palanca", "Aumenta el daño");
        }
        else if (isDurumDoble)
        {
            newItem = new Item("Durum Doble", "Aumenta la salud");
        }
        else if (isCrocks)
        {
            newItem = new Item("Crocks", "Permite doble salto");
        }

        return newItem;
    }

    public void ReplaceItem(int index)
    {
        if (index >= 0 && index < mochila.Count)
        {
            mochila.RemoveAt(index);
            itemsCollected--;
            AddItemToInventory();
        }
    }

    public int GetNumberItems()
    {
        return itemsCollected;
    }
}




