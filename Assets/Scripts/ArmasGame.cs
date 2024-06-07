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

    public GameObject interactText;
    public bool isPlayerInRange = false;

    void Start()
    {
        interactText.gameObject.SetActive(false);
        // Inicializar estadísticas de acuerdo al tipo de arma
        if (gameObject.CompareTag("Katana"))
        {
            isKatana = true;
            weaponDamage = 5;
            weaponAttackSpeed = 1.5f;
            weaponRange = 1.5f;
        }
        else if (gameObject.CompareTag("Mazo"))
        {
            isMazo = true;
            weaponDamage = 12;
            weaponAttackSpeed = 2;
            weaponRange = 1.2f;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isAttacking)
        {
            OnActivate();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactText.gameObject.SetActive(false);
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

        gfx.localRotation = Quaternion.Euler(0, 0, -70);
        Debug.Log("Arma rotada a -70 grados");

        yield return new WaitForSeconds(maxCooldownTime * 0.9f);

        gfx.localRotation = Quaternion.Euler(0, 0, 0);
        Debug.Log("Arma revertida a 0 grados");

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
