// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class WeaponManager : MonoBehaviour
// {
//     public Weapon currentWeapon;

//     public Transform weaponHolder;

//     public bool HasRoomForWeapon => this.currentWeapon == null;

//     // UI
//     private AmmoUI ammoUI;

//     /// =========================================================
//     /// <summary>
//     ///
//     /// </summary>
//     void Start()
//     {
//         this.ammoUI = FindObjectOfType<AmmoUI>();
//         this.ammoUI.Display(false);

//         Weapon[] weapons = this.GetComponentsInChildren<Weapon>();
//         foreach (var w in weapons)
//         {
//             // ARREGLAME PLS
//             this.PickUpWeapon(w, 9999);
//         }
//     }

//     /// =========================================================
//     /// <summary>
//     ///
//     /// </summary>
//     private void Update()
//     {
//         if (Input.GetButton("Fire1"))
//         {
//             if (this.currentWeapon != null)
//             {
//                 this.currentWeapon.Activate();
//             }
//         }

//         if (Input.GetButton("Fire2"))
//         {
//             if (this.currentWeapon != null)
//             {
//                 this.currentWeapon.Throw();
//                 this.currentWeapon = null;

//                 this.ammoUI.Display(false);
//             }
//         }
//     }

//     /// =========================================================
//     /// <summary>
//     ///
//     /// </summary>
//     /// <param name="weapon"></param>
//     /// <param name="startingAmmo"></param>
//     public void PickUpWeapon(Weapon weapon, int startingAmmo)
//     {
//         weapon.transform.position = this.weaponHolder.position;
//         weapon.transform.rotation = this.weaponHolder.rotation;
//         weapon.transform.SetParent(this.weaponHolder);

//         this.currentWeapon = weapon;

//         if (this.currentWeapon is GunWeapon)
//         {
//             GunWeapon gun = this.currentWeapon as GunWeapon;

//             gun.ui = this.ammoUI;

//             gun.currentAmmo = startingAmmo;

//             this.ammoUI.Display(true);
//         }
//         else
//         {
//             this.ammoUI.Display(false);
//         }
//     }

//     /// =========================================================
//     /// <summary>
//     ///
//     /// </summary>
//     /// <param name="type"></param>
//     /// <param name="amount"></param>
//     /// <returns></returns>
//     public bool TryToRecharge(GunType type, int amount)
//     {
//         if (this.currentWeapon is GunWeapon == false)
//             return false;

//         GunWeapon gun = this.currentWeapon as GunWeapon;
//         if (gun.type != type)
//             return false;

//         if (gun.isAmmoAtMax)
//             return false;

//         gun.currentAmmo += amount;

//         return true;
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon currentWeapon;
    public Transform weaponHolder;
    public bool HasRoomForWeapon => this.currentWeapon == null;

    // UI
    private AmmoUI ammoUI;

    void Start()
    {
        this.ammoUI = FindObjectOfType<AmmoUI>();
        if (this.ammoUI != null)
        {
            this.ammoUI.Display(false);
        }
        else
        {
            Debug.LogError("AmmoUI not found in the scene!");
        }

        Weapon[] weapons = this.GetComponentsInChildren<Weapon>();
        foreach (var w in weapons)
        {
            if (w != null)
            {
                this.PickUpWeapon(w, 9999);
            }
            else
            {
                Debug.LogError("Weapon is null in the weapons array!");
            }
        }
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (this.currentWeapon != null)
            {
                this.currentWeapon.Activate();
            }
            else
            {
                Debug.LogWarning("No current weapon to activate.");
            }
        }

        if (Input.GetButton("Fire2"))
        {
            if (this.currentWeapon != null)
            {
                this.currentWeapon.Throw();
                this.currentWeapon = null;

                if (this.ammoUI != null)
                {
                    this.ammoUI.Display(false);
                }
            }
            else
            {
                Debug.LogWarning("No current weapon to throw.");
            }
        }
    }

    public void PickUpWeapon(Weapon weapon, int startingAmmo)
    {
        if (weapon == null)
        {
            Debug.LogError("Trying to pick up a null weapon!");
            return;
        }

        if (weaponHolder == null)
        {
            Debug.LogError("Weapon holder is not assigned!");
            return;
        }

        weapon.transform.position = this.weaponHolder.position;
        weapon.transform.rotation = this.weaponHolder.rotation;
        weapon.transform.SetParent(this.weaponHolder);

        this.currentWeapon = weapon;

        if (this.currentWeapon is GunWeapon gun)
        {
            gun.ui = this.ammoUI;
            gun.currentAmmo = startingAmmo;

            if (this.ammoUI != null)
            {
                this.ammoUI.Display(true);
            }
            else
            {
                Debug.LogError("AmmoUI is null when trying to display.");
            }
        }
        else
        {
            if (this.ammoUI != null)
            {
                this.ammoUI.Display(false);
            }
            else
            {
                Debug.LogError("AmmoUI is null when trying to hide.");
            }
        }
    }

    public bool TryToRecharge(GunType type, int amount)
    {
        if (!(this.currentWeapon is GunWeapon gun))
        {
            Debug.LogWarning("Current weapon is not a GunWeapon.");
            return false;
        }

        if (gun.type != type)
        {
            Debug.LogWarning("Gun type does not match.");
            return false;
        }

        if (gun.isAmmoAtMax)
        {
            Debug.LogWarning("Ammo is already at max.");
            return false;
        }

        gun.currentAmmo += amount;
        return true;
    }
}
