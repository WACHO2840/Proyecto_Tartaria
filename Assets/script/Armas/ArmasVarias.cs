using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasVarias : Weapon
{
    public Transform hitSpot;
    public float rango = 1;

    public Transform gfx;
    protected override void OnActivate()
    {
        // throw new System.NotImplementedException();

        StartCoroutine(this.Animate());

        Collider2D[] targets = Physics2D.OverlapCircleAll(this.hitSpot.position, this.rango);

        foreach (var target in targets)
        {
            Vida h = target.GetComponent<Vida>();
            if (h == null)
            {
                continue;
            }

            this.OnHit(h);
        }
    }

    IEnumerator Animate()
    {
        this.gfx.localRotation = Quaternion.Euler(0,0,-70);

        yield return new WaitForSeconds(this.maxCooldownTime * 0.9f);

        this.gfx.localRotation = Quaternion.Euler(0,0,-70);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.hitSpot.position, this.rango);
    }
}
