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

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        player = playerMovement.transform;
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, minWidth, maxWidth), Mathf.Clamp(player.position.y, minHeight, maxHeight), transform.position.z); // FIJAR CAMARA AL JUGADOR 
    }
}
