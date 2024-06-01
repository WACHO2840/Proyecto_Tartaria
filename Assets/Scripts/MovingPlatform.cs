using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float movementSpeed;
    [SerializeField] bool horizontal;
    private int nextPatrolPoint = 1;
    private bool patrolOrder = true;

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
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[nextPatrolPoint].position, movementSpeed * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, patrolPoints[nextPatrolPoint].position.y), movementSpeed * Time.deltaTime);
    }

    // Detectar cuando el jugador entra en la plataforma
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cambiar el padre del jugador solo si no tiene ya un padre
            if (collision.transform.parent == null)
            {
                collision.transform.SetParent(this.transform);
            }
        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cambiar el padre del jugador solo si el padre actual es esta plataforma
            if (collision.transform.parent == this.transform)
            {
                collision.transform.SetParent(null);
                DontDestroyOnLoad(collision.gameObject); // Aquí establecemos la propiedad DontDestroyOnLoad
            }
        }
    }
}


