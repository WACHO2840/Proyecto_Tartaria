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
       if (collision.tag == "Player") 
        { 
            UnityEngine.Debug.Log("Hit");
        }

    }
}
