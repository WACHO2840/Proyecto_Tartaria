/*using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES
    public static PlayerMovement instance;

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform checkGround;
    [SerializeField] private LayerMask ground;
    private SpriteRenderer sr;

    private float speed = 10;
    private float jumpHeight = 10;
    private float knockbackDistance;
    private float knockbackPower;
    private float knockbackCounter;
    
    private bool isOnGround;

    #endregion

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
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
*/

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
    private bool hasCrocks = false;     // Controla si el jugador ha recogido los Crocks

    public bool canMove = true; // Variable para controlar si el jugador puede moverse

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (canMove)
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
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // Detener el movimiento horizontal
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

    public void Knockback()
    {
        knockbackCounter = knockbackDistance;
        rb.velocity = new Vector2(0f, knockbackPower / 2);
    }
}
