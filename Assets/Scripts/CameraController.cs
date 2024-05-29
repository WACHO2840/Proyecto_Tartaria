using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region VARIABLES   
    [SerializeField] private float minHeight, maxHeight, minWidth, maxWidth; // LIMITES DE LA CAMARA
    private PlayerMovement playerMovement;
    private Transform player; // POSICION DEL JUGADOR
    #endregion

    // Nuevas variables para el fondo
    public Transform farBackGround; // Referencia al fondo lejano
    private Vector3 previousCameraPosition;

    // Factores de desplazamiento individuales para X y Y
    [SerializeField] private float parallaxEffectMultiplierX = 0.5f;
    [SerializeField] private float parallaxEffectMultiplierY = 0.5f;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        player = playerMovement.transform;

        // Inicializar la posición anterior de la cámara
        previousCameraPosition = transform.position;
    }

    void Update()
    {
        if (player != null) // Comprobar que el jugador exista
        {
            Vector3 newCameraPosition = new Vector3(
                Mathf.Clamp(player.position.x, minWidth, maxWidth),
                Mathf.Clamp(player.position.y, minHeight, maxHeight),
                transform.position.z
            );

            // Calcular la cantidad de movimiento en X y Y
            Vector3 deltaMovement = newCameraPosition - previousCameraPosition;

            // Aplicar los factores de desplazamiento al fondo
            farBackGround.position += new Vector3(deltaMovement.x * parallaxEffectMultiplierX, deltaMovement.y * parallaxEffectMultiplierY, 0f);

            // Actualizar la posición anterior de la cámara
            previousCameraPosition = newCameraPosition;

            // Actualizar la posición de la cámara
            transform.position = newCameraPosition;
        }
    }
}
