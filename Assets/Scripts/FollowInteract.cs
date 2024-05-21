using System.Collections;
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
}