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

    public void EquipWeapon(GameObject weapon)
    {
        ArmasGame newWeapon = weapon.GetComponent<ArmasGame>();
        if (newWeapon != null)
        {
            equippedWeapon = newWeapon;
            additionalDamage = newWeapon.GetWeaponDamage(); // Asignar el daño del arma al daño adicional
            Debug.Log(weapon.tag + " equipada. Daño: " + BasicDamage + ", Velocidad de Ataque: " + BasicAttackSpeed + ", Rango: " + Range);
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

    public void IncreaseDamage(float amount)
    {
        additionalDamage += amount;
        Debug.Log("Daño incrementado. Nuevo daño: " + BasicDamage);
    }

    public void IncreaseAttackSpeed(float amount)
    {
        additionalAttackSpeed += amount;
        Debug.Log("Velocidad de Ataque incrementada. Nueva velocidad: " + BasicAttackSpeed);
    }

    public void IncreaseRange(float amount)
    {
        additionalRange += amount;
        Debug.Log("Rango incrementado. Nuevo rango: " + Range);
    }

    private void LogCurrentStats()
    {
        Debug.Log("Estadísticas actuales del personaje:");
        Debug.Log("Daño: " + BasicDamage);
        Debug.Log("Velocidad de Ataque: " + BasicAttackSpeed);
        Debug.Log("Rango: " + Range);
    }

    public void ResetStats()
    {
        additionalDamage = 0;
        additionalAttackSpeed = 0;
        additionalRange = 0;
        equippedWeapon = null;
        Debug.Log("Estadísticas reiniciadas.");
        LogCurrentStats();
    }
}
