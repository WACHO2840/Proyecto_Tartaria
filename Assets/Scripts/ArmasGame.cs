// 1° version
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ArmasGame : MonoBehaviour
// {
//     public int damage = 10;  // Cantidad de daño que hace la katana
//     public Transform gfx;  // Referencia al transform del gráfico de la katana
//     public float maxCooldownTime = 1.0f;  // Tiempo de cooldown para la animación

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         // Verifica si el objeto que colisiona tiene la etiqueta "enemigos"
//         if (other.CompareTag("Enemy"))
//         {
//             // Intenta obtener el componente de salud del enemigo
//             EnemyLogic EnemyLogic = other.GetComponent<EnemyLogic>();
//             if (EnemyLogic != null)
//             {
//                 // Aplicar daño al enemigo
//                 // EnemyLogic.TakeDamage(damage);
//             }
//         }
//     }

//     public void StartAttack()
//     {
//         StartCoroutine(Animate());
//     }

//     IEnumerator Animate()
//     {
//         // Rotar la katana para la animación de ataque
//         gfx.localRotation = Quaternion.Euler(0, 0, -70);

//         // Esperar por un tiempo antes de revertir la rotación
//         yield return new WaitForSeconds(maxCooldownTime * 0.9f);

//         // Revertir la rotación de la katana
//         gfx.localRotation = Quaternion.Euler(0, 0, 0);
//     }
// }


// V2 funciona
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ArmasGame : MonoBehaviour
// {
//     public int damage = 10;  // Cantidad de daño que hace la katana
//     public Transform gfx;  // Referencia al transform del gráfico de la katana
//     public float maxCooldownTime = 1.0f;  // Tiempo de cooldown para la animación

//     private bool isAttacking = false;

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         // Verifica si el objeto que colisiona tiene la etiqueta "Enemy"
//         if (other.CompareTag("Enemy") && !isAttacking)
//         {
//             // Inicia la animación de ataque
//             StartAttack();

//             // Intenta obtener el componente de lógica del enemigo
//             EnemyStats EnemyStats = other.GetComponent<EnemyStats>();
//             if (EnemyStats != null)
//             {
//                 // Aplicar daño al enemigo
//                 // EnemyStats.GetDamage(damage);
//                 Debug.Log("daño");
//             }
//         }
//     }

//     public void StartAttack()
//     {
//         StartCoroutine(Animate());
//     }

//     IEnumerator Animate()
//     {
//         isAttacking = true;

//         // Rotar la katana para la animación de ataque
//         gfx.localRotation = Quaternion.Euler(0, 0, -70);

//         // Esperar por un tiempo antes de revertir la rotación
//         yield return new WaitForSeconds(maxCooldownTime * 0.9f);

//         // Revertir la rotación de la katana
//         gfx.localRotation = Quaternion.Euler(0, 0, 0);

//         // Esperar el resto del tiempo de cooldown
//         yield return new WaitForSeconds(maxCooldownTime * 0.1f);

//         isAttacking = false;
//     }
// }


// V3 pruebas
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ArmasGame : MonoBehaviour
// {
//     public int damage = 10;  // Cantidad de daño que hace la katana
//     public Transform gfx;  // Referencia al transform del gráfico de la katana
//     public Transform hitSpot; // Punto de impacto de la katana
//     public float range = 1.0f;  // Alcance del ataque de la katana
//     public float maxCooldownTime = 1.0f;  // Tiempo de cooldown para la animación
//     // public Transform player;  // Referencia al transform del jugador

//     private bool isAttacking = false;
//     private bool isEquipped = false;  // Indica si la katana está equipada

//     void Start()
//     {
//         // Verifica si el objeto tiene el tag "katana" y está equipado por el jugador
//         if (gameObject.CompareTag("katana"))
//         {
//             isEquipped = true;
//         }
//     }

//     void Update()
//     {
//         // Detectar la entrada "Fire1" (por defecto, clic izquierdo) y realizar la animación de ataque si está equipada
//         if (Input.GetButtonDown("Fire1") && isEquipped && !isAttacking)
//         {
//             OnActivate();
//         }

//         // Asegurar que la katana rota con el jugador
//         // if (player != null)
//         // {
//         //     FollowPlayerRotation();
//         // }
//     }

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         // Este método se deja en blanco ya que la detección de impacto se realiza en OnActivate
//     }

