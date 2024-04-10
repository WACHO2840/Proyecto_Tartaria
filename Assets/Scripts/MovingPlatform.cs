using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] puntosMovimiento;
    public float velocidadMovimiento;
    private int siguientePlataforma = 1;
    private bool ordenPlataformas = true;

    // Update is called once per frame
    void Update()
    {
        if (ordenPlataformas && siguientePlataforma + 1 >= puntosMovimiento.Length)
        {
            ordenPlataformas = false;
        }

        if (!ordenPlataformas && siguientePlataforma <= 0)
        {
            ordenPlataformas = true;
        }
    
        if (Vector2.Distance(transform.position, puntosMovimiento[siguientePlataforma].position) < 0.1f)
        {
            if(ordenPlataformas)
            {
                siguientePlataforma += 1;
            }
            else
            {
                siguientePlataforma -= 1;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[siguientePlataforma].position,velocidadMovimiento*Time.deltaTime);
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
