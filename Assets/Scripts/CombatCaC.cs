// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CombatCaC : MonoBehaviour
// {
//     [SerializeField] private Transform HitContoler; // Aseg�rate de asignar este valor en el inspector
//     private PlayerAttack playerAttack;

//     private bool canHit = true;
//     private float hitCooldown;
//     private float lastHitTime;

//     void Start()
//     {
//         playerAttack = GetComponent<PlayerAttack>();
//         if (playerAttack == null)
//         {
//             Debug.LogError("PlayerAttack no est� adjunto al GameObject.");
//         }
//     }

//     void Update()
//     {
//         hitCooldown = 1 / playerAttack.BasicAttackSpeed; // Ajusta el cooldown basado en la velocidad de ataque

//         // Detectar la tecla F
//         if (Input.GetKeyDown(KeyCode.F) && canHit)
//         {
//             Hit();
//             canHit = false;
//             lastHitTime = Time.time;
//         }

//         // Resetear la capacidad de atacar despu�s del cooldown
//         if (Time.time - lastHitTime >= hitCooldown)
//         {
//             canHit = true;
//         }
//     }

//     private void Hit()
//     {
//         float hitRadius = playerAttack.Range; // Obtener el rango del ataque del jugador
//         Collider2D[] objects = Physics2D.OverlapCircleAll(HitContoler.position, hitRadius);

//         foreach (Collider2D colisionador in objects)
//         {
//             if (colisionador.CompareTag("Enemy"))
//             {
//                 EnemyLogic enemyLogic = colisionador.transform.GetComponent<EnemyLogic>();
//                 if (enemyLogic != null)
//                 {
//                     enemyLogic.GetDamage(playerAttack.BasicDamage);
//                 }
//                 else
//                 {
//                     Debug.LogWarning("El enemigo no tiene el script EnemyLogic adjunto.");
//                 }
//             }
//         }
//     }

//     private void OnDrawGizmos()
//     {
//         if (HitContoler != null)
//         {
//             float hitRadius = playerAttack != null ? playerAttack.Range : 0.5f; // Obtener el rango del ataque del jugador
//             Gizmos.color = Color.yellow;
//             Gizmos.DrawWireSphere(HitContoler.position, hitRadius);
//         }
//     }
// }

// codigo ANDRES
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CombatCaC : MonoBehaviour
// {
//     [SerializeField] private Transform HitContoler; // Asegúrate de asignar este valor en el inspector
//     [SerializeField] private Transform gfx; // Asegúrate de asignar este valor en el inspector
//     private PlayerAttack playerAttack;

//     private bool canHit = true;
//     private float hitCooldown;
//     private float lastHitTime;

//     void Start()
//     {
//         playerAttack = GetComponent<PlayerAttack>();
//         if (playerAttack == null)
//         {
//             Debug.LogError("PlayerAttack no está adjunto al GameObject.");
//         }
//     }

//     void Update()
//     {
//         hitCooldown = 1 / playerAttack.BasicAttackSpeed; // Ajusta el cooldown basado en la velocidad de ataque

//         // Detectar la tecla F
//         if (Input.GetKeyDown(KeyCode.F) && canHit)
//         {
//             Hit();
//             canHit = false;
//             lastHitTime = Time.time;
//         }

//         // Resetear la capacidad de atacar después del cooldown
//         if (Time.time - lastHitTime >= hitCooldown)
//         {
//             canHit = true;
//         }
//     }

//     private void Hit()
//     {
//         StartCoroutine(Animate()); // Iniciar la animación de ataque

//         float hitRadius = playerAttack.Range; // Obtener el rango del ataque del jugador
//         Collider2D[] objects = Physics2D.OverlapCircleAll(HitContoler.position, hitRadius);

//         foreach (Collider2D colisionador in objects)
//         {
//             if (colisionador.CompareTag("Enemy"))
//             {
//                 EnemyLogic enemyLogic = colisionador.transform.GetComponent<EnemyLogic>();
//                 if (enemyLogic != null)
//                 {
//                     enemyLogic.GetDamage(playerAttack.BasicDamage);
//                 }
//                 else
//                 {
//                     Debug.LogWarning("El enemigo no tiene el script EnemyLogic adjunto.");
//                 }
//             }
//         }
//     }

//     private IEnumerator Animate()
//     {
//         if (gfx != null)
//         {
//             gfx.localRotation = Quaternion.Euler(0, 0, -70);

//             yield return new WaitForSeconds(playerAttack.BasicAttackSpeed * 0.9f);

//             gfx.localRotation = Quaternion.Euler(0, 0, 0);
//         }
//     }

//     private void OnDrawGizmos()
//     {
//         if (HitContoler != null)
//         {
//             float hitRadius = playerAttack != null ? playerAttack.Range : 0.5f; // Obtener el rango del ataque del jugador
//             Gizmos.color = Color.yellow;
//             Gizmos.DrawWireSphere(HitContoler.position, hitRadius);
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCaC : MonoBehaviour
{
    [SerializeField] private Transform HitContoler; // Asegúrate de asignar este valor en el inspector
    [SerializeField] private Transform gfx; // Asegúrate de asignar este valor en el inspector
    private PlayerAttack playerAttack;

    private bool canHit = true;
    private float hitCooldown;
    private float lastHitTime;

    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        if (playerAttack == null)
        {
            Debug.LogError("PlayerAttack no está adjunto al GameObject.");
        }
    }

    void Update()
    {
        if (playerAttack == null)
        {
            return; // Si playerAttack no está asignado, salir de Update para evitar errores.
        }

        hitCooldown = 1 / playerAttack.BasicAttackSpeed; // Ajusta el cooldown basado en la velocidad de ataque

        // Detectar la tecla F
        if (Input.GetKeyDown(KeyCode.F) && canHit)
        {
            Hit();
            canHit = false;
            lastHitTime = Time.time;
        }

        // Resetear la capacidad de atacar después del cooldown
        if (Time.time - lastHitTime >= hitCooldown)
        {
            canHit = true;
        }
    }

    private void Hit()
    {
        if (HitContoler == null)
        {
            Debug.LogError("HitContoler no está asignado en el inspector.");
            return;
        }

        StartCoroutine(Animate()); // Iniciar la animación de ataque

        float hitRadius = playerAttack.Range; // Obtener el rango del ataque del jugador
        Collider2D[] objects = Physics2D.OverlapCircleAll(HitContoler.position, hitRadius);

        foreach (Collider2D colisionador in objects)
        {
            if (colisionador.CompareTag("Enemy"))
            {
                EnemyLogic enemyLogic = colisionador.transform.GetComponent<EnemyLogic>();
                if (enemyLogic != null)
                {
                    enemyLogic.GetDamage(playerAttack.BasicDamage);
                }
                else
                {
                    Debug.LogWarning("El enemigo no tiene el script EnemyLogic adjunto.");
                }
            }
        }
    }

    private IEnumerator Animate()
    {
        if (gfx == null)
        {
            Debug.LogError("gfx no está asignado en el inspector.");
            yield break;
        }

        gfx.localRotation = Quaternion.Euler(0, 0, -70);

        yield return new WaitForSeconds(playerAttack.BasicAttackSpeed * 0.9f);

        gfx.localRotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnDrawGizmos()
    {
        if (HitContoler != null)
        {
            float hitRadius = playerAttack != null ? playerAttack.Range : 0.5f; // Obtener el rango del ataque del jugador
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(HitContoler.position, hitRadius);
        }
    }
}
