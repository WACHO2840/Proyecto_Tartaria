using UnityEngine;

public class KeepOnLoad : MonoBehaviour
{
    private void Awake()
    {
        // Verifica si este GameObject es el GameObject raíz
        if (transform.parent == null)
        {
            // Si es el GameObject raíz, se mantiene activo en todas las escenas
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si no es el GameObject raíz, se destruye para evitar problemas
            Destroy(gameObject);
        }
    }
}
