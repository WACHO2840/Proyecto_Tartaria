/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int itemsCollected = 0;
    public static int maxItems = 3;  // Límite máximo de objetos que se pueden recoger

    public bool isToroide = true;
    public bool isElectron = true;
    public bool isLenguaDeFuego = true;
    public bool isRocaVolcanica = true;
    public bool isLlaveCorroida = true;
    public bool isPalanca = true;
    public bool isCrocks = true;
    public bool isDurumDoble = true;
    private bool isCollected;

    public GameObject interactKeyUI;  // Arrastra aquí tu objeto de UI desde el editor

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Activa el UI cuando el jugador entra en el trigger
            if (interactKeyUI != null)
                interactKeyUI.SetActive(true);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Desactiva el UI cuando el jugador sale del trigger
            if (interactKeyUI != null)
                interactKeyUI.SetActive(false);
        }
    }*/


/*private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player") && !isCollected)
    {
        PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (isToroide)
        {
            playerAttack.hasToroide = true;
            playerAttack.IncreaseDamage(5, 0);
            Debug.Log("OBJ Toroide pillado");
        }
        else if (isElectron)
        {
            playerAttack.hasElectron = true;
            //StartCoroutine(TempDamageBoost(playerAttack));
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
            //StartCoroutine(TempDamageBoost(playerAttack));
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
            other.GetComponent<PlayerMovement>().EnableDoubleJump();
            Debug.Log("Crocks recogidos, doble salto activado.");
        }

        //playerAttack.ApplySynergyTyE();
        //playerAttack.ApplySynergyLyR();

        GetComponent<Collider2D>().enabled = false;
        if (GetComponent<Renderer>() != null)
        {
            GetComponent<Renderer>().enabled = false;
        }
        // Opcional: desactivar el GameObject
        // gameObject.SetActive(false);

        isCollected = true;
    }
}

IEnumerator TempDamageBoost(PlayerAttack player)
{
    if (player != null)
    {
        player.IncreaseDamage(5, 0);
        yield return new WaitForSeconds(3);
        player.IncreaseDamage(-5, 0);
        Debug.Log("El efecto del aumento de daño ha terminado.");
    }
}*/

/*private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        // Activa el UI cuando el jugador entra en el trigger
        if (interactKeyUI != null)
            interactKeyUI.SetActive(true);

    }
    if (other.CompareTag("Player"))
    {
        // Desactiva el UI cuando el jugador sale del trigger
        if (interactKeyUI != null)
            interactKeyUI.SetActive(false);
    }
    if (other.CompareTag("Player") && !isCollected)
    {
        if (itemsCollected < maxItems)  // Chequea si el límite de objetos aún no se ha alcanzado
        {
            PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Incrementa el contador de objetos recogidos
            itemsCollected++;

            // Efectuar el efecto correspondiente al objeto
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
                other.GetComponent<PlayerMovement>().EnableDoubleJump();
                Debug.Log("Crocks recogidos, doble salto activado.");
            }

            // Desactiva el collider y el renderizado para que el objeto no sea visible ni interactuable
            GetComponent<Collider2D>().enabled = false;
            if (GetComponent<Renderer>() != null)
            {
                GetComponent<Renderer>().enabled = false;
            }

            // Marca el objeto como recogido
            isCollected = true;
        }
        else
        {
            // Notifica que el límite ha sido alcanzado pero mantiene el objeto visible y no interactuable
            Debug.Log("Límite de objetos alcanzado, no puedes recoger más.");
            GetComponent<Collider2D>().enabled = false;  // Opcional: desactivar el collider pero mantener visible el objeto
        }
    }
}
}*/

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

    void Start()
    {
        interactKeyUI.SetActive(false); // Make sure UI is turned off on start
    }

    void Update()
    {
        // Check if the player is pressing 'E', the player is present, the item is not yet collected, and item limit is not reached
        if (playerCollider != null && Input.GetKeyDown(KeyCode.E) && !isCollected && itemsCollected < maxItems)
        {
            CollectItem();
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

    private void CollectItem()
    {
        itemsCollected++; // Increment the number of items collected
        isCollected = true; // Mark this object as collected to prevent re-collection

        PlayerAttack playerAttack = GetComponent<PlayerAttack>();
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        // Implement effects based on the type of item
        if (isToroide)
        {
            playerCollider.GetComponent<PlayerAttack>().hasToroide = true;
            playerCollider.GetComponent<PlayerAttack>().IncreaseDamage(5, 0);
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
        // Add similar blocks for other item types

        // Disable the collider and renderer to make the object non-interactive and invisible
        GetComponent<Collider2D>().enabled = false;
        if (GetComponent<Renderer>() != null)
        {
            GetComponent<Renderer>().enabled = false;
        }

        interactKeyUI.SetActive(false); // Hide the interaction UI
    }
}