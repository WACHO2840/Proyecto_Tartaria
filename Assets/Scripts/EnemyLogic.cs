using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyLogic : MonoBehaviour
{
    public static EnemyLogic Instance;

    #region Variables
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform player;
    [SerializeField] float knockbackDistance;
    [SerializeField] float knockbackPower;
    [SerializeField] float iFramesCountdown = 3;
    [SerializeField] float inTimer;
    [SerializeField] private float detectionRange = 6f;
    private float iFrames;
    private bool cooldown = true;
    private bool inCombat = false;
    private float inTime;
    private SpriteRenderer sr;
    private int currentPatrolIndex;
    private Transform patrolTarget;
    private float knockbackCounter;
    #endregion

    private void Awake()
    {
        inTime = EnemyStats.instance.movementSpeed;
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        patrolTarget = patrolPoints[0];
        rb.velocity = new Vector2(EnemyStats.instance.movementSpeed, rb.velocity.y); // VELOCIDAD DE MOVIMIENTO HORIZONTAL
    }

    void Update()
    {
        // PATRULLAR
        if (!inCombat)
        {
            Patrol();
        }

        // COMPROBAR SI EL JUGADOR ENTRA EN LOS LIMITES DEL PATRULLAJE PARA ATACARLO
        if (Vector2.Distance(transform.position, player.position) < detectionRange)
        {
            // SI ENTRA EN EL RANGO DEL ENEMIGO CAMBIAR OBJETIVO AL JUGADOR
            patrolTarget = player;
            inCombat = true;
        }
        else
        {
            // SI SALE FUERA DEL RANGO CAMBIAR OBJETIVO A PATRULLAR
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            patrolTarget = patrolPoints[currentPatrolIndex];
            inCombat = true;
        }

        // COMPROBAR INVENCIBILIDAD DEL ENEMIGO
        if (iFrames > 0)
        {
            iFrames -= Time.deltaTime;
            if (iFrames <= 0)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            }
        }
        if (EnemyStats.instance.hp <= 0)
        {
            gameObject.SetActive(false); // DESAPARECER AL JUGADOR
                                         // PANTALLA DE FINAL DE JUEGO / VOLVER A JUGAR
        }

        // COMPROBAR SI HAY KNOCKBACK
        if (knockbackCounter <= 0)
        {
            rb.velocity = new Vector2(EnemyStats.instance.movementSpeed, rb.velocity.y); // Velocidad de movimiento horizontal

            // VOLTEAR SPRITE DEPENDINDO DONDE MIRA
            if (rb.velocity.x < 0)
            {
                sr.flipX = true; // VOLTEAR IZQUIERDA
            }
            else if (rb.velocity.x > 0)
            {
                sr.flipX = false; // VOLTEAR DERECHA
            }
        }
        else
        {
            knockbackCounter -= Time.deltaTime;

            if (sr.flipX) // SI MIRA HACIA LA IQUIERDA, EMPUJAR DERECHA
                rb.velocity = new Vector2(knockbackPower, rb.velocity.y);
            else // SI MIRA HACIA LA DERECHA, EMPUJAR IZQUIERDA
                rb.velocity = new Vector2(-knockbackPower, rb.velocity.y);
        }
    }

    // RECIBIR DAÑO DEL JUGADOR
    private void DealPlayerDamage(int damage)
    {
        if (iFrames <= 0)
        {
            EnemyStats.instance.hp -= damage;
            if (EnemyStats.instance.hp > 0)
            {
                iFrames = iFramesCountdown;
                Knockback();
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.7f);
            }
        }
    }

    // HACER DAÑO AL JUGADOR
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            if (cooldown)
            {
                playerHealth.instance.DealMonsterDamage(EnemyStats.instance.dmg);
                Cooldown();
            }
        }
    }

    // TIEMPO DE ESPERA ENTRE ATAQUES
    private void Cooldown()
    {
        EnemyStats.instance.attackSpeed -= Time.deltaTime;
        if (EnemyStats.instance.attackSpeed <= 0 && cooldown)
        {
            cooldown = false;
            EnemyStats.instance.attackSpeed = inTimer;
        }
    }

    // EMPUJAR AL ENEMIGO HACIA ATRAS
    public void Knockback()
    {
        knockbackCounter = knockbackDistance;
        rb.velocity = new Vector2(0f, knockbackPower / 2);
    }

    // PATRULLAJE ENTRE PUNTOS
    private void Patrol()
    {
        // HACER QUE EL ENEMIGO AVANCE HACIA ADELANTE
        transform.position = Vector2.MoveTowards(transform.position, patrolTarget.position, EnemyStats.instance.movementSpeed * Time.deltaTime);

        // CUANDO 
        if (Vector2.Distance(transform.position, patrolTarget.position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            patrolTarget = patrolPoints[currentPatrolIndex];
            Flip();
        }
    }
   
    // REDIRECCIONAR CUANDO LLEGA AL LIMITE DEL PATRULLAJE
    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > player.position.x)
        {
            rotation.y = 0;
        }
        else
        {
            rotation.y = -180;
        }
        transform.eulerAngles = rotation;
    }
}
