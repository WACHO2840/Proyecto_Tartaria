using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class EnemyHealth : MonoBehaviour
{
    public static EnemyHealth instance;

    [SerializeField] int maxHealth;
    private int health;
    private float iFramesCountdown = 3;
    private float iFrames;
    private SpriteRenderer sr;

    private void Awake()
    {
        instance = this;
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
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
            gameObject.SetActive(false); // Hacer desaparecer el enemigo
        }
    }

    private void DealPlayerDamage(int damage, int weapon, bool knockback = true)
    {
        if (iFrames <= 0)
        {
            health = health - damage;
            if (health > 0)
            {
                iFrames = iFramesCountdown;
                if (knockback)
                {
                    EnemyMovement.instance.Knockback();
                }
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
            }
        }
    }
}
