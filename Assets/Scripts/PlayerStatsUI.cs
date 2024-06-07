using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    public Text statsText; // Arrastra y suelta el Text aquí desde el inspector

    private PlayerAttack playerAttack;
    private PlayerHealth playerHealth;
    private ArmasGame armasGame;

    void Start()
    {
        playerAttack = FindObjectOfType<PlayerAttack>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        armasGame = FindObjectOfType<ArmasGame>();

        if (playerAttack == null || playerHealth == null || armasGame == null)
        {
            Debug.LogError("PlayerAttack o PlayerHealth no está adjunto al GameObject.");
        }
    }

    void Update()
    {
        UpdateStatsText();
    }
    //enseña en el canvas las estadisticas actuales del jugador
    void UpdateStatsText()
    {
        if (playerAttack != null && playerHealth != null)
        {
            statsText.text = $"Daño: {playerAttack.BasicDamage*2}\n" +
                             $"Velocidad de ataque: {playerAttack.BasicAttackSpeed}\n" +
                             $"Rango: {playerAttack.Range}\n" +
                             $"Vida: {playerHealth.GetCurrentHealth()}"; // Asegúrate de que 'health' sea accesible
        }
    }
}
