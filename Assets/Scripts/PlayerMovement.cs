using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private float knockbackDistance = .5f;
    private float knockbackPower = 10f;
    private float knockbackCounter;
    private float sceneCooldown = 1f;
    private float sceneTimer = 0f;
    private bool isOnGround;
    private bool nextScene = false; // Evitar múltiples ejecuciones
    int[] scenesCheck = new int[5];
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

    public void Knockback(Vector2 direction)
    {
        knockbackCounter = knockbackDistance;
        rb.velocity = new Vector2(direction.x * knockbackPower, knockbackPower / 2);
    }

    //PASAR DE NIVEL 
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            Knockback(knockbackDirection);
        }
    }

    // GENERAR NIVELES
    private int[] GenerateScenes()
    {
        for (int i = 0; i < 5; i++)
        {
            int index = UnityEngine.Random.Range(2, 16); // Limites de escenas
            while (scenesCheck.Contains(index))
            {
                index = UnityEngine.Random.Range(2, 16); // Si ya está, genera otro número
            }
            scenesCheck[i] = index; // Guardar el valor
        }
        return scenesCheck;
    }
}
