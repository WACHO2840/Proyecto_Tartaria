using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public static WeaponStats Instance;

    [SerializeField] int Damage;
    private int CritDamage;
    [SerializeField] int AttackSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
