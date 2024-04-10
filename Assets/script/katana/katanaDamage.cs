using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class katanaDamage : MonoBehaviour
{
    public int damageAmount = 10; // Cantidad de daño que causa la katana (mayor que el de la espada)

    private new BoxCollider2D collider2D;
    private SpriteRenderer playerSpriteRenderer;

    public Animator animator;

    public GameObject swordParent;

    void Start()
    {
        playerSpriteRenderer = transform.root.GetComponent<SpriteRenderer>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (playerSpriteRenderer.flipX == true)
        {
            swordParent.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void Attack()
    {
        animator.Play("Attack");
        collider2D.enabled = true;
        Invoke("DisableAttack", 0.5f);
    }

    private void DisableAttack()
    {
        collider2D.enabled = false;
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Enemy"))
    //     {
    //         // Comprueba si el componente 'ScripDamage' está presente en el objeto del enemigo
    //         ScriptDamage enemyDamageScript = collision.gameObject.GetComponent<ScriptDamage>();
    //         if (enemyDamageScript != null)
    //         {
    //             // Llama al método LoseLifeAndHit del ScriptDamage para aplicar el daño
    //             enemyDamageScript.LoseLifeAndHit(damageAmount);
    //         }

    //         // Desactiva el collider después de impactar con un enemigo
    //         collider2D.enabled = false;
    //     }
    // }
}
