using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    #region Variables
    [SerializeField] public int maxHp;
    [SerializeField] public float movementSpeed;
    [SerializeField] public int dmg;
    private int hp;
    #endregion

    // Inicializar vida
    void Start()
    {
        hp = maxHp;
    }

    // Devolver vida
    public int GetHp() { return hp; }

    // Actualizar vida
    public void SetHp(int dmg) { hp -= dmg; }
}