//     private void OnActivate()
//     {
//         StartCoroutine(Animate());

//         Collider2D[] targets = Physics2D.OverlapCircleAll(hitSpot.position, range);

//         foreach (var target in targets)
//         {
//             if (target.CompareTag("Enemy"))
//             {
//                 EnemyStats enemyStats = target.GetComponent<EnemyStats>();
//                 if (enemyStats != null)
//                 {
//                     // enemyStats.TakeDamage(damage);
//                     Debug.Log("Daño aplicado al enemigo.");
//                 }
//             }
//         }
//     }

//     IEnumerator Animate()
//     {
//         isAttacking = true;

//         // Rotar la katana para la animación de ataque
//         gfx.localRotation = Quaternion.Euler(0, 0, -70);

//         // Esperar por un tiempo antes de revertir la rotación
//         yield return new WaitForSeconds(maxCooldownTime * 0.9f);

//         // Revertir la rotación de la katana
//         gfx.localRotation = Quaternion.Euler(0, 0, 0);

//         // Esperar el resto del tiempo de cooldown
//         yield return new WaitForSeconds(maxCooldownTime * 0.1f);

//         isAttacking = false;
//     }

//     // private void FollowPlayerRotation()
//     // {
//     //     // Asegurar que la katana siga la rotación del jugador
//     //     transform.rotation = player.rotation;
//     // }

//     private void OnDrawGizmos()
//     {
//         // Dibujar el alcance del ataque en el editor para visualización
//         if (hitSpot != null)
//         {
//             Gizmos.color = Color.red;
//             Gizmos.DrawWireSphere(hitSpot.position, range);
//         }
//     }
// }

// V4
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasGame : MonoBehaviour
{
    public int damage = 10;  // Cantidad de daño que hace la katana
    public Transform gfx;  // Referencia al transform del gráfico de la katana
    public Transform hitSpot; // Punto de impacto de la katana
    public float range = 1.0f;  // Alcance del ataque de la katana
    public float maxCooldownTime = 1.0f;  // Tiempo de cooldown para la animación

    private bool isAttacking = false;
    private bool isEquipped = false;  // Indica si la katana está equipada

    void Start()
    {
        // Verifica si el objeto tiene el tag "katana" y está equipado por el jugador
        if (gameObject.CompareTag("katana"))
        {
            isEquipped = true;
        }
    }

    void Update()
    {
        // Detectar la entrada "Fire1" (por defecto, clic izquierdo) y realizar la animación de ataque si está equipada
        if (Input.GetButtonDown("Fire1") && isEquipped && !isAttacking)
        {
            OnActivate();
        }
    }

    private void OnActivate()
    {
        Debug.Log("Activando ataque");
        StartCoroutine(Animate());

        Collider2D[] targets = Physics2D.OverlapCircleAll(hitSpot.position, range);

        foreach (var target in targets)
        {
            if (target.CompareTag("Enemy"))
            {
                EnemyStats enemyStats = target.GetComponent<EnemyStats>();
                if (enemyStats != null)
                {
                    // enemyStats.TakeDamage(damage);
                    Debug.Log("Daño aplicado al enemigo.");
                }
            }
        }
    }

    IEnumerator Animate()
    {
        isAttacking = true;
        Debug.Log("Comenzando animación de ataque");

        // Rotar la katana para la animación de ataque
        gfx.localRotation = Quaternion.Euler(0, 0, -70);
        Debug.Log("Katana rotada a -70 grados");

        // Esperar por un tiempo antes de revertir la rotación
        yield return new WaitForSeconds(maxCooldownTime * 0.9f);

        // Revertir la rotación de la katana
        gfx.localRotation = Quaternion.Euler(0, 0, 0);
        Debug.Log("Katana revertida a 0 grados");

        // Esperar el resto del tiempo de cooldown
        yield return new WaitForSeconds(maxCooldownTime * 0.1f);

        isAttacking = false;
        Debug.Log("Animación de ataque terminada");
    }

    private void OnDrawGizmos()
    {
        // Dibujar el alcance del ataque en el editor para visualización
        if (hitSpot != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(hitSpot.position, range);
        }
    }
}
