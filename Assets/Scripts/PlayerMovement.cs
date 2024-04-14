using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform checkGround;
    [SerializeField] LayerMask ground;
    [SerializeField] SpriteRenderer sr;
    private float speed = 10;
    private float jumpHeight = 10;
    private float knockbackDistance;
    private float knockbackPower;
    private float knockbackCounter;
    private bool isOnGround;


    private void Awake()
    {
        instance = this;
    }

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

    public void Knockback()
    {
        knockbackCounter = knockbackDistance;
        rb.velocity = new Vector2(0f, knockbackPower / 2);
    }
}
