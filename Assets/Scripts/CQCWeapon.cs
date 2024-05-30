// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CQCWeapon : MonoBehaviour
// {
//     public Transform hitSpot;
//     public float range = 1;

//     public Transform gfx;
//     private float maxCooldownTime;

//      protected override void OnActivate()
//     {
//         StartCoroutine(this.Animate());

//         Collider2D[] targets = Physics2D.OverlapCircleAll(this.hitSpot.position, this.range);

//         // foreach (var target in targets)
//         // {
//         //     Health h = target.GetComponent<Health>();
//         //     if (h == null)
//         //         continue;

//         //     this.OnHit(h);
//         // }
//     }


//     IEnumerator Animate()
//     {
//         this.gfx.localRotation = Quaternion.Euler(0, 0, -70);

//         yield return new WaitForSeconds(this.maxCooldownTime * 0.9f);

//         this.gfx.localRotation = Quaternion.Euler(0, 0, 0);
//     }

//     private void OnDrawGizmos()
//     {
//         Gizmos.DrawWireSphere(this.hitSpot.position, this.range);
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CQCWeapon : Weapon
{
    public Transform hitSpot;
    public float range = 1;

    public Transform gfx;
    // private float maxCooldownTime;

    protected override void OnActivate()
    {
        StartCoroutine(this.Animate());

        Collider2D[] targets = Physics2D.OverlapCircleAll(this.hitSpot.position, this.range);

        // foreach (var target in targets)
        // {
        //     Health h = target.GetComponent<Health>();
        //     if (h == null)
        //         continue;

        //     this.OnHit(h);
        // }
    }

    private IEnumerator Animate()
    {
        this.gfx.localRotation = Quaternion.Euler(0, 0, -70);

        yield return new WaitForSeconds(this.maxCooldownTime * 0.9f);

        this.gfx.localRotation = Quaternion.Euler(0, 0, 0);
    }

    // Método OnHit para manejar el golpe
    // private void OnHit(Health health)
    // {
    //     health.Damage(this.damage);
    // }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.hitSpot.position, this.range);
    }
}
