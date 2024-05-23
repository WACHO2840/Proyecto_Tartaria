using System.Collections;
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
    private float sceneCooldown = 1f;
    private float sceneTimer = 0f;
    private bool isOnGround;
    private bool nextScene = false; // Evitar múltiples ejecuciones
    private Vector2 levelStart;
    private int[] scenesCheck = new int[5];
    private int stages;
    #endregion

    private void Awake()
    {
        instance = this;
        levelStart = transform.position;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        GenerateScenes();
    }

    // Update is called once per frame
    void Update()
    {
        // Cooldown escenas 
        if (nextScene)
        {
            sceneTimer += Time.deltaTime; // Contar el tiempo en segundos
            if (sceneTimer >= sceneCooldown)
            {
                nextScene = false; // Habilitar cambio de escena
                sceneTimer = 0f; // Restablecer contador
            }
        }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LevelEnd") && !nextScene)
        {
            nextScene = true; // Activar cuenta atras

            if (stages < 5)
            {
                SceneManager.LoadScene(scenesCheck[stages]); // Cambiar a la siguiente escena
                stages++;
            }
            else if (stages == 5)
            {
                SceneManager.LoadScene(16); // Cambiar a la escena del jefe
            }
            this.transform.position = levelStart; // Resetear posicion del jugador a x:0 y:0
        }
    }

    private int[] GenerateScenes()
    {
        for (int i = 0; i < 5; i++)
        {
            int index = UnityEngine.Random.Range(2, 16);
            while (scenesCheck.Contains(index))
            {
                index = UnityEngine.Random.Range(2, 16); // Si ya está, genera otro numero
            }
            scenesCheck[i] = index;
            Debug.Log(index);
        }
        return scenesCheck;
    }
}
