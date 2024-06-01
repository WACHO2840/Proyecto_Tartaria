using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform weaponHolder;  // Referencia al Empty GameObject donde se guardará el arma
    private GameObject currentWeapon;  // Referencia al objeto actualmente recogido

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
        // Verifica si el objeto que colisiona tiene la etiqueta "katana" o "Mazo"
        if (other.CompareTag("katana") || other.CompareTag("Mazo"))
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
        if (weapon.CompareTag("katana"))
        {
            weapon.transform.localPosition = new Vector3(0.46f, -0.06f, 0f);
            weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
            weapon.transform.localScale = new Vector3(6.4f, 6.0f, 1.0f);
        }
        else if (weapon.CompareTag("Mazo"))
        {
            // Establece la posición, rotación y escala específicas para el mazo
            weapon.transform.localPosition = new Vector3(0.5f, -0.1f, 0f); // Ajusta estos valores según sea necesario
            weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
            weapon.transform.localScale = new Vector3(5.0f, 5.0f, 1.0f); // Ajusta estos valores según sea necesario
        }

        // Guardar la referencia del arma actual
        currentWeapon = weapon;
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

            // Limpiar la referencia del arma actual
            currentWeapon = null;
        }
    }
}
