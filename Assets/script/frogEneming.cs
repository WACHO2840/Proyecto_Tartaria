using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class frogEneming : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento
    public float jumpForce = 5f; // Fuerza del salto
    public int normalAttackDamage = 5; // Daño del ataque normal
    public int maxHealth = 10; // Vida máxima del enemigo frog

    private Rigidbody2D rb;
    private bool facingRight = true; // Dirección inicial del enemigo
    private int currentHealth; // Vida actual del enemigo frog
    private bool isGrounded = false; // Variable para controlar si el enemigo está en el suelo
    public Transform groundCheck; // Punto de comprobación para verificar si el enemigo está en el suelo
    public LayerMask groundLayer; // Capa del suelo

    // Inicialización
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; // Inicializa la vida actual al valor máximo

        // Inicia la rutina de movimiento
        InvokeRepeating("MoveForward", 0f, 2f);
    }

    // Método para moverse hacia adelante
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

        // Comprueba si el enemigo está en el suelo para saltar
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // Método para recibir daño
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce la vida actual por el daño recibido

        if (currentHealth <= 0)
        {
            Die(); // Si la vida llega a cero o menos, llama al método Die
        }
    }

    // Método para eliminar al enemigo frog
    void Die()
    {
        Destroy(gameObject); // Destruye el GameObject del enemigo frog
    }

    // Método para el daño por contacto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // El jugador toca al enemigo, aplica daño
            ApplyDamage(normalAttackDamage);
        }
    }

    // Método para aplicar daño al jugador
    private void ApplyDamage(int damage)
    {
        // Aquí puedes implementar la lógica para aplicar el daño al jugador
        Debug.Log("El enemigo hizo " + damage + " puntos de daño al jugador.");
    }
}