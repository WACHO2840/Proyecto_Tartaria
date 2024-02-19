using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public static playerHealth instance;
    
    public int health;
    public int max_health;

    private void Awake()
    {
        instance = this;
    }

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

    public void DealMonsterDamage()
    {
        health -= 30;

        // HACER SWITCH DEPENDIENDO DEL NOMBRE DEL ENEMIGO PARA HACER DAÑO
        switch (health) 
        { 
            case 0:
                break; 
            case 1:
                break; 
            case 2:
                break;
            case 3: 
                break; 
            default:
                break;
        }
    }

    public void DealBossDamage()
    {
        health -= 30;

        switch (health)
        {
            case 0:
                break;
            case 1:
                break;
            default:
                break;
        }
    }

    
}
