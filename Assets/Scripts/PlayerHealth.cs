using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    private float maxHealth = 100;
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

    public int MaxHealth // Propiedad pública para acceder y modificar el daño básico
    {
        get { return (int)maxHealth; }
        set { maxHealth = value; }
    }

    public void IncreaseHealth(int increaseAmountPickUp)
    {
        maxHealth += increaseAmountPickUp; // Incrementa el daño base
        Debug.Log("Daño incrementado. Nuevo daño: " + maxHealth);
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
            SceneManager.LoadScene(0);
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

                // Calcula la dirección del knockback
                Vector2 knockbackDirection = (PlayerMovement.instance.transform.position - enemyPosition).normalized;
                PlayerMovement.instance.Knockback(knockbackDirection); // Empujamos al jugador hacia atrás

                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f); // Le bajamos la transparencia para indicar la invulnerabilidad
            }
        }
    }
}


