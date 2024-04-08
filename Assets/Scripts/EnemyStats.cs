using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class EnemyStats : MonoBehaviour
{
    public static EnemyStats instance;

    #region Variables
    [SerializeField] public int maxHp;
    [SerializeField] public float movementSpeed;
    [SerializeField] public float attackSpeed;
    [SerializeField] public int dmg;
    public int hp;
    #endregion

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        hp = maxHp;
    }
}
