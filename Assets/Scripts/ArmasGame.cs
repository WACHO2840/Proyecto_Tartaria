using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasGame : MonoBehaviour
{
    public int damage = 10;  // Cantidad de daño que hace la katana
    public Transform gfx;  // Referencia al transform del gráfico de la katana
    public Transform hitSpot; // Punto de impacto de la katana
    public float range = 1.0f;  // Alcance del ataque de la katana
    public float maxCooldownTime = 1.0f;  // Tiempo de cooldown para la animación

    private bool isAttacking = false;
    private bool isEquipped = false;  // Indica si la katana está equipada

    void Start()
    {
        // Verifica si el objeto tiene el tag "katana" y está equipado por el jugador
        if (gameObject.CompareTag("Katana"))
        {
            isEquipped = true;
        }
    }

    void Update()
    {
        // Detectar la entrada "Fire1" (por defecto, clic izquierdo) y realizar la animación de ataque si está equipada
        if (Input.GetButtonDown("Fire1") && isEquipped && !isAttacking)
        {
            OnActivate();
        }
    }

    private void OnActivate()
    {
        Debug.Log("Activando ataque");
        StartCoroutine(Animate());

        Collider2D[] targets = Physics2D.OverlapCircleAll(hitSpot.position, range);

        foreach (var target in targets)
        {
            if (target.CompareTag("Enemy"))
            {
                EnemyStats enemyStats = target.GetComponent<EnemyStats>();
                if (enemyStats != null)
                {
                    // enemyStats.TakeDamage(damage);
                    Debug.Log("Daño aplicado al enemigo.");
                }
            }
        }
    }

    IEnumerator Animate()
    {
        isAttacking = true;
        Debug.Log("Comenzando animación de ataque");

        // Rotar la Katana para la animación de ataque
        gfx.localRotation = Quaternion.Euler(0, 0, -70);
        Debug.Log("Katana rotada a -70 grados");

        // Esperar por un tiempo antes de revertir la rotación
        yield return new WaitForSeconds(maxCooldownTime * 0.9f);

        // Revertir la rotación de la katana
        gfx.localRotation = Quaternion.Euler(0, 0, 0);
        Debug.Log("Katana revertida a 0 grados");

        // Esperar el resto del tiempo de cooldown
        yield return new WaitForSeconds(maxCooldownTime * 0.1f);

        isAttacking = false;
        Debug.Log("Animación de ataque terminada");
    }

    private void OnDrawGizmos()
    {
        // Dibujar el alcance del ataque en el editor para visualización
        if (hitSpot != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(hitSpot.position, range);
        }
    }
}