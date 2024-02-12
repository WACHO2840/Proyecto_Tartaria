using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float jumpHeight;
    private bool isOnAir;

    // Start is called before the first frame update
    void Start()
    {
        isOnAir = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"),rb.velocity.y); // Velocidad de movimiento horizontal
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2 (rb.velocity.x,jumpHeight); // Velocidad de movimiento vertical
        }
    }
}
