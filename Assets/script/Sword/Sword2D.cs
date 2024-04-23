using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword2D : MonoBehaviour
{

    private new BoxCollider2D collider2D;
    private SpriteRenderer playerSpriteRenderer;

    public Animator animator;

    public GameObject swordParent;
    // Start is called before the first frame update
    void Start()
    {
        playerSpriteRenderer = transform.root.GetComponent<SpriteRenderer>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
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
        animator.Play("AttackKatana");
        collider2D.enabled = true;
        Invoke("DisableAttack", 0.5f);
    }

    private void DisableAttack()
    {
        collider2D.enabled = false;
    }

    private void OntriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {   
            // #ScripDamage# es un scrip que estara asociado a los enemigos
            collision.gameObject.GetComponent<DamageEnemy>().LoseLifeAndHit();
            collider2D.enabled= false;
        }
    }
}
