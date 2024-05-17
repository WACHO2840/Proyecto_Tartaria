using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGeneric : MonoBehaviour
{
    public static int itemsCollected = 0;
    public static int maxItems = 3; // Maximum number of items that can be collected

    public bool isToroide = true;
    public bool isElectron = true;
    public bool isLenguaDeFuego = true;
    public bool isRocaVolcanica = true;
    public bool isLlaveCorroida = true;
    public bool isPalanca = true;
    public bool isCrocks = true;
    public bool isDurumDoble = true;
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
        isCollected = true; // Mark this object as collected to prevent re-collection

        PlayerAttack playerAttack = playerCollider.GetComponent<PlayerAttack>();
        PlayerHealth playerHealth = playerCollider.GetComponent<PlayerHealth>();
        PlayerMovement playerMovement = playerCollider.GetComponent<PlayerMovement>();

        // Create a new Item object based on the type of item
        Item newItem = new Item();
        if (isToroide)
        {
            playerAttack.hasToroide = true;
            playerAttack.IncreaseDamage(5, 0);
            newItem.name = "Toroide";
            Debug.Log("OBJ Toroide pillado");
        }
        else if (isElectron)
        {
            playerAttack.hasElectron = true;
            newItem.name = "Electron";
            Debug.Log("OBJ Electron pillado");
        }
        else if (isLenguaDeFuego)
        {
            playerAttack.hasLenguaDeFuego = true;
            playerAttack.IncreaseAttackSpeed(0.5f, 0);
            newItem.name = "Lengua De Fuego";
            Debug.Log("OBJ Lengua De Fuego pillado");
        }
        else if (isRocaVolcanica)
        {
            playerAttack.hasRocaVolcanica = true;
            newItem.name = "Roca Volcanica";
            Debug.Log("OBJ Roca Volcánica pillado");
        }
        else if (isLlaveCorroida)
        {
            newItem.name = "Llave Corroida";
            Debug.Log("OBJ Llave Corroida pillado");
        }
        else if (isPalanca)
        {
            playerAttack.IncreaseDamage(10, 0);
            newItem.name = "Palanca";
            Debug.Log("OBJ Palanca pillado");
        }
        else if (isDurumDoble)
        {
            playerHealth.IncreaseHealth(25);
            newItem.name = "Durum Doble";
            Debug.Log("OBJ Durum pillado");
        }
        else if (isCrocks)
        {
            playerMovement.EnableDoubleJump();
            newItem.name = "Crocks";
            Debug.Log("Crocks recogidos, doble salto activado.");
        }
        // Add similar blocks for other item types

        Inventory.instance.AddItem(newItem);

        // Disable the collider and renderer to make the object non-interactive and invisible
        GetComponent<Collider2D>().enabled = false;
        if (GetComponent<Renderer>() != null)
        {
            GetComponent<Renderer>().enabled = false;
        }

        interactKeyUI.SetActive(false); // Hide the interaction UI
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PickUpGeneric : MonoBehaviour
{
    public static int itemsCollected = 0;
    public static int maxItems = 3; // Maximum number of items that can be collected

    public bool isToroide = true;
    public bool isElectron = true;
    public bool isLenguaDeFuego = true;
    public bool isRocaVolcanica = true;
    public bool isLlaveCorroida = true;
    public bool isPalanca = true;
    public bool isCrocks = true;
    public bool isDurumDoble = true;
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
        // Check if the player is pressing 'E', the player is present, the item is not yet collected, and item limit is not reached
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
        isCollected = true; // Mark this object as collected to prevent re-collection

        PlayerAttack playerAttack = playerCollider.GetComponent<PlayerAttack>();
        PlayerHealth playerHealth = playerCollider.GetComponent<PlayerHealth>();
        PlayerMovement playerMovement = playerCollider.GetComponent<PlayerMovement>();

        // Create a new Item object based on the type of item
        Item newItem = new Item();
        if (isToroide)
        {
            playerAttack.hasToroide = true;
            playerAttack.IncreaseDamage(5, 0);
            newItem.name = "Toroide";
            Debug.Log("OBJ Toroide pillado");
        }
        else if (isElectron)
        {
            playerAttack.hasElectron = true;
            newItem.name = "Electron";
            Debug.Log("OBJ Electron pillado");
        }
        else if (isLenguaDeFuego)
        {
            playerAttack.hasLenguaDeFuego = true;
            playerAttack.IncreaseAttackSpeed(0.5f, 0);
            newItem.name = "Lengua De Fuego";
            Debug.Log("OBJ Lengua De Fuego pillado");
        }
        else if (isRocaVolcanica)
        {
            playerAttack.hasRocaVolcanica = true;
            newItem.name = "Roca Volcanica";
            Debug.Log("OBJ Roca Volcánica pillado");
        }
        else if (isLlaveCorroida)
        {
            newItem.name = "Llave Corroida";
            Debug.Log("OBJ Llave Corroida pillado");
        }
        else if (isPalanca)
        {
            playerAttack.IncreaseDamage(10, 0);
            newItem.name = "Palanca";
            Debug.Log("OBJ Palanca pillado");
        }
        else if (isDurumDoble)
        {
            playerHealth.IncreaseHealth(25);
            newItem.name = "Durum Doble";
            Debug.Log("OBJ Durum pillado");
        }
        else if (isCrocks)
        {
            playerMovement.EnableDoubleJump();
            newItem.name = "Crocks";
            Debug.Log("Crocks recogidos, doble salto activado.");
        }
        // Add similar blocks for other item types

        Inventory.instance.AddItem(newItem);

        // Disable the collider and renderer to make the object non-interactive and invisible
        GetComponent<Collider2D>().enabled = false;
        if (GetComponent<Renderer>() != null)
        {
            GetComponent<Renderer>().enabled = false;
        }

        interactKeyUI.SetActive(false); // Hide the interaction UI
    }
}*/

