using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class Katana : MonoBehaviour
// {
//     public int damage = 10;  // Cantidad de daño que hace la katana

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         // // Verifica si el objeto que colisiona tiene la etiqueta "enemigos"
//         // if (other.CompareTag("enemigos"))
//         // {
//         //     // Intenta obtener el componente de salud del enemigo
//         //     EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
//         //     if (enemyHealth != null)
//         //     {
//         //         // Aplicar daño al enemigo
//         //         enemyHealth.TakeDamage(damage);
//         //     }
//         // }
//     }
// }


public class Katana : MonoBehaviour
{
    public int damage = 10;  // Cantidad de daño que hace la katana
    public Transform gfx;  // Referencia al transform del gráfico de la katana
    public float maxCooldownTime = 1.0f;  // Tiempo de cooldown para la animación

    void OnTriggerEnter2D(Collider2D other)
    {
        // // Verifica si el objeto que colisiona tiene la etiqueta "enemigos"
        // if (other.CompareTag("enemigos"))
        // {
        //     // Intenta obtener el componente de salud del enemigo
        //     EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        //     if (enemyHealth != null)
        //     {
        //         // Aplicar daño al enemigo
        //         enemyHealth.TakeDamage(damage);
        //     }
        // }
    }

    public void StartAttack()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        // Rotar la katana para la animación de ataque
        gfx.localRotation = Quaternion.Euler(0, 0, -70);

        // Esperar por un tiempo antes de revertir la rotación
        yield return new WaitForSeconds(maxCooldownTime * 0.9f);

        // Revertir la rotación de la katana
        gfx.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
