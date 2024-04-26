using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagers : MonoBehaviour
{
    public SpriteRenderer playerWeapon;

    public Sprite katanaSprite;
    public Sprite mazoSprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "katana")
        {
            playerWeapon.sprite = katanaSprite;
            Destroy(playerWeapon.sprite);
        }
        else if (collision.gameObject.tag == "mazo")
        {
            playerWeapon.sprite = mazoSprite;
            Destroy(playerWeapon.sprite);
        }
    }

}
