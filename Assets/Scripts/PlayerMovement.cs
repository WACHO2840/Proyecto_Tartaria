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
    private bool isOnGround;

    private bool canDoubleJump = false;
    private bool hasCrocks = false;

    public bool canMove = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0) // Si no estamos en la escena del menú
        {
            if (knockbackCounter <= 0)
            {
                rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);

                isOnGround = Physics2D.OverlapCircle(checkGround.position, .2f, ground);

                if (Input.GetButtonDown("Jump") && isOnGround)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                }

                if (rb.velocity.x < 0)
                {
                    sr.flipX = true;
                }
                else if (rb.velocity.x > 0)
                {
                    sr.flipX = false;
                }
            }
            else
            {
                knockbackCounter -= Time.deltaTime;
            }
        }
    }

    public void EnableDoubleJump()
    {
        hasCrocks = true;
        canDoubleJump = true;
    }

    public void DisableDoubleJump()
    {
        hasCrocks = false;
        canDoubleJump = false;
    }

    public void Knockback(Vector2 direction)
    {
        knockbackCounter = knockbackDistance;
        rb.velocity = new Vector2(direction.x * knockbackPower, knockbackPower / 2);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0) // Si volvemos a la escena del menú
        {
            Destroy(gameObject);
        }
    }
}
