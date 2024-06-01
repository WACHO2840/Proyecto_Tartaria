using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (other.CompareTag("Player"))
        {
            // Aquí puedes agregar la lógica para lo que sucede cuando el jugador recoge el objeto
            // Por ejemplo, podrías aumentar el puntaje, agregar el objeto al inventario, etc.
            Debug.Log("Objeto recogido");

            // Destruir el objeto recogible
            Destroy(gameObject);
        }
    }
}
