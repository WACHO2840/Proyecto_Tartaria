using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public EndGame endGame;

    private float maxHealth = 100;
    private float health;
    private float iFramesCountdown = 1;
    private float iFrames;
    private SpriteRenderer sr;
    [SerializeField] private HealthBar hpBar;

    private Randomizer randomizer;

    private void Awake()
    {
        // instanciar GameObjects y sprite
        instance = this;
        sr = GetComponent<SpriteRenderer>();

        endGame = FindObjectOfType<EndGame>();
        if (endGame == null)
        {
            Debug.LogError("No se encontró un objeto con el script EndGame en la escena.");
        }
    }

    void Start()
    {
        // Inicializar la vida
        health = maxHealth;
        hpBar.Bar(health);
    }

    void Update()
    {
        // Invulnerabilidad
        if (iFrames > 0)
        {
            iFrames -= Time.deltaTime;
            if (iFrames <= 0)
            {
                // Invulnerabilidad visual
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            }
        }
        //Comprobar vida del personaje
        if (health <= 0)
        {
            gameObject.SetActive(false); // Hacer desaparecer el jugador
            if (endGame != null)
            {
                // Activar escena de muertes
                endGame.FinalScreenSet();
            }
            if (randomizer != null)
            {
                randomizer.OnPlayerDeath();
            }
        }
    }
    // Recibir daño de los pinchos
    public void DealDamageSpikes()
    {
        health = 0;
        hpBar.HpSet(health);
    }
    // Recibir daño de los enemigos
    public void DealMonsterDamage(int dmg, Vector3 enemyPosition)
    {
        // Comprobar que no haya invulnerabilidad 
        if (iFrames <= 0)
        {
            // Restar vida y actualizar UI
            health -= dmg; 
            hpBar.HpSet(health);
            if (health > 0) 
            {
                iFrames = iFramesCountdown; // Le volvemos invulnerable

                // Calcula la dirección del knockback
                Vector2 knockbackDirection = (PlayerMovement.instance.transform.position - enemyPosition).normalized;
                PlayerMovement.instance.Knockback(knockbackDirection); // Empujamos al jugador hacia atrás

                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f); // Le bajamos la transparencia para indicar la invulnerabilidad
            }
        }
    }

    // Curar al personaje
    public void IncreaseHealth(int increaseAmountPickUp)
    {
        health = maxHealth;
        hpBar.HpSet(health);
    }

    public float GetCurrentHealth()
    {
        return health;
    }
}