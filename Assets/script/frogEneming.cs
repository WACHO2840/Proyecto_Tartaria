using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug; // Agrega esta l�nea para evitar la ambig�edad

public class frogEneming : MonoBehaviour
{
    private float moveSpeed = 2f; // Velocidad de movimiento
    private float jumpForce = 5f; // Fuerza del salto
    private int normalAttackDamage = 5; // Da�o del ataque normal
    private int maxHealth = 10; // Vida m�xima del enemigo frog

    private bool facingRight = true; // Direcci�n inicial del enemigo
    private int currentHealth; // Vida actual del enemigo frog
    private bool isGrounded = false; // Variable para controlar si el enemigo est� en el suelo
    private Transform groundCheck; // Punto de comprobaci�n para verificar si el enemigo est� en el suelo
    private LayerMask groundLayer; // Capa del suelo

    // Inicializaci�n
    void Start()
    {
        currentHealth = maxHealth; // Inicializa la vida actual al valor m�ximo

        // Inicia la rutina de movimiento
        InvokeRepeating("MoveForward", 0f, 2f);
    }

    // M�todo para moverse hacia adelante
    void MoveForward()
    {
        Vector2 movement = new Vector2(moveSpeed * (facingRight ? 1 : -1), 0);
        transform.Translate(movement * Time.deltaTime);

        // Comprueba si el enemigo est� en el suelo para saltar
        if (isGrounded)
        {
            Jump();
        }
    }

    // M�todo para el salto del enemigo
    void Jump()
    {
        isGrounded = false;
        Vector2 jumpVelocity = new Vector2(0, jumpForce);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = jumpVelocity;
    }

    // M�todo para recibir da�o
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce la vida actual por el da�o recibido

        if (currentHealth <= 0)
        {
            Die(); // Si la vida llega a cero o menos, llama al m�todo Die
        }
    }

    // M�todo para eliminar al enemigo frog
    void Die()
    {
        Destroy(gameObject); // Destruye el GameObject del enemigo frog
    }

    // M�todo para el da�o por contacto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // El jugador toca al enemigo, aplica da�o
            ApplyDamage(normalAttackDamage);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            // El enemigo est� en el suelo
            isGrounded = true;
        }
    }

    // M�todo para aplicar da�o al jugador
    private void ApplyDamage(int damage)
    {
        // Aqu� puedes implementar la l�gica para aplicar el da�o al jugador
        Debug.Log("El enemigo hizo " + damage + " puntos de da�o al jugador.");
    }
}