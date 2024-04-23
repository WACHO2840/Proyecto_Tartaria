using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public float moveSpeed = 2f; // Velocidad de movimiento del enemigo
    public int damageAmount = 10; // Cantidad de daño que inflige el enemigo al jugador

    private bool isDead = false;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead)
        {
            // Movimiento del enemigo (por ejemplo, hacia la izquierda)
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }

    public void LoseLifeAndHit(int damage)
    {
        if (!isDead)
        {
            currentHealth -= damage; // Reducir la vida del enemigo según el daño recibido

            // Verificar si el enemigo aún tiene vida
            if (currentHealth <= 0)
            {
                Die(); // Llamar a la función de muerte del enemigo
            }
        }
    }

    void Die()
    {
        isDead = true;
        // Aquí puedes agregar lógica para reproducir una animación de muerte, sonido, etc.
        animator.SetTrigger("Die"); // Activar la animación de muerte en el Animator

        // Desactivar el collider y el Rigidbody para evitar interacciones
        GetComponent<Collider2D>().enabled = false;
        rb.velocity = Vector2.zero;

        // Después de un cierto tiempo, destruir el objeto enemigo
        Destroy(gameObject, 1.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Si colisiona con el jugador, causar daño al jugador
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);

            // Opcional: Empujar al jugador hacia atrás al recibir daño
            Vector2 pushDirection = (collision.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * 300f);
        }
    }

    internal void LoseLifeAndHit()
    {
        throw new NotImplementedException();
    }
}
