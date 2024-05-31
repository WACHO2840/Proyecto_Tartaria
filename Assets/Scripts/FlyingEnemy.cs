using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{

    public static FlyingEnemy Instance;
    private EnemyStats enemyStats;

    #region Variables
    [SerializeField] Transform[] patrolPoints; // Puntos de patrullaje
    [SerializeField] Transform player; // GO jugador
    [SerializeField] SpriteRenderer sr; // SR Enemigo
    [SerializeField] bool horizontal; // Hacia donde se mueve
    private Vector2 velocidadEnemigo;
    private PlayerMovement playerMovement;

    [SerializeField] private float detectionRange = 5f;
    private int nextPatrolPoint = 0;
    private bool patrolOrder = true; //

    private bool attacking; // Comprobar si esta persiguiendo al jugador

    #endregion

    private void Awake()
    {
        Instance = this;
        enemyStats = GetComponent<EnemyStats>();
        if (enemyStats == null)
        {
            Debug.LogError("EnemyStats no está adjunto al GameObject.");
        }
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        player = playerMovement.transform;
    }

    void Update()
    {
        AttackPlayer();
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
                PlayerHealth.instance.DealMonsterDamage(enemyStats.dmg, transform.position);
            }
            else
            {
                Debug.LogWarning("El enemigo no tiene el script EnemyStats asociado");
            }
        }
    }

    private void Patrol()
    {
        EnemyStats enemyStats = GetComponent<EnemyStats>();

        // Verificar si el componente EnemyStats está adjunto al enemigo
        if (enemyStats != null && patrolPoints.Length > 0)
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
                        nextPatrolPoint++;
                    }
                    else
                    {
                        nextPatrolPoint--;
                    }
                }
            }
            else
            {
                if (Vector2.Distance(patrolPoints[nextPatrolPoint].position, transform.position) < 0.1f)
                {
                    if (patrolOrder)
                    {
                        nextPatrolPoint++;
                    }
                    else
                    {
                        nextPatrolPoint--;
                    }
                }
            }

            // Asegurarse de que nextPatrolPoint esté dentro de los límites del array
            nextPatrolPoint = Mathf.Clamp(nextPatrolPoint, 0, patrolPoints.Length - 1);

            // Mover el enemigo hacia el punto de patrulla
            if (horizontal)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[nextPatrolPoint].position, enemyStats.movementSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, patrolPoints[nextPatrolPoint].position.y), enemyStats.movementSpeed * Time.deltaTime);
            }
        }
        else
        {
            Debug.LogWarning("El enemigo no tiene el script EnemyStats adjunto o no hay puntos de patrullaje definidos.");
        }
    }


    private void AttackPlayer()
    {
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

    public void GetDamage(float damage)
    {
        if (enemyStats != null)
        {
            enemyStats.ReduceHp(damage);
        }
    }
}