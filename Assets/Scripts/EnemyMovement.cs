using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static EnemyMovement instance;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform[] pathPoints;
    [SerializeField] SpriteRenderer sr;
    private float speed = 5;
    private float jumpHeight = 10;
    private float knockbackDistance;
    private float knockbackPower;
    private float knockbackCounter;

    private void Awake()
    {
        instance = this;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player") 
        { 
            if (knockbackCounter <= 0)
            {
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

    public void Knockback()
    {
        knockbackCounter = knockbackDistance;
        rb.velocity = new Vector2(0f, knockbackPower / 2);
    }
}
