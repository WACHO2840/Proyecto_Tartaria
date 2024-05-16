using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player; // JUGADOR
    [SerializeField] float minHeight, maxHeight, minWidth, maxWidth; // LIMITES DE LA CAMARA

    void Update()
    {
        if (player != null)
        transform.position = new Vector3(Mathf.Clamp(player.position.x, minWidth, maxWidth), Mathf.Clamp(player.position.y, minHeight, maxHeight), transform.position.z); // FIJAR CAMARA AL JUGADOR EN EL EJE X E Y
        else
        transform.position = new Vector3(0, 0, 0);
    }
}
