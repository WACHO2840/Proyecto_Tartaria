using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class EnemyStats : MonoBehaviour
{
    public static EnemyStats Instance;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] int damage;
    [SerializeField] int movementSpeed;
    [SerializeField] int health;
    [SerializeField] double attackSpeed;

    private int maxHealth = 100;
    private float iFramesCountdown;
    private float iFrames = 3;
    private SpriteRenderer sr;

    private float knockbackDistance = 10;
    private float knockbackPower = 5;
    private float knockbackCounter;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        Instance = this;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iFrames > 0)
        {
            iFrames -= Time.deltaTime;
            if (iFrames <= 0)
            {
                // Hacer visual que el enemigo ha sido dañado
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            }
        }
        if (health <= 0)
        {
            // Hacer desaparecer el enemigo
            gameObject.SetActive(false); 
        }
        if (knockbackCounter <= 0)
        {
            if (rb.velocity.x < 0)
            {
                sr.flipX = true; //Izquierda
            }
            else if (rb.velocity.x > 0)
            {
                sr.flipX = false; //Derecha
            }
        }
        else
        {
            knockbackCounter -= Time.deltaTime;

            if (sr.flipX)
                rb.velocity = new Vector2(knockbackPower, rb.velocity.y);
            else
                rb.velocity = new Vector2(-knockbackPower, rb.velocity.y);
        }
    }

    private void GetDamage(int damage, bool knockback = true)
    {
        if (iFrames <= 0)
        {
            health = health - damage;
            if (health > 0)
            {
                iFrames = iFramesCountdown;
                if (knockback)
                {
                    Knockback();
                }
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
            }
        }
    }

    public void Knockback()
    {
        knockbackCounter = knockbackDistance;
        rb.velocity = new Vector2(0f, knockbackPower / 2);
    }
}
