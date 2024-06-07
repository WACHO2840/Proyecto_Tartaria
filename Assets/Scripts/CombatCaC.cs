using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCaC : MonoBehaviour
{
    [SerializeField] private Transform HitContoler; // Aseg�rate de asignar este valor en el inspector
    private PlayerAttack playerAttack;

    private bool canHit = true;
    private float hitCooldown;
    private float lastHitTime;

    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        if (playerAttack == null)
        {
            Debug.LogError("PlayerAttack no est� adjunto al GameObject.");
        }
    }

    void Update()
    {
        hitCooldown = 1 / playerAttack.BasicAttackSpeed; // Ajusta el cooldown basado en la velocidad de ataque

        if (Input.GetKeyDown(KeyCode.F) && canHit)
        {
            Debug.Log("ATAQUE");
            Hit();
            canHit = false;
            lastHitTime = Time.time;
        }

        if (Time.time - lastHitTime >= hitCooldown)
        {
            canHit = true;
        }
    }

    private void Hit()
    {
        float hitRadius = playerAttack.Range;
        Collider2D[] objects = Physics2D.OverlapCircleAll(HitContoler.position, hitRadius);

        foreach (Collider2D colisionador in objects)
        {
            if (colisionador.CompareTag("Enemy"))
            {
                EnemyLogic enemyLogic = colisionador.transform.GetComponent<EnemyLogic>();
                if (enemyLogic != null)
                {
                    enemyLogic.GetDamage(playerAttack.BasicDamage); // Usar BasicDamage
                }
                else
                {
                    Debug.LogWarning("El enemigo no tiene el script EnemyLogic adjunto.");
                }
            }
            if (colisionador.CompareTag("Boss"))
            {
                EnemyLogic enemyLogic = colisionador.transform.GetComponent<EnemyLogic>();
                if (enemyLogic != null)
                {
                    enemyLogic.GetDamage(playerAttack.BasicDamage); // Usar BasicDamage
                }
                else
                {
                    Debug.LogWarning("El enemigo no tiene el script EnemyLogic adjunto.");
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (HitContoler != null)
        {
            float hitRadius = playerAttack != null ? playerAttack.Range : 0.5f;
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(HitContoler.position, hitRadius);
        }
    }
}






