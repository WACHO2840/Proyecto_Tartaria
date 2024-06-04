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
        hp = maxHp;
        winGame = FindWinGame();
        if (winGame == null)
        {
            Debug.LogError("No se encontró el script WinGame en la escena.");
        }
    }

    private void Update()
    {
        if (hp <= 0)
        {
            if (CompareTag("Boss") && winGame != null)
            {
                Die();
                winGame.WinScreenSet();
            }
            else if (CompareTag("Enemy"))
            {
                Die();
            }
        }
    }

    public int GetHp()
    {
        return hp;
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public void ReduceHp(float damage)
    {
        hp -= (int)damage;
        Debug.Log("Vida restante del enemigo: " + hp);
    }

    private void Die()
    {
        Debug.Log("Enemigo muerto");
        Destroy(gameObject);
    }

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
