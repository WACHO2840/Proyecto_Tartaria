using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mensajeNpc : MonoBehaviour
{
    public Transform target; // El objeto target (jugador)
    public string mensaje = "Solo puedes elegir una arma, elige bien."; // Mensaje al inicio del nivel

    private bool alreadySpoken = false; // Bandera para asegurar que el mensaje solo se muestre una vez

    // M�todo que se llama al inicio del juego
    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("No se ha asignado el objeto target en el NPCController.");
        }
    }

    // M�todo que se llama en cada fotograma
    void Update()
    {
        if (!alreadySpoken && target != null && Vector3.Distance(transform.position, target.position) < 5f)
        {
            // Si el jugador est� cerca y a�n no se ha mostrado el mensaje
            Debug.Log(mensaje); // Muestra el mensaje en la consola (puedes cambiar esto por una animaci�n o un cuadro de di�logo)
            alreadySpoken = true; // Actualiza la bandera para que no se muestre el mensaje repetidamente
        }
    }
}