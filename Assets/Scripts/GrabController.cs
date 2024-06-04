/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform weaponHolder;  // Referencia al Empty GameObject donde se guardará el arma
    private GameObject currentWeapon;  // Referencia al objeto actualmente recogido

    public PlayerAttack playerAttack;  // Referencia al script PlayerAttack del jugador

    void Update()
    {
        // Detectar el input "Fire2" para soltar el arma
        if (Input.GetButtonDown("Fire2") && currentWeapon != null)
        {
            DropWeapon();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisiona tiene la etiqueta "Katana" o "Mazo"
        if (other.CompareTag("Katana") || other.CompareTag("Mazo"))
        {
            // Si ya tienes un arma, no hacer nada
            if (currentWeapon != null)
            {
                return;
            }

            // Recoger el arma
            PickUpWeapon(other.gameObject);
        }
    }

    void PickUpWeapon(GameObject weapon)
    {
        // Desactivar el collider del arma para que no cause más colisiones
        weapon.GetComponent<Collider2D>().enabled = false;

        // Hacer que el arma sea hija del weaponHolder
        weapon.transform.SetParent(weaponHolder);

        // Establecer la posición, rotación y escala del arma relativa al weaponHolder
        if (weapon.CompareTag("Katana"))
        {
            weapon.transform.localPosition = new Vector3(0.48f, 0.44f, 0f);
            weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
            weapon.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if (weapon.CompareTag("Mazo"))
        {
            // Establece la posición, rotación y escala específicas para el mazo
            weapon.transform.localPosition = new Vector3(0.48f, 0.44f, 0f);
            weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
            weapon.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        // Guardar la referencia del arma actual
        currentWeapon = weapon;

        // Equipar el arma en PlayerAttack
        playerAttack.EquipWeapon(weapon);
    }

    void DropWeapon()
    {
        // Si hay un arma actual, soltarla
        if (currentWeapon != null)
        {
            // Reactivar el collider del arma
            currentWeapon.GetComponent<Collider2D>().enabled = true;

            // Deshacer la relación padre-hijo
            currentWeapon.transform.SetParent(null);

            // Establecer la posición actual del arma ligeramente fuera del jugador para evitar problemas de colisión
            Vector3 dropPosition = transform.position + transform.right * 1.5f; // Ajustar la dirección y distancia del drop según sea necesario
            currentWeapon.transform.position = dropPosition;

            // Desequipar el arma en PlayerAttack
            playerAttack.UnequipWeapon();

            // Limpiar la referencia del arma actual
            currentWeapon = null;
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabController : MonoBehaviour
{
    public Transform weaponHolder;  // Referencia al Empty GameObject donde se guardará el arma
    public PlayerAttack playerAttack;  // Referencia al script PlayerAttack del jugador

    public GameObject katanaPanel;  // Panel de confirmación para la Katana
    public Button katanaYesButton;  // Botón "Sí" en el panel de la Katana
    public Button katanaNoButton;   // Botón "No" en el panel de la Katana

    public GameObject mazoPanel;    // Panel de confirmación para el Mazo
    public Button mazoYesButton;    // Botón "Sí" en el panel del Mazo
    public Button mazoNoButton;     // Botón "No" en el panel del Mazo

    private GameObject currentWeapon;  // Referencia al objeto actualmente recogido
    private GameObject weaponInRange;  // Referencia al arma que está en el rango

    private void Start()
    {
        // Asegurarse de que los paneles de confirmación estén ocultos al inicio
        if (katanaPanel != null)
        {
            katanaPanel.SetActive(false);
        }
        if (mazoPanel != null)
        {
            mazoPanel.SetActive(false);
        }

        // Asignar listeners a los botones
        if (katanaYesButton != null)
        {
            katanaYesButton.onClick.AddListener(() => PickUpWeapon("Katana"));
        }
        if (katanaNoButton != null)
        {
            katanaNoButton.onClick.AddListener(CancelPickUp);
        }
        if (mazoYesButton != null)
        {
            mazoYesButton.onClick.AddListener(() => PickUpWeapon("Mazo"));
        }
        if (mazoNoButton != null)
        {
            mazoNoButton.onClick.AddListener(CancelPickUp);
        }
    }

    private void Update()
    {
        // Detectar la tecla "E" para mostrar el panel de confirmación
        if (Input.GetKeyDown(KeyCode.E) && weaponInRange != null)
        {
            if (weaponInRange.CompareTag("Katana"))
            {
                katanaPanel.SetActive(true);
            }
            else if (weaponInRange.CompareTag("Mazo"))
            {
                mazoPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisiona tiene la etiqueta "Katana" o "Mazo"
        if (other.CompareTag("Katana") || other.CompareTag("Mazo"))
        {
            weaponInRange = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == weaponInRange)
        {
            weaponInRange = null;
            CancelPickUp(); // Ocultar paneles de confirmación si el jugador sale del rango
        }
    }

    public void PickUpWeapon(string weaponTag)
    {
        if (weaponInRange != null && weaponInRange.CompareTag(weaponTag))
        {
            GameObject weapon = weaponInRange;
            weaponInRange = null;

            // Desactivar el collider del arma para que no cause más colisiones
            weapon.GetComponent<Collider2D>().enabled = false;

            // Hacer que el arma sea hija del weaponHolder
            weapon.transform.SetParent(weaponHolder);

            // Establecer la posición, rotación y escala del arma relativa al weaponHolder
            weapon.transform.localPosition = new Vector3(0.48f, 0.44f, 0f);
            weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
            weapon.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            // Guardar la referencia del arma actual
            currentWeapon = weapon;

            // Equipar el arma en PlayerAttack
            playerAttack.EquipWeapon(weapon);

            // Hacer invisible e invulnerable el arma no elegida
            MakeOtherWeaponInvisible(weapon);
        }

        // Ocultar los paneles de confirmación después de recoger el arma
        CancelPickUp();
    }

    private void MakeOtherWeaponInvisible(GameObject pickedWeapon)
    {
        if (pickedWeapon.CompareTag("Katana"))
        {
            GameObject mazo = GameObject.FindGameObjectWithTag("Mazo");
            if (mazo != null)
            {
                mazo.GetComponent<Renderer>().enabled = false;
                mazo.GetComponent<Collider2D>().enabled = false;
            }
        }
        else if (pickedWeapon.CompareTag("Mazo"))
        {
            GameObject katana = GameObject.FindGameObjectWithTag("Katana");
            if (katana != null)
            {
                katana.GetComponent<Renderer>().enabled = false;
                katana.GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    public void CancelPickUp()
    {
        if (katanaPanel != null)
        {
            katanaPanel.SetActive(false);
        }
        if (mazoPanel != null)
        {
            mazoPanel.SetActive(false);
        }
    }
}
