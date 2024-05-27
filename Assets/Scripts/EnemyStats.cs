using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    #region Variables
    [SerializeField] public int maxHp = 100;
    [SerializeField] public float movementSpeed = 3.0f;
    [SerializeField] public float attackSpeed = 1.0f;
    [SerializeField] public int dmg = 10;
    private int hp;
    #endregion

    void Start()
    {
        hp = maxHp;
    }

    public int GetHp()
    {
        return hp;
    }

    public void ReduceHp(float damage)
    {
        hp -= (int)damage;
        Debug.Log("Vida restante del enemigo: " + hp);
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemigo muerto");
        Destroy(gameObject);
    }
}


