using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPost;
    public LayerMask whatIsEnemies;
    public float attackDamage;
    public Animator camAnim;
    public Animator playerAnim;
    public int damage;
    void Update()
    {
        if (timeBtwAttack <= 0)
        {

            if (Input.GetKey(KeyCode.Space))
            {
                camAnim.SetTrigger("shake");
                playerAnim.SetTrigger("AttackKatana");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPost.position, attackDamage, whatIsEnemies);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetOrAddComponent<EnemyHealth>().TakeDamage(damage);
                }
            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPost.position, attackDamage);
    }
}
