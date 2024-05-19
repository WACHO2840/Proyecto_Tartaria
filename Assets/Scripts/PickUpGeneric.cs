using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGeneric : MonoBehaviour
{
    public static int itemsCollected = 0;
    public static int maxItems = 3; // Maximum number of items that can be collected

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

        itemsCollected++; // Increment the number of items collected
        isCollected = true; // Mark this object as collected to prevent re-collection

        PlayerAttack playerAttack = playerCollider.GetComponent<PlayerAttack>();
        PlayerHealth playerHealth = playerCollider.GetComponent<PlayerHealth>();
        PlayerMovement playerMovement = playerCollider.GetComponent<PlayerMovement>();

        // Implement effects based on the type of item
        if (isToroide)
        {
            playerAttack.hasToroide = true;
            playerAttack.IncreaseDamage(5, 0);
            Debug.Log("OBJ Toroide pillado");
        }
        else if (isElectron)
        {
            playerAttack.hasElectron = true;
            Debug.Log("OBJ Electron pillado");
        }
        else if (isLenguaDeFuego)
        {
            playerAttack.hasLenguaDeFuego = true;
            playerAttack.IncreaseAttackSpeed(0.5f, 0);
            Debug.Log("OBJ Lengua De Fuego pillado");
        }
        else if (isRocaVolcanica)
        {
            playerAttack.hasRocaVolcanica = true;
            Debug.Log("OBJ Roca Volcánica pillado");
        }
        else if (isLlaveCorroida)
        {
            Debug.Log("OBJ Llave Corroida pillado");
        }
        else if (isPalanca)
        {
            playerAttack.IncreaseDamage(10, 0);
            Debug.Log("OBJ Palanca pillado");
        }
        else if (isDurumDoble)
        {
            playerHealth.IncreaseHealth(25);
            Debug.Log("OBJ Durum pillado");
        }
        else if (isCrocks)
        {
            playerMovement.EnableDoubleJump();
            Debug.Log("Crocks recogidos, doble salto activado.");
        }

        // Make the object invulnerable and invisible
        GetComponent<Collider2D>().enabled = false;
        if (GetComponent<Renderer>() != null)
        {
            GetComponent<Renderer>().enabled = false;
        }

        interactKeyUI.SetActive(false); // Hide the interaction UI
    }

    public int GetNumberItems()
    {
        return itemsCollected;
    }
}