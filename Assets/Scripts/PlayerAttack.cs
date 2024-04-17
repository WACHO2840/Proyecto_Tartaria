using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float basicDamage = 5; // Daño base privado con un atributo para poder verlo en el inspector de Unity
    private float basicAttackSpeed = 3;
    public bool hasToroide = false;
    public bool hasElectron = false;
    public bool hasLenguaDeFuego = false;
    public bool hasRocaVolcanica = false;

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

    public void IncreaseDamage(int increaseAmountPickUp, float increaseAmountWeapon)
    {
        basicDamage += (increaseAmountPickUp+ increaseAmountWeapon); // Incrementa el daño base
        Debug.Log("Daño incrementado. Nuevo daño: " + basicDamage);
    }

    public void IncreaseAttackSpeed(float increaseAmountPickUp, float increaseAmountWeapon)
    {
        basicAttackSpeed += (increaseAmountPickUp + increaseAmountWeapon); // Incrementa el daño base
        Debug.Log("Velocidad de Ataque incrementada. Nuevo daño: " + basicAttackSpeed);
    }
    public void ApplySynergyTyE()
    {
        if (hasToroide && hasElectron)
        {
            // Restablece el efecto original de los objetos individuales si ya se había aplicado
            basicDamage -= 5; // Suponiendo que cada uno añadía 5 de daño

            // Aplica el nuevo efecto de sinergia
            basicDamage += 7; // Nuevo daño total de la sinergia
            Debug.Log("Sinergia aplicada. Nuevo daño total: " + basicDamage);
        }
    }

    public void ApplySynergyLyR()
    {
        if (hasLenguaDeFuego && hasRocaVolcanica)
        {
            // Restablece el efecto original de los objetos individuales si ya se había aplicado
            basicDamage -= 5; // Suponiendo que cada uno añadía 5 de daño
            basicAttackSpeed -= 0.5f;
            // Aplica el nuevo efecto de sinergia
            basicDamage += 7; // Nuevo daño total de la sinergia
            basicAttackSpeed += 1;
            Debug.Log("Sinergia aplicada. Nuevo daño total: " + basicDamage + "" + basicAttackSpeed);
        }
    }
}
