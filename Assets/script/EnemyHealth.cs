using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // public int enemyHealth = 1;
    // public Rigidbody2D enemyZombi;


    // private void Start()
    // {
    //     enemyZombi = GetComponent<Rigidbody2D>();
    // }

    // public void TakeDamage(int amount, bool facingRight, float kBforce)
    // {   
    //     if (facingRight)
    //     {

    //     }

    //     enemyHealth -= amount;

    //     if (enemyHealth <= 0)
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    public int health;
    public float speed;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true); 
    }
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("pupa");
    }

    internal void TakeDamage(object damage)
    {
        throw new NotImplementedException();
    }
}
