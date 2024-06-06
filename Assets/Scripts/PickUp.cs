using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public static int itemsCollected = 0;
    public static int maxItems = 3; // Objetos maximos
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

    public GameObject interactKeyUI; 
    public ItemPickupConfirmation itemPickupConfirmation; 

    void Start()
    {
        interactKeyUI.SetActive(false);
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
            playerCollider = other; 
            interactKeyUI.SetActive(true); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollider = null; 
            interactKeyUI.SetActive(false); 
            itemPickupConfirmation.HideAllDialogs(); 
        }
    }

    public void CollectItem()
    {
        if (isCollected)
        {
            return; 
        }

        if (itemsCollected < maxItems)
        {
            AddItemToInventory();
        }
        else
        {
            itemPickupConfirmation.ShowFullMochilaDialog();
        }
    }

    public void AddItemToInventory()
    {
        itemsCollected++; 
        isCollected = true; 

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
            ApplyItemEffect(newItem);
            LogMochilaContents();

            MakeInvisibleAndUninteractable(); // Hacer el objeto recogido invisible e invulnerable
        }
    }

    public void ApplyItemEffect(Item item)
    {
        PlayerAttack playerAttack = playerCollider.GetComponent<PlayerAttack>();
        PlayerHealth playerHealth = playerCollider.GetComponent<PlayerHealth>();
        PlayerMovement playerMovement = playerCollider.GetComponent<PlayerMovement>();

        switch (item.Name)
        {
            case "Toroide":
                playerAttack.IncreaseDamage(5);
                break;
            case "Electron":
                playerAttack.IncreaseAttackSpeed(-0.5f);
                break;
            case "Lengua de Fuego":
                playerAttack.IncreaseAttackSpeed(-0.5f);
                break;
            case "Roca Volcánica":
                playerAttack.IncreaseDamage(5);
                break;
            case "Palanca":
                playerAttack.IncreaseDamage(10);
                break;
            case "Durum Doble":
                playerHealth.IncreaseHealth(70);
                break;
            case "Crocks":
                playerMovement.EnableDoubleJump();
                break;
        }
    }

    public void RemoveItemEffect(Item item)
    {
        PlayerAttack playerAttack = playerCollider.GetComponent<PlayerAttack>();
        PlayerHealth playerHealth = playerCollider.GetComponent<PlayerHealth>();
        PlayerMovement playerMovement = playerCollider.GetComponent<PlayerMovement>();

        switch (item.Name)
        {
            case "Toroide":
                playerAttack.IncreaseDamage(-5);
                break;
            case "Electron":
                playerAttack.IncreaseAttackSpeed(0.5f);
                break;
            case "Lengua de Fuego":
                playerAttack.IncreaseAttackSpeed(0.5f);
                break;
            case "Roca Volcánica":
                playerAttack.IncreaseDamage(-5);
                break;
            case "Palanca":
                playerAttack.IncreaseDamage(-10);
                break;
            case "Durum Doble":
                playerHealth.IncreaseHealth(-70);
                break;
            case "Crocks":
                playerMovement.DisableDoubleJump();
                break;
        }
    }

    public void MakeInvisibleAndUninteractable()
    {
        GetComponent<Collider2D>().enabled = false;
        if (GetComponent<Renderer>() != null)
        {
            GetComponent<Renderer>().enabled = false;
        }

        interactKeyUI.SetActive(false);
    }

    public void LogMochilaContents()
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
            playerAttack.IncreaseDamage(5);
        }
        else if (isElectron)
        {
            newItem = new Item("Electron", "Aumenta la velocidad de ataque");
            playerAttack.IncreaseAttackSpeed(-0.5f);
        }
        else if (isLenguaDeFuego)
        {
            newItem = new Item("Lengua de Fuego", "Aumenta la velocidad de ataque");
            playerAttack.IncreaseAttackSpeed(-0.5f);
        }
        else if (isRocaVolcanica)
        {
            newItem = new Item("Roca Volcánica", "Incrementa el daño");
            playerAttack.IncreaseDamage(5);
        }
        else if (isPalanca)
        {
            newItem = new Item("Palanca", "Aumenta el daño");
            playerAttack.IncreaseDamage(10);
        }
        else if (isDurumDoble)
        {
            newItem = new Item("Durum Doble", "Aumenta la salud");
            playerHealth.IncreaseHealth(70);
        }
        else if (isCrocks)
        {
            newItem = new Item("Crocks", "Permite doble salto");
            playerMovement.EnableDoubleJump();
        }

        return newItem;
    }
}
