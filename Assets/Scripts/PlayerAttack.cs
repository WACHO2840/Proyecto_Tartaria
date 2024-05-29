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

    public bool isKatana = false;
    public bool isMazo = false;

    public float BasicAttackSpeed // Propiedad pública para acceder y modificar la velocidad de ataque
    {
        get
        {
            return baseAttackSpeed + additionalAttackSpeed;
        }
    }

    public float BasicDamage // Propiedad pública para acceder y modificar el daño básico
    {
        get
        {
            return baseDamage + additionalDamage;
        }
    }

    public float Range // Propiedad pública para acceder y modificar el rango
    {
        get
        {
            return baseRange + additionalRange;
        }
    }

    void Start()
    {
        // Inicialización si es necesario
    }

    void Update()
    {
        UpdateBaseStats();
    }

    private void UpdateBaseStats()
    {
        if (isKatana)
        {
            baseDamage = 10;
            baseAttackSpeed = 6;
            baseRange = 3f;
        }
        else if (isMazo)
        {
            baseDamage = 15;
            baseAttackSpeed = 4;
            baseRange = 2f;
        }
        else
        {
            baseDamage = 5;
            baseAttackSpeed = 3;
            baseRange = 3f; // Cambiado a 1.5 para el ataque sin arma
        }
    }

    public void IncreaseDamage(float amount)
    {
        additionalDamage += amount; // Incrementa el daño adicional
        Debug.Log("Daño incrementado. Nuevo daño: " + BasicDamage);
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
}



