using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public bool isKat = true;
    public bool isMazo = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isKat)
            {
                /*playerWeapon.sprite = katanaSprite;
                Destroy(playerWeapon.sprite);*/
                Debug.Log("katana");
            }
            else if (isMazo)
            {
                /*playerWeapon.sprite = mazoSprite;
                Destroy(playerWeapon.sprite);*/
                Debug.Log("katana");
            }
            GetComponent<Collider2D>().enabled = false;
            if (GetComponent<Renderer>() != null)
            {
                GetComponent<Renderer>().enabled = false;
            }
        }
    }
}
