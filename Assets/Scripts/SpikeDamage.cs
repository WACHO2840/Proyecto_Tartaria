using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") // Comprobar que ha colisionado con el jugador
        {
            PlayerHealth.instance.DealDamageSpikes(); // Llamar a la funcion para bajar la vida
        }
    }
}
