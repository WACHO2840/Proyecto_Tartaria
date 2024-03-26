using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;


public class cameraControl : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Actualiza la posición de la cámara para que coincida con la posición del objetivo,
        // pero mantén la misma coordenada Y y Z que ya tiene la cámara.
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
