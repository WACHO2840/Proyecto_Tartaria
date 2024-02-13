using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float jumpHeight;
    private bool isOnGround;
    public Transform checkGround;
    public LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"),rb.velocity.y); // Velocidad de movimiento horizontal

        isOnGround = Physics2D.OverlapCircle(checkGround.position,.2f,ground); 

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("salto");
           if(isOnGround)
            {
                Debug.Log("salto2");
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight); // Velocidad de movimiento vertical
            }
        }
    }
}
