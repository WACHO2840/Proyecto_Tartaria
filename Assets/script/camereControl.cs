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
        // Actualiza la posici�n de la c�mara para que coincida con la posici�n del objetivo,
        // pero mant�n la misma coordenada Y y Z que ya tiene la c�mara.
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
