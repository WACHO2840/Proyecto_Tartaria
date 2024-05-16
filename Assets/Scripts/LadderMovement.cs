using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private float climbSpeed = 4f;

    private float vertical;
    private bool isLadder;
    private bool isClimbing;
    private PlayerMovement playerMovement;
    private Rigidbody2D player;
    #endregion

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        player = playerMovement.rb;
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical"); // ALMACENO LA VELOCIDAD DEL EJE Y

        if (isLadder && math.abs(vertical) > 0f) // SI ES MAYOR DE 0 SIGNIFICA QUE SE PRESIONA W
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            player.gravityScale = 0f;
            player.velocity = new Vector2(player.velocity.x, vertical * climbSpeed); // AVANZAMOS EN EL EJE Y
        } else
        {
            player.gravityScale = 2f;
        }
    }

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
