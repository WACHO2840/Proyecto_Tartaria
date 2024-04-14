using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // COMPROBAR QUE EL JUGADOR HA TOCADO
        if (collision.tag == "Player")
        {
            Debug.Log("PLAYER TOCADO");
            PlayerHealth.instance.DealDamageSpikes();
        }
    }
}
