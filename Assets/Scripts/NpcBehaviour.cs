using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBehaviour : MonoBehaviour
{
    private int health = 0;

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
        if (collision.tag == "Player") 
        {
            // Hablar con el NPC 
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Hablando");
            }
            // Atacar al NPC

            // Intercambiar con el NPC
        }
    }
}
