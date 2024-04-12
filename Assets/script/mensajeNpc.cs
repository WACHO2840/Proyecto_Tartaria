using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mensajeNpc : MonoBehaviour
{
    public string mensaje = "Solo puedes elegir un arma, elige bien."; // Mensaje al acercarse al NPC

    private bool alreadySpoken = false; // Bandera para asegurar que el mensaje solo se muestre una vez

    // Método que se llama cuando algo entra en el área de colisión del NPC
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!alreadySpoken && other.CompareTag("playerNpc"))
        {
            Debug.Log(mensaje); // Mostrar el mensaje en la consola (puedes cambiar esto por otro método para mostrar el mensaje)
            alreadySpoken = true; // Actualizar la bandera
        }
    }
}