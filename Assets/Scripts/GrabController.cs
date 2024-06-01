using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform weaponHolder;  // Referencia al Empty GameObject donde se guardará la katana
    private GameObject currentWeapon;  // Referencia al objeto actualmente recogido

    void Update()
    {
        // Detectar el input "Fire2" para soltar el arma
        if (Input.GetButtonDown("Fire2") && currentWeapon != null)
        {
            DropKatana();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisiona tiene la etiqueta "katana"
        if (other.CompareTag("katana"))
        {
            // Recoger la katana
            PickUpKatana(other.gameObject);
        }
    }

    void PickUpKatana(GameObject katana)
    {
        // Desactivar el collider de la katana para que no cause más colisiones
        katana.GetComponent<Collider2D>().enabled = false;

        // Hacer que la katana sea hija del weaponHolder
        katana.transform.SetParent(weaponHolder);

        // Establecer la posición, rotación y escala de la katana relativa al weaponHolder
        katana.transform.localPosition = new Vector3(0.46f, -0.06f, 0f);
        katana.transform.localRotation = Quaternion.Euler(0, 0, 0);
        katana.transform.localScale = new Vector3(6.4f, 6.0f, 1.0f);

        // Guardar la referencia del arma actual
        currentWeapon = katana;
    }

    void DropKatana()
    {
        // Si hay un arma actual, soltarla
        if (currentWeapon != null)
        {
            // Reactivar el collider de la katana
            currentWeapon.GetComponent<Collider2D>().enabled = true;

            // Deshacer la relación padre-hijo
            currentWeapon.transform.SetParent(null);

            // Establecer la posición actual de la katana ligeramente fuera del jugador para evitar problemas de colisión
            Vector3 dropPosition = transform.position + transform.right * 1.5f; // Ajustar la dirección y distancia del drop según sea necesario
            currentWeapon.transform.position = dropPosition;

            // Limpiar la referencia del arma actual
            currentWeapon = null;
        }
    }
}
