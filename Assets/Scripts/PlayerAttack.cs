using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float baseDamage = 5;
    private float baseAttackSpeed = 3;
    private float baseRange = 0.9f;

    private float additionalDamage = 0;
    private float additionalAttackSpeed = 0;
    private float additionalRange = 0;

    private ArmasGame equippedWeapon;

    public float BasicAttackSpeed
    {
        get
        {
            return (equippedWeapon != null ? equippedWeapon.GetWeaponAttackSpeed() : baseAttackSpeed) + additionalAttackSpeed;
        }
    }

    public float BasicDamage
    {
        get
        {
            return baseDamage + additionalDamage;
        }
    }

    public float Range
    {
        get
        {
            return (equippedWeapon != null ? equippedWeapon.GetWeaponRange() : baseRange) + additionalRange;
        }
    }

    void Start()
    {
        LogCurrentStats();
    }

    void Update()
    {
    }
    //detecta el arma equipada y recoge el da�o de esta
    public void EquipWeapon(GameObject weapon)
    {
        ArmasGame newWeapon = weapon.GetComponent<ArmasGame>();
        if (newWeapon != null)
        {
            equippedWeapon = newWeapon;
            additionalDamage = newWeapon.GetWeaponDamage(); // Asignar el da�o del arma al da�o adicional
            Debug.Log(weapon.tag + " equipada. Da�o: " + BasicDamage + ", Velocidad de Ataque: " + BasicAttackSpeed + ", Rango: " + Range);
        }
        else
        {
            Debug.LogError("El objeto no tiene un componente ArmasGame.");
        }

        LogCurrentStats();
    }

    public void UnequipWeapon()
    {
        equippedWeapon = null;
        additionalDamage = 0;
        Debug.Log("Arma desequipada.");
        LogCurrentStats();
    }
    //funcion para aumnentar el da�o dependiendo de los items
    public void IncreaseDamage(float amount)
    {
        additionalDamage += amount;
        Debug.Log("Da�o incrementado. Nuevo da�o: " + BasicDamage);
    }
    //funcion para aumnentar la velocidad de ataque dependiendo de los items
    public void IncreaseAttackSpeed(float amount)
    {
        additionalAttackSpeed += amount;
        Debug.Log("Velocidad de Ataque incrementada. Nueva velocidad: " + BasicAttackSpeed);
    }
    //funcion para aumnentar el rango dependiendo de los items
    public void IncreaseRange(float amount)
    {
        additionalRange += amount;
        Debug.Log("Rango incrementado. Nuevo rango: " + Range);
    }

    private void LogCurrentStats()
    {
        Debug.Log("Estad�sticas actuales del personaje:");
        Debug.Log("Da�o: " + BasicDamage);
        Debug.Log("Velocidad de Ataque: " + BasicAttackSpeed);
        Debug.Log("Rango: " + Range);
    }
}
