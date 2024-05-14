using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public static EnemyLogic Instance;

    #region Variables
    [SerializeField] Transform[] patrolPoints; // Puntos de patrullaje
    private PlayerMovement playerMovement;
    private Rigidbody2D rb; // RB Enemigo
    private Transform player; // GO jugador
    [SerializeField] SpriteRenderer sr; // SR Enemigo
    [SerializeField] bool horizontal; // Hacia donde se mueve
    private Vector2 velocidadEnemigo;


    private float detectionRange = 9f;
    private int nextPatrolPoint = 0;
    private bool patrolOrder = true;

    private bool attacking; // Comprobar si esta persiguiendo al jugador

    #endregion

    private void Awake()
    {
        Instance = this;
        rb = playerMovement.rb;
        player = playerMovement.transform;
    }

    void Start()
    {

    }

    void Update()
    {
        velocidadEnemigo = rb.velocity; // BORRAR, SIRVE PARA PRUEBAS

        AttackPlayer();

        Flip();
    }
    private void FixedUpdate()
    {
        if (!attacking)
        {
            Patrol();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // INSTANCIAMOS EL ENEMIGO CON EL QUE COLISIONO
            EnemyStats enemyStats = GetComponent<EnemyStats>();

            // COMPROBAMOS QUE TENGA ENLAZADO EL SCRIPT
            if (enemyStats != null)
            {
                PlayerHealth.instance.DealMonsterDamage(enemyStats.dmg);
            }
            else
            {
                Debug.LogWarning("El enemigo no tiene el script EnemyStats.");
            }
        }
    }

    private void Patrol()
    {
        EnemyStats enemyStats = GetComponent<EnemyStats>();
        // Verificar si el componente EnemyStats está adjunto al enemigo
        if (enemyStats != null)
        {
            if (horizontal)
            {
                // Cambiar la dirección de la patrulla si se alcanza el final del array
                if (patrolOrder && nextPatrolPoint + 1 >= patrolPoints.Length)
                {
                    patrolOrder = false;
                }
                // Cambiar la dirección de la patrulla si se alcanza el principio del array
                else if (!patrolOrder && nextPatrolPoint <= 0)
                {
                    patrolOrder = true;
                }   

                // Dependiendo de la dirección de la patrulla, cambiar el próximo punto de patrulla
                if (Vector2.Distance(transform.position, patrolPoints[nextPatrolPoint].position) < 0.1f)
                {
                    if (patrolOrder)
                    {
                        nextPatrolPoint += 1;
                    }
                    else
                    {
                        nextPatrolPoint -= 1;
                    }
                }
            }
            else
            {
                if (Vector2.Distance(patrolPoints[nextPatrolPoint].position, transform.position) < 0.1f)
                {
                    if (patrolOrder)
                    {
                        nextPatrolPoint += 1;
                    }
                    else
                    {
                        nextPatrolPoint -= 1;
                    }
                }
            }
            if (horizontal)
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[nextPatrolPoint].position, enemyStats.movementSpeed * Time.deltaTime);
            else
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, patrolPoints[nextPatrolPoint].position.y), enemyStats.movementSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("El enemigo no tiene el script EnemyStats adjunto.");
        }
    }

    private void AttackPlayer()
    {
        EnemyStats enemyStats = GetComponent<EnemyStats>();

        if (enemyStats != null)
        {
            if (player != null)
            {
                // Calcula la distancia entre el enemigo y el jugador
                float playerDistance = Vector2.Distance(transform.position, player.position);

                // Si la distancia es menor que la distancia de persecución, comienza a perseguir al jugador
                if (playerDistance <= detectionRange)
                {
                    // Dirección hacia la que se moverá el enemigo
                    Vector2 direccion = (player.position - transform.position).normalized;

                    // Mueve al enemigo hacia el jugador
                    transform.position = Vector2.MoveTowards(transform.position, player.position, enemyStats.movementSpeed * Time.deltaTime);

                    attacking = true;
                }
                else
                {
                    attacking = false;
                }
            }
        }
    }

    private void Flip()
    {
        if(transform.position.x < patrolPoints[nextPatrolPoint].position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
