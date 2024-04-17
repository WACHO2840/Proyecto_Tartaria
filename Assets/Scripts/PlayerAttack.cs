using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private double basicDamage = 5; // Da�o base privado con un atributo para poder verlo en el inspector de Unity
    private double basicAttackSpeed = 3;

    public int BasicAttackSpeed // Propiedad p�blica para acceder y modificar el da�o b�sico
    {
        get { return (int)basicAttackSpeed; }
        set { basicAttackSpeed = value; }
    }
    public int BasicDamage // Propiedad p�blica para acceder y modificar  b�sico
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
        basicDamage += (increaseAmountPickUp+ increaseAmountWeapon); // Incrementa el da�o base
        Debug.Log("Da�o incrementado. Nuevo da�o: " + basicDamage);
    }

    public void IncreaseAttackSpeed(double increaseAmountPickUp, double increaseAmountWeapon)
    {
        basicAttackSpeed += (increaseAmountPickUp + increaseAmountWeapon); // Incrementa el da�o base
        Debug.Log("Velocidad de Ataque incrementada. Nuevo da�o: " + basicAttackSpeed);
    }
}
