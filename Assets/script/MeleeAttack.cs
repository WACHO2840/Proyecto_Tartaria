using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Animator playerAnim;
    public float attackDelay;
    public Transform weaponTransform;
    public float weaponRange;
    public int weaponDamage;
    public LayerMask enemyLayer;


    private float timer;
    public float coolDown = 2;
    public float KBforce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(AttackEnemi());
        }
    }

    IEnumerator AttackEnemi()
    {
        playerAnim.Play("ObjectHand");
        Collider2D enemy = Physics2D.OverlapCircle(weaponTransform.position, weaponRange, enemyLayer);
        yield return new WaitForSeconds(attackDelay);

        bool facingRigth = (transform.position.x < enemy.transform.position.x);
        // enemy.GetComponent<EnemyHealth>().TakeDamage(
        //     weaponDamage, facingRigth, KBforce);
    }
}
