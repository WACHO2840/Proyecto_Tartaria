using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class frogEneming : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento
    public float jumpForce = 5f; // Fuerza del salto
    public int normalAttackDamage = 5; // Da�o del ataque normal
    public int maxHealth = 10; // Vida m�xima del enemigo frog

    private Rigidbody2D rb;
    private bool facingRight = true; // Direcci�n inicial del enemigo
    private int currentHealth; // Vida actual del enemigo frog
    private bool isGrounded = false; // Variable para controlar si el enemigo est� en el suelo
    public Transform groundCheck; // Punto de comprobaci�n para verificar si el enemigo est� en el suelo
    public LayerMask groundLayer; // Capa del suelo

    // Inicializaci�n
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; // Inicializa la vida actual al valor m�ximo

        // Inicia la rutina de movimiento
        InvokeRepeating("MoveForward", 0f, 2f);
    }

    // M�todo para moverse hacia adelante
    void MoveForward()
    {
        if (facingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        // Comprueba si el enemigo est� en el suelo para saltar
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
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
    }

    // M�todo para aplicar da�o al jugador
    private void ApplyDamage(int damage)
    {
        // Aqu� puedes implementar la l�gica para aplicar el da�o al jugador
        Debug.Log("El enemigo hizo " + damage + " puntos de da�o al jugador.");
    }
}