using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int health;
    public int max_health;

    void Start()
    {
        health = max_health;
    }

    
    void Update()
    {
        
    }

    public void DealDamageSpikes()
    {
        health = 0;
        gameObject.SetActive(false); // Hacer desaparecer el jugador
    }
}
