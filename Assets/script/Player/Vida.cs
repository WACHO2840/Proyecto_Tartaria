using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
   public float maxHealth = 100f; // Establece un valor predeterminado para la vida máxima

    public float CurrentHealth => currentHealth; // Utiliza una propiedad de solo lectura para obtener la salud actual

    private float currentHealth; // La salud actual se manejará de forma privada

    public event Action<float, Vector3> OnDamage; // Utiliza un evento para notificar daños con la cantidad y la ubicación
    public event Action OnDeath; // Utiliza un evento para notificar la muerte

    private void Awake()
    {
        currentHealth = maxHealth; // Establece la salud actual igual a la salud máxima al despertar
    }

    public void Restore(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0f, maxHealth); // Restaura la salud y asegura que no supere la salud máxima
    }

    public void Damage(float amount, Vector3 instigatorLocation)
    {
        if (currentHealth > 0f) // Solo aplicar daño si la salud actual es mayor que cero
        {
            if (OnDamage != null)
            {
                OnDamage(amount, instigatorLocation); // Notificar a los suscriptores sobre el daño aplicado
            }

            currentHealth = Mathf.Clamp(currentHealth - amount, 0f, maxHealth); // Aplicar daño y asegurar que no caiga por debajo de cero

            if (currentHealth == 0f) // Verificar si la salud ha llegado a cero
            {
                Die(); // Llamar al método Die si la salud es cero
            }
        }
    }

    private void Die()
    {
        if (OnDeath != null)
        {
            OnDeath(); // Notificar a los suscriptores sobre la muerte
        }

        Destroy(gameObject); // Destruir el GameObject al morir
    }

    internal void Damage(float damage)
    {
        throw new NotImplementedException();
    }
}
