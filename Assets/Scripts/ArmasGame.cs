/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasGame : MonoBehaviour
{
    public Transform gfx;  // Referencia al transform del gráfico de la katana
    public Transform hitSpot; // Punto de impacto de la katana
    public float maxCooldownTime = 1.0f;  // Tiempo de cooldown para la animación

    private bool isAttacking = false;
    private bool isEquipped = false;  // Indica si el arma esta equipada 

    void Start()
    {
        // Verifica si el objeto tiene el tag "katana" y está equipado por el jugador
        if (gameObject.CompareTag("Katana") || gameObject.CompareTag("Mazo"))
        {
            isEquipped = true;
        }
    }

    void Update()
    {
        // Detectar la entrada "Fire1" (por defecto, clic izquierdo) y realizar la animación de ataque si está equipada
        if (Input.GetKeyDown(KeyCode.F) && isEquipped && !isAttacking)
        {
            OnActivate();
        }
    }

    private void OnActivate()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        isAttacking = true;
        Debug.Log("Comenzando animación de ataque");

        // Rotar la Katana para la animación de ataque
        gfx.localRotation = Quaternion.Euler(0, 0, -70);
        Debug.Log("Katana rotada a -70 grados");

        // Esperar por un  antes de revertir la rotación
        yield return new WaitForSeconds(maxCooldownTime * 0.9f);

        // Revertir la rotación de la katana
        gfx.localRotation = Quaternion.Euler(0, 0, 0);
        Debug.Log("Katana revertida a 0 grados");

        // Esperar el resto del tiempo de cooldown
        yield return new WaitForSeconds(maxCooldownTime * 0.1f);

        isAttacking = false;
        Debug.Log("Animación de ataque terminada");
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasGame : MonoBehaviour
{
    public Transform gfx;  // Referencia al transform del gráfico del arma
    public Transform hitSpot; // Punto de impacto del arma
    public float maxCooldownTime = 1.0f;  // Tiempo de cooldown para la animación

    private bool isAttacking = false;
    public bool isKatana = false;
    public bool isMazo = false;

    private float weaponDamage = 0;
    private float weaponAttackSpeed = 0;
    private float weaponRange = 0;

    void Start()
    {
        // Inicializar estadísticas de acuerdo al tipo de arma
        if (gameObject.CompareTag("Katana"))
        {
            isKatana = true;
            weaponDamage = 10;
            weaponAttackSpeed = 6;
            weaponRange = 3f;
        }
        else if (gameObject.CompareTag("Mazo"))
        {
            isMazo = true;
            weaponDamage = 15;
            weaponAttackSpeed = 4;
            weaponRange = 2f;
        }
        else
        {
            weaponDamage = 5;
            weaponAttackSpeed = 3;
            weaponRange = 1.5f;
        }
    }

    void Update()
    {
        // Detectar la entrada "Fire1" (por defecto, clic izquierdo) y realizar la animación de ataque si está equipada
        if (Input.GetKeyDown(KeyCode.F) && !isAttacking)
        {
            OnActivate();
        }
    }

    private void OnActivate()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        isAttacking = true;
        Debug.Log("Comenzando animación de ataque");

        // Rotar el arma para la animación de ataque
        gfx.localRotation = Quaternion.Euler(0, 0, -70);
        Debug.Log("Arma rotada a -70 grados");

        // Esperar por un tiempo antes de revertir la rotación
        yield return new WaitForSeconds(maxCooldownTime * 0.9f);

        // Revertir la rotación del arma
        gfx.localRotation = Quaternion.Euler(0, 0, 0);
        Debug.Log("Arma revertida a 0 grados");

        // Esperar el resto del tiempo de cooldown
        yield return new WaitForSeconds(maxCooldownTime * 0.1f);

        isAttacking = false;
        Debug.Log("Animación de ataque terminada");
    }

    public float GetWeaponDamage()
    {
        return weaponDamage;
    }

    public float GetWeaponAttackSpeed()
    {
        return weaponAttackSpeed;
    }

    public float GetWeaponRange()
    {
        return weaponRange;
    }
}
