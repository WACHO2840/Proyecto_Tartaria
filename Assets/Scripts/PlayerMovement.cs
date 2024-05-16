using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] Transform checkGround;
    [SerializeField] LayerMask ground;
    [SerializeField] SpriteRenderer sr;
    private float speed = 10;
    private float jumpHeight = 10;
    private float knockbackDistance;
    private float knockbackPower;
    private float knockbackCounter;
    private bool isOnGround;
    int[] stagesCheck = new int[5];
    private Vector2 levelStart;

    private int stages;

    private void Awake()
    {
        stages = 0;
        instance = this;
        levelStart = transform.position;
        GenerateScenes();
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

    //PASAR DE NIVEL ALEATORIO

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("LevelEnd"))
        {
            if (stages < 5)
            {
                SceneManager.LoadScene(stagesCheck[stages]); // Cambiar a la siguiente sala
                //Debug.Log(stagesCheck[stages]);
                //Debug.Log(stages);
                stages++;
            } 
            else if (stages == 5)
            {
                SceneManager.LoadScene(16); // Cambiar a la sala del jefe
                //Debug.Log("jefe");
            }
            this.transform.position = levelStart;
        }
    }

    private int[] GenerateScenes()
    {
        for (int i = 0; i < 5; i++)
        {
            int index = UnityEngine.Random.Range(3, 16);
            while (stagesCheck.Contains(index))
            {
                index = UnityEngine.Random.Range(3, 16); // Si ya está, genera otro índice
            }
            stagesCheck[i] = index;
            Debug.Log(index);
        }
        return stagesCheck;
    }
}
