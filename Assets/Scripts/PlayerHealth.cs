using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    [SerializeField] private float maxHealth;
    private float health;
    private float iFramesCountdown = 1;
    private float iFrames;
    private SpriteRenderer sr;
    [SerializeField] private HealthBar hpBar;

    private void Awake()
    {
        instance = this;
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        health = maxHealth;
        hpBar.Bar(health);
    }

    void Update()
    {
        if (iFrames > 0)
        {
            iFrames -= Time.deltaTime;
            if (iFrames <= 0)
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
        hpBar.HpSet(health);
        health = 0;
    }

    public void DealMonsterDamage(int dmg)
    {
        if (iFrames <= 0)
        {
            health -= dmg;
            Debug.Log(health);
            hpBar.HpSet(health);
            if (health > 0)
            {
                iFrames = iFramesCountdown;
                PlayerMovement.instance.Knockback();
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
            }
        }
    }
}
