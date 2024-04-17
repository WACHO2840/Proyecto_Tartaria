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

    private bool canDoubleJump = false;  // Controla si el jugador puede hacer doble salto
    private bool hasCrocks = false;      // Controla si el jugador ha recogido los Crocks

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (knockbackCounter <= 0)
        {
            rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);

            isOnGround = Physics2D.OverlapCircle(checkGround.position, .2f, ground);

            if (isOnGround && hasCrocks)
            {
                canDoubleJump = true;  // Solo restablece el doble salto si tiene los Crocks
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (isOnGround || canDoubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                    if (!isOnGround)
                    {
                        canDoubleJump = false; // Usa el doble salto
                    }
                }
            }

            sr.flipX = rb.velocity.x < 0;
        }
        else
        {
            knockbackCounter -= Time.deltaTime;
            rb.velocity = new Vector2(knockbackPower * (sr.flipX ? 1 : -1), rb.velocity.y);
        }
    }

    public void EnableDoubleJump()
    {
        hasCrocks = true;  // Permite el doble salto al recoger los Crocks
        canDoubleJump = true;  // Activa el doble salto inmediatamente
    }

    public void Knockback()
    {
        knockbackCounter = knockbackDistance;
        rb.velocity = new Vector2(0f, knockbackPower / 2);
    }
}
