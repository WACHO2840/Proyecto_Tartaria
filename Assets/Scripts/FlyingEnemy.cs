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
    [SerializeField] SpriteRenderer sr; // SR Enemigo
    [SerializeField] bool horizontal; // Hacia donde se mueve
    private int nextPatrolPoint = 1;
    private bool patrolOrder = true; //


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
    }

    void Update()
    {
        if (patrolOrder && nextPatrolPoint + 1 >= patrolPoints.Length)
        {
            patrolOrder = false;
        }

        if (!patrolOrder && nextPatrolPoint <= 0)
        {
            patrolOrder = true;
        }

        if (horizontal)
        {
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
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[nextPatrolPoint].position, enemyStats.GetMovementSpeed() * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, patrolPoints[nextPatrolPoint].position.y), enemyStats.GetMovementSpeed() * Time.deltaTime);
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

}
