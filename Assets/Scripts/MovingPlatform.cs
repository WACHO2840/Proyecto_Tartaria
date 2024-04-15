using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float movementSpeed;
    [SerializeField] bool horizontal; // PARA COMPROBAR SI LA PLATAFORMA SUBE Y BAJA O SE DESPLAZA HORIZONTALMENTE
    private int nextPatrolPoint = 1;
    private bool patrolOrder = true; // ESTO SOLO SIRVE EN CASO DE QUE SEAN 2 PUNTOS

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
        else // SI ES FALSO SE MUEVE EN EL EJE Y
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


    // CUANDO EL JUGADOR ENTRE EN LA PLATAFORMA PONERLO DE HIJO
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }

    }

    // CUANDO EL JUGADOR DEJE LA PLATAFORMA QUITARLO DE HIJO
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }

    }
}
