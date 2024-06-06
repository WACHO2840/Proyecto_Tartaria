/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float baseDamage = 5;
    private float baseAttackSpeed = 3;

    private float baseRange = 3f;

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

    public void IncreaseRange(float amount)
    {
        additionalRange += amount; // Incrementa el rango adicional
        Debug.Log("Rango incrementado. Nuevo rango: " + Range);
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
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float baseDamage = 5;
    private float baseAttackSpeed = 3;
    private float baseRange = 3f;

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

    public void IncreaseDamage(float amount)
    {
        additionalDamage += amount;
        Debug.Log("Da�o incrementado. Nuevo da�o: " + BasicDamage);
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
