using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug; // Agrega esta línea para evitar la ambigüedad

public class frogEneming : MonoBehaviour
{
    private float moveSpeed = 2f; // Velocidad de movimiento
    private float jumpForce = 5f; // Fuerza del salto
    private int normalAttackDamage = 5; // Daño del ataque normal
    private int maxHealth = 10; // Vida máxima del enemigo frog

    private bool facingRight = true; // Dirección inicial del enemigo
    private int currentHealth; // Vida actual del enemigo frog
    private bool isGrounded = false; // Variable para controlar si el enemigo está en el suelo
    private Transform groundCheck; // Punto de comprobación para verificar si el enemigo está en el suelo
    private LayerMask groundLayer; // Capa del suelo

    // Inicialización
    void Start()
    {
        currentHealth = maxHealth; // Inicializa la vida actual al valor máximo

        // Inicia la rutina de movimiento
        InvokeRepeating("MoveForward", 0f, 2f);
    }

    // Método para moverse hacia adelante
    void MoveForward()
    {
        Vector2 movement = new Vector2(moveSpeed * (facingRight ? 1 : -1), 0);
        transform.Translate(movement * Time.deltaTime);

        // Comprueba si el enemigo está en el suelo para saltar
        if (isGrounded)
        {
            Jump();
        }
    }

    // Método para el salto del enemigo
    void Jump()
    {
        isGrounded = false;
        Vector2 jumpVelocity = new Vector2(0, jumpForce);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = jumpVelocity;
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
        else if (collision.gameObject.CompareTag("Ground"))
        {
            // El enemigo está en el suelo
            isGrounded = true;
        }
    }

    // Método para aplicar daño al jugador
    private void ApplyDamage(int damage)
    {
        // Aquí puedes implementar la lógica para aplicar el daño al jugador
        Debug.Log("El enemigo hizo " + damage + " puntos de daño al jugador.");
    }
}