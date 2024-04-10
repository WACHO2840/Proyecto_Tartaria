using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class EnemyStats : MonoBehaviour
{
    #region Variables
    [SerializeField] public int maxHp;
    [SerializeField] public float movementSpeed;
    [SerializeField] public float attackSpeed;
    [SerializeField] public int dmg;
    private int hp;
    #endregion

    void Start()
    {
        hp = maxHp;
    }

    public int GetHp() { return hp; }

    public void SetHp(int dmg) { hp -= dmg; }
}
