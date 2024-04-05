using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;


public class cameraControl : MonoBehaviour
{
    // public Transform target;

    // // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     // Actualiza la posici�n de la c�mara para que coincida con la posici�n del objetivo,
    //     // pero mant�n la misma coordenada Y y Z que ya tiene la c�mara.
    //     transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    // }

     public Transform target; // Referencia al transform del objetivo (personaje)

    // Variables de desplazamiento de la cámara
    public float smoothSpeed = 0.125f; // Velocidad de suavizado del seguimiento
    public Vector3 offset; // Desplazamiento adicional de la cámara respecto al objetivo

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la posición deseada de la cámara sumando el offset al position del target
            Vector3 desiredPosition = target.position + offset;

            // Interpolación suave entre la posición actual de la cámara y la posición deseada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Establece la nueva posición de la cámara
            transform.position = smoothedPosition;
        }
    }
}