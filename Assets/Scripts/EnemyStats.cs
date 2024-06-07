using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    #region Variables
    [SerializeField] public int maxHp = 100;
    [SerializeField] public float movementSpeed = 3.0f;
    [SerializeField] public int dmg = 10;
    private int hp;
    #endregion

    private WinGame winGame;

    void Start()
    {
        // Inicializar vida y pantalla del final
        hp = maxHp;
        winGame = FindWinGame();
        if (winGame == null)
        {
            Debug.LogError("No se encontró el script WinGame en la escena.");
        }
    }

    private void Update()
    {
        // Comprobar si el enemigo esta muerto
        if (hp <= 0)
        {
            if (CompareTag("Boss") && winGame != null)
            {
                Die();
                // Lanzar pantalla de victoria
                winGame.WinScreenSet();
            }
            else if (CompareTag("Enemy"))
            {
                Die();
            }
        }
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public void ReduceHp(float damage)
    {
        // reducir vida tras golpe
        hp -= (int)damage;
        Debug.Log("Vida restante del enemigo: " + hp);
    }

    private void Die()
    {
        // Destruir GameObject
        Debug.Log("Enemigo muerto");
        Destroy(gameObject);
    }

    // Almacenar GameObjects de la escena
    private WinGame FindWinGame()
    {
        var dontDestroyOnLoadObjects = FindObjectsOfType<WinGame>(true);
        foreach (var obj in dontDestroyOnLoadObjects)
        {
            return obj;
        }
        return null;
    }
}
