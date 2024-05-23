using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCaC : MonoBehaviour
{
    [SerializeField] private Transform HitContoler;
    [SerializeField] private float HitRadius;
    [SerializeField] private float HitDamage;

    private void Hit()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(HitContoler.position, HitRadius);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
