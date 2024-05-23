using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    [Header("Weapon")]
    public GameObject weaponItem;
    public float maxCooldownTime = 1f;
    private float cooldownTime;
    public float damage = 1;
    public bool IsReady => this.cooldownTime >= this.maxCooldownTime;



    // Start is called before the first frame update
    protected void Awake()
    {
        this.cooldownTime = this.maxCooldownTime;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (this.IsReady == false)
        {
            this.cooldownTime += this.maxCooldownTime;
        }
    }

    public void Activate()
    {
        if (this.IsReady)
        {
            this.OnActivate();

            this.cooldownTime = 0;
        }
    }

    public virtual void OnHit(Vida vida)
    {

        vida.Damage(this.damage);
    }
    public virtual void Throw()
    {
        Instantiate(this.weaponItem, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    protected abstract void OnActivate();


}