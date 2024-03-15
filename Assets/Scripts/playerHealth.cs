using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public static playerHealth instance;

    [SerializeField] int max_health;
    private int health;
    private float iFramesCountdown = 10;
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
        if (health <= 0)
        {
            gameObject.SetActive(false); // Hacer desaparecer el jugador

                                         //Hacer saltar el canvas de fin de juego
        }
    }

    public void DealDamageSpikes()
    {
        health = 0;
    }

    public void DealMonsterDamage(string enemyName, bool knockback = false)
    {
        // HACER SWITCH DEPENDIENDO DEL NOMBRE DEL ENEMIGO PARA HACER DAÑO
        switch (enemyName) 
        { 
            case "Enemy1":
                DamamageFilter(knockback, 10);
                Debug.Log(health);
                break; 
            case "Enemy2":
                DamamageFilter(knockback, 13);
                Debug.Log(health);
                break; 
            case "Enemy3":
                DamamageFilter(knockback, 20);
                break;
            case "Enemy4":
                DamamageFilter(knockback, 50);
                break;
            case "Enemy5":
                DamamageFilter(knockback, 20);
                break;
            case "Boss1":
                DamamageFilter(knockback, 33);
                break;
            case "Boss2":
                DamamageFilter(knockback, 40);
                break;
            case "Boss3":
                DamamageFilter(knockback, 40);
                break;
            default:
                DamamageFilter(knockback, 0);
                break;
        }
    }

    private void DealDamage(int damage, bool knockback = false, bool slowDown = false)
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

    private void DamamageFilter(bool knockback, int damage)
    {
        if (knockback) //Si hace contacto con su hitbox
        {
            DealDamage(damage, true);
        }
        else if (!knockback) //Si el enemigo le pega al jugador
        {
            DealDamage(damage, false, true);
        }
    }
}
