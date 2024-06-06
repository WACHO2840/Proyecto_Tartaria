using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerUI : MonoBehaviour
{
    public Transform player; // GameObject Jugador
    public Canvas canvas;    // GameObject Canvas

    void Update()
    {
        if (player != null && canvas != null)
        {
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(player.position + new Vector3(1f, 1f, 0)); // Ajusta 1.2f para cambiar la altura
            transform.position = screenPosition;
        }
    }
}
