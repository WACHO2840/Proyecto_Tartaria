using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereControll : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float minHeight, maxHeight, minWidth, maxWidth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, minWidth, maxWidth), Mathf.Clamp(player.position.y, minHeight, maxHeight), transform.position.z); // Fijar camara al jugador con limites verticales
    }
}
