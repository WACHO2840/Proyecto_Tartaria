/*
   
    // Update is called once per frame
    void Update()
    {


        if (knockbackCounter <= 0)
        {
            rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y); // Velocidad de movimiento horizontal

            isOnGround = Physics2D.OverlapCircle(checkGround.position, .2f, ground);

            if (Input.GetButtonDown("Jump"))
            {
                if (isOnGround)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpHeight); // Velocidad de movimiento vertical
                }
            }

            if (rb.velocity.x < 0)
            {
                sr.flipX = true; //Izquierda
            }
            else if (rb.velocity.x > 0)
            {
                sr.flipX = false; //Derecha
            }
        }
        else
        {
            knockbackCounter -= Time.deltaTime;

            if (sr.flipX)
                rb.velocity = new Vector2(knockbackPower, rb.velocity.y);
            else
                rb.velocity = new Vector2(-knockbackPower, rb.velocity.y);
        }
    }

    

}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] Transform checkGround;
    [SerializeField] LayerMask ground;
    [SerializeField] SpriteRenderer sr;
    private float speed = 10;
    private float jumpHeight = 10;
    private float knockbackDistance = .5f;
    private float knockbackPower = 10f;
    private float knockbackCounter;
    private bool isOnGround;

    private bool canDoubleJump = false;  // Controla si el jugador puede hacer doble salto
    private bool hasCrocks = false;     // Controla si el jugador ha recogido los Crocks

    public bool canMove = true; // Variable para controlar si el jugador puede moverse

    private void Awake()
    {
        instance = this;
    }
 
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (knockbackCounter <= 0)
        {
            rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y); // Velocidad de movimiento horizontal

            isOnGround = Physics2D.OverlapCircle(checkGround.position, .2f, ground);

            if (Input.GetButtonDown("Jump") && isOnGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight); // Velocidad de movimiento vertical
            }

            if (rb.velocity.x < 0)
            {
                sr.flipX = true; //Izquierda
            }
            else if (rb.velocity.x > 0)
            {
                sr.flipX = false; //Derecha
            }
        }
        else
        {
            knockbackCounter -= Time.deltaTime;
        }
    }

    public void EnableDoubleJump()
    {
        hasCrocks = true;  // Permite el doble salto al recoger los Crocks
        canDoubleJump = true;  // Activa el doble salto inmediatamente
    }

    public void DisableDoubleJump()
    {
        hasCrocks = false;  // Permite el doble salto al recoger los Crocks
        canDoubleJump = false;  // Activa el doble salto inmediatamente
    }

    public void Knockback(Vector2 direction)
    {
        knockbackCounter = knockbackDistance;
        rb.velocity = new Vector2(direction.x * knockbackPower, knockbackPower / 2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            Knockback(knockbackDirection);
        }
    }

}
