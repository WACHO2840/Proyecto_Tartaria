using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    [SerializeField] private float climbSpeed = 4f;
    private float vertical;
    private bool isLadder;
    private bool isClimbing;

    private PlayerMovement playerMovement;
    private Rigidbody2D player;


    private void Start()
    {
        // Obtener GameObject del jugador y rigidbody
        playerMovement = FindObjectOfType<PlayerMovement>();
        player = playerMovement.rb;
    }

    // Update is called once per frame
    void Update()
    {
        // Detectar si esta en la escalera y subir
        vertical = Input.GetAxis("Vertical"); // ALMACENO LA VELOCIDAD DEL EJE Y

        if (isLadder && math.abs(vertical) > 0f) // SI ES MAYOR DE 0 SIGNIFICA QUE SE PRESIONA W
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        // Si escala gravedad a 0 si no restaurarla
        if (isClimbing)
        {
            player.gravityScale = 0f;
            player.velocity = new Vector2(player.velocity.x, vertical * climbSpeed); // AVANZAMOS EN EL EJE Y
        }
        else
        {
            player.gravityScale = 2f;
        }
    }

    // Comprobar si esta en la escalera
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
