using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public static playerHealth instance;
    
    public int health;
    public int max_health;

    public float iFramesCountdown;
    private float iFrames;

    private SpriteRenderer sr;

    private void Awake()
    {
        instance = this;

        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        health = max_health;
    }

    
    void Update()
    {
        if (iFrames > 0)
        {
            iFrames -= Time.deltaTime;
            if(iFrames <= 0)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            }
        }
    }

    public void DealDamageSpikes()
    {
        health = 0;
        gameObject.SetActive(false); // Hacer desaparecer el jugador
  
    }

    public void DealMonsterDamage()
    {

        DealDamage(30);

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

    private void DealDamage(int damage, bool knockback = true)
    {
        if (iFrames <= 0)
        {
            health = health - damage;
            if (health > 0)
            {
                iFrames = iFramesCountdown;
                if(knockback)
                {
                    playerMovement.instance.Knockback();
                }
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
            }
        }
    }
}
