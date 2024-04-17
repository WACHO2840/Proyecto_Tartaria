using System.Collections;
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

    public bool isToroide = true;
    public bool isElectron = true;
    public bool isLenguaDeFuego = true;
    public bool isRocaVolcanica = true;
    public bool isPalanca = true;

    public bool isDurumDoble = true;
    private bool isCollected;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (isToroide)
            {
                playerAttack.IncreaseDamage(5, 0);
                Debug.Log("OBJ Toroide pillado");
                Destroy(gameObject);
            }
            else if (isElectron)
            {
                StartCoroutine(TempDamageBoost(playerAttack));
                Debug.Log("OBJ Electron pillado");
                GetComponent<Collider2D>().enabled = false;
                if (GetComponent<Renderer>() != null)
                {
                    GetComponent<Renderer>().enabled = false;
                }
            }
            else if (isLenguaDeFuego)
            {
                playerAttack.IncreaseAttackSpeed(0.5, 0);
                Debug.Log("OBJ Lengua De Fuego pillado");
                Destroy(gameObject);
            }
            else if (isRocaVolcanica)
            {
                StartCoroutine(TempDamageBoost(playerAttack));
                Debug.Log("OBJ Roca Volcánica pillado");
                GetComponent<Collider2D>().enabled = false;
                if (GetComponent<Renderer>() != null)
                {
                    GetComponent<Renderer>().enabled = false;
                }
            }
            else if (isPalanca)
            {
                playerAttack.IncreaseDamage(10, 0);
                Debug.Log("OBJ Palanca pillado");
                Destroy(gameObject);
            }
            else if (isDurumDoble)
            {
                playerHealth.IncreaseHealth(25);
                Debug.Log("OBJ Durum pillado");
                Destroy(gameObject);
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
    }
}
