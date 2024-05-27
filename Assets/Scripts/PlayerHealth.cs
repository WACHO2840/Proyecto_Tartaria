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

    public void DealMonsterDamage(int dmg, Vector3 enemyPosition)
    {
        if (iFrames <= 0)
        {
            health -= dmg; // Bajamos la vida del jugador
            hpBar.HpSet(health); // Actualizamos la barra de vida
            if (health > 0) // Comprobamos que el jugador siga teniendo vida
            {
                iFrames = iFramesCountdown; // Le volvemos invulnerable

                // Calcula la direcci�n del knockback
                Vector2 knockbackDirection = (PlayerMovement.instance.transform.position - enemyPosition).normalized;
                PlayerMovement.instance.Knockback(knockbackDirection); // Empujamos al jugador hacia atr�s

                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f); // Le bajamos la transparencia para indicar la invulnerabilidad
            }
        }
    }

}
