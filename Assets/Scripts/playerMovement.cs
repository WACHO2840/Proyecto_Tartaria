using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public static playerMovement instance;

    public float speed;
    public Rigidbody2D rb;
    public float jumpHeight;
    private bool isOnGround;
    public Transform checkGround;
    public LayerMask ground;

    public SpriteRenderer sr;

    public float knockbackDistance;
    public float knockbackPower;
    private float knockbackCounter;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knockbackCounter <= 0) { 
            rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"),rb.velocity.y); // Velocidad de movimiento horizontal

            isOnGround = Physics2D.OverlapCircle(checkGround.position,.2f,ground); 

            if (Input.GetButtonDown("Jump"))
            {
               if(isOnGround)
                {
                    Debug.Log("salto");
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
        } else
        {
            knockbackCounter -= Time.deltaTime;
            
            if(sr.flipX)
                rb.velocity = new Vector2(knockbackPower, rb.velocity.y);
            else
                rb.velocity = new Vector2(-knockbackPower, rb.velocity.y);
        }
    }

    public void Knockback()
    {
        knockbackCounter = knockbackDistance;
        rb.velocity = new Vector2(0f, knockbackPower/2);
    }
}
