using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player; // JUGADOR
    [SerializeField] float minHeight, maxHeight, minWidth, maxWidth; // LIMITES DE LA CAMARA

    public Transform farBackGround; // Referencia al fondo lejano
    private Vector3 previousCameraPosition;

    // Agregar factores de desplazamiento individuales para X y Y
    [SerializeField] float parallaxEffectMultiplierX = 0.5f;
    [SerializeField] float parallaxEffectMultiplierY = 0.5f;

    void Start()
    {
        previousCameraPosition = transform.position;
    }

    void Update()
    {
        // FIJAR CAMARA AL JUGADOR EN EL EJE X E Y
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
