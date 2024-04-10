using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBehaviour : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Hablar con el NPC 
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Hablando");
            }
            // Atacar al NPC

            // Intercambiar con el NPC
        }
    }

    // RECIBIR DAÑO DEL JUGADOR
    private void PlayerDammage()
    {

    }

    // INTERCAMBIAR CON EL NPC
    private void Trade()
    {

    }
}
