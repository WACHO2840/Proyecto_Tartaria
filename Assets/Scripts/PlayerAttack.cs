using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float baseDamage = 5;
    private float baseAttackSpeed = 3;
    private float baseRange = 1.5f;

    private float additionalDamage = 0;
    private float additionalAttackSpeed = 0;
    private float additionalRange = 0;

    private ArmasGame equippedWeapon;

    public float BasicAttackSpeed // Propiedad p�blica para acceder y modificar la velocidad de ataque
    {
        get
        {
            return (equippedWeapon != null ? equippedWeapon.GetWeaponAttackSpeed() : baseAttackSpeed) + additionalAttackSpeed;
        }
    }

    public float BasicDamage // Propiedad p�blica para acceder y modificar el da�o b�sico
    {
        get
        {
            return (equippedWeapon != null ? equippedWeapon.GetWeaponDamage() : baseDamage) + additionalDamage;
        }
    }

    public float Range // Propiedad p�blica para acceder y modificar el rango
    {
        get
        {
            return (equippedWeapon != null ? equippedWeapon.GetWeaponRange() : baseRange) + additionalRange;
        }
    }

    void Start()
    {
        LogCurrentStats(); // Mostrar estad�sticas iniciales
    }

    void Update()
    {
        // Este m�todo se puede utilizar para actualizar la l�gica si es necesario
    }

    public void EquipWeapon(GameObject weapon)
    {
        if (weapon.CompareTag("Katana"))
        {
            equippedWeapon = weapon.GetComponent<ArmasGame>();
            Debug.Log("Katana equipada.");
        }
        else if (weapon.CompareTag("Mazo"))
        {
            equippedWeapon = weapon.GetComponent<ArmasGame>();
            Debug.Log("Mazo equipado.");
        }
        else
        {
            equippedWeapon = null;
            Debug.Log("Sin arma equipada.");
        }

        LogCurrentStats();
    }

    public void UnequipWeapon()
    {
        equippedWeapon = null;
        Debug.Log("Arma desequipada.");
        LogCurrentStats();
    }

    public void IncreaseDamage(float amount)
    {
        additionalDamage += amount; // Incrementa el da�o adicional
        Debug.Log("Da�o incrementado. Nuevo da�o: " + BasicDamage);
    }

    public void IncreaseAttackSpeed(float amount)
    {
        additionalAttackSpeed += amount; // Incrementa la velocidad de ataque adicional
        Debug.Log("Velocidad de Ataque incrementada. Nueva velocidad: " + BasicAttackSpeed);
    }

    private void LogCurrentStats()
    {
        Debug.Log("Estad�sticas actuales del personaje:");
        Debug.Log("Da�o: " + BasicDamage);
        Debug.Log("Velocidad de Ataque: " + BasicAttackSpeed);
        Debug.Log("Rango: " + Range);
    }
    public void ResetStats()
    {
        additionalDamage = 0;
        additionalAttackSpeed = 0;
        additionalRange = 0;
        equippedWeapon = null;
        Debug.Log("Estad�sticas reiniciadas.");
        LogCurrentStats();
    }
}
