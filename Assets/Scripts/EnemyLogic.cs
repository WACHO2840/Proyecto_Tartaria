using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyLogic : MonoBehaviour
{
    public static EnemyLogic Instance;

    #region Variables
    [SerializeField] Transform[] patrolPoints; // Puntos de patrullaje
    [SerializeField] Rigidbody2D rb; // RB Enemigo
    [SerializeField] Transform player; // GO jugador
    [SerializeField] SpriteRenderer sr; // SR Enemigo


    private float detectionRange = 9f;
    private int nextPatrolPoint = 0;
    private bool patrolOrder = true; // 

    private bool attacking; // Comprobar si esta persiguiendo al jugador

    #endregion

    private void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        if (!attacking)
        {
            Patrol();
        }

        AttackPlayer();

        if (rb.velocity.x < 0)
        {
            sr.flipX = true; //Izquierda
        }
        else if (rb.velocity.x > 0)
        {
            sr.flipX = false; //Derecha
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
        // Verificar si el componente EnemyStats est� adjunto al enemigo
        if (enemyStats != null)
        {
            // Cambiar la direcci�n de la patrulla si se alcanza el final del array
            if (patrolOrder && nextPatrolPoint + 1 >= patrolPoints.Length)
            {
                patrolOrder = false;
            }
            // Cambiar la direcci�n de la patrulla si se alcanza el principio del array
            else if (!patrolOrder && nextPatrolPoint <= 0)
            {
                patrolOrder = true;
            }

            // Dependiendo de la direcci�n de la patrulla, cambiar el pr�ximo punto de patrulla
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
            // Mover al enemigo hacia el siguiente punto de patrulla
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[nextPatrolPoint].position, enemyStats.movementSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("El enemigo no tiene el script EnemyStats adjunto.");
        }
    }

    private void AttackPlayer()
    {
        EnemyStats enemyStats = GetComponent<EnemyStats>();

        if (enemyStats != null) {
            if (player != null)
            {
                // Calcula la distancia entre el enemigo y el jugador
                float playerDistance = Vector2.Distance(transform.position, player.position);

                // Si la distancia es menor que la distancia de persecuci�n, comienza a perseguir al jugador
                if (playerDistance <= detectionRange)
                {
                    // Direcci�n hacia la que se mover� el enemigo
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
}


   
