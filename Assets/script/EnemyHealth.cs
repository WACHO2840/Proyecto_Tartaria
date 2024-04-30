using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 1;
    public Rigidbody2D enemyZombi;


    private void Start()
    {
        enemyZombi = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int amount, bool facingRight, float kBforce)
    {   
        if (facingRight)
        {
            
        }

        enemyHealth -= amount;

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
