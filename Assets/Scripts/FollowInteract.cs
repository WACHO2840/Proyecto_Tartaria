/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowInteract : MonoBehaviour
{
    public Transform player; // Arrastra aquí el Transform del jugador
    public Canvas canvas;    // Arrastra aquí el Canvas
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && canvas != null)
        {
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(player.position + new Vector3(1f, 1f, 0)); // Ajusta 1.2f para cambiar la altura
            transform.position = screenPosition;
        }
    }
}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowInteract : MonoBehaviour
{
    public Transform player; // Arrastra aquí el Transform del jugador o se buscará automáticamente
    public Canvas canvas;    // Arrastra aquí el Canvas

    private Text interactText;

    private void Start()
    {
        interactText = GetComponent<Text>();

        if (interactText == null)
        {
            Debug.LogError("El componente Text no se encontró en el objeto");
            return;
        }

        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
                Debug.Log("Player encontrado y asignado: " + player.name);
            }
            else
            {
                Debug.LogWarning("No se encontró un objeto con el tag 'Player'");
            }
        }

        interactText.enabled = false; // Asegurarse de que el texto esté desactivado al inicio
    }

    private void Update()
    {
        if (player != null && canvas != null)
        {
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(player.position + new Vector3(1f, 1f, 0)); // Ajusta 1f para cambiar la altura
            interactText.transform.position = screenPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.enabled = true; // Mostrar texto al entrar en el rango
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.enabled = false; // Ocultar texto al salir del rango
        }
    }
}
