using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon currentWeapon;
    public Transform weaponHolder;
    public bool HasRoomForWeapon => this.currentWeapon == null;
    // void Start()
    // {
    //     Weapon[] weapons = this.GetComponentInChildren<Weapon>();
    //     foreach (var x in weapons)
    //     {
    //         this.PickUpWeapon(x);
    //     }
    // }
    void Start()
    {
        // Obtener todas las armas del objeto hijo y elegir la primera encontrada
        Weapon[] weapons = GetComponentsInChildren<Weapon>();
        if (weapons.Length > 0)
        {
            PickUpWeapon(weapons[0]); // Solo recoge la primera arma encontrada por ahora
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (this.currentWeapon != null)
            {
                this.currentWeapon.Activate();
            }
        }
        if (Input.GetButton("Fire2"))
        {
            if (this.currentWeapon != null)
            {
                this.currentWeapon.Throw();
                this.currentWeapon = null;
            }
        }
    }

    public void PickUpWeapon(Weapon wp)
    {
        wp.transform.position = this.weaponHolder.position;
        wp.transform.rotation = this.weaponHolder.rotation;
        wp.transform.SetParent(this.weaponHolder);
    }

}
