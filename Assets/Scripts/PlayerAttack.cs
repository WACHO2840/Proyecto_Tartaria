using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private double basicDamage = 5; // Daño base privado con un atributo para poder verlo en el inspector de Unity
    private double basicAttackSpeed = 3;

    public int BasicAttackSpeed // Propiedad pública para acceder y modificar el daño básico
    {
        get { return (int)basicAttackSpeed; }
        set { basicAttackSpeed = value; }
    }
    public int BasicDamage // Propiedad pública para acceder y modificar  básico
    {
        get { return (int)basicDamage; }
        set { basicDamage = value; }
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void IncreaseDamage(int increaseAmountPickUp, double increaseAmountWeapon)
    {
        basicDamage += (increaseAmountPickUp+ increaseAmountWeapon); // Incrementa el daño base
        Debug.Log("Daño incrementado. Nuevo daño: " + basicDamage);
    }

    public void IncreaseAttackSpeed(double increaseAmountPickUp, double increaseAmountWeapon)
    {
        basicAttackSpeed += (increaseAmountPickUp + increaseAmountWeapon); // Incrementa el daño base
        Debug.Log("Velocidad de Ataque incrementada. Nuevo daño: " + basicAttackSpeed);
    }
}
