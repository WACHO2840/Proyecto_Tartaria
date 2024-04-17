using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float basicDamage = 5; // Da�o base privado con un atributo para poder verlo en el inspector de Unity
    private float basicAttackSpeed = 3;
    public bool hasToroide = false;
    public bool hasElectron = false;
    public bool hasLenguaDeFuego = false;
    public bool hasRocaVolcanica = false;

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

    public void IncreaseDamage(int increaseAmountPickUp, float increaseAmountWeapon)
    {
        basicDamage += (increaseAmountPickUp+ increaseAmountWeapon); // Incrementa el da�o base
        Debug.Log("Da�o incrementado. Nuevo da�o: " + basicDamage);
    }

    public void IncreaseAttackSpeed(float increaseAmountPickUp, float increaseAmountWeapon)
    {
        basicAttackSpeed += (increaseAmountPickUp + increaseAmountWeapon); // Incrementa el da�o base
        Debug.Log("Velocidad de Ataque incrementada. Nuevo da�o: " + basicAttackSpeed);
    }
    public void ApplySynergyTyE()
    {
        if (hasToroide && hasElectron)
        {
            // Restablece el efecto original de los objetos individuales si ya se hab�a aplicado
            basicDamage -= 5; // Suponiendo que cada uno a�ad�a 5 de da�o

            // Aplica el nuevo efecto de sinergia
            basicDamage += 7; // Nuevo da�o total de la sinergia
            Debug.Log("Sinergia aplicada. Nuevo da�o total: " + basicDamage);
        }
    }

    public void ApplySynergyLyR()
    {
        if (hasLenguaDeFuego && hasRocaVolcanica)
        {
            // Restablece el efecto original de los objetos individuales si ya se hab�a aplicado
            basicDamage -= 5; // Suponiendo que cada uno a�ad�a 5 de da�o
            basicAttackSpeed -= 0.5f;
            // Aplica el nuevo efecto de sinergia
            basicDamage += 7; // Nuevo da�o total de la sinergia
            basicAttackSpeed += 1;
            Debug.Log("Sinergia aplicada. Nuevo da�o total: " + basicDamage + "" + basicAttackSpeed);
        }
    }
}
