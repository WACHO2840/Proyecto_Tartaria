using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class spikeDamage : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // COMPROBAR QUE EL JUGADOR HA TOCADO
       if (collision.tag == "Player") 
        {
            //Debug.Log("Hit");

            // FindObjectOfType<playerHealth>().DealDamageSpikes();

            playerHealth.instance.DealMonsterDamage();
        }

    }
}
