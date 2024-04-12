using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasNivelUno : MonoBehaviour
{
    public Transform object1;  // Primer objeto Transform
    public Transform object2;  // Segundo objeto Transform

    void Start()
    {
        // Aquí puedes inicializar o realizar acciones al comenzar el juego
    }

    void Update()
    {
        // Puedes realizar actualizaciones por frame si es necesario
    }

    // Método para seleccionar el objeto 1 y desactivar el objeto 2
    public void SelectObject1()
    {
        if (object1 != null && object2 != null)
        {
            object1.gameObject.SetActive(true);  // Activa el objeto 1
            object2.gameObject.SetActive(false); // Desactiva el objeto 2
        }
    }

    // Método para seleccionar el objeto 2 y desactivar el objeto 1
    public void SelectObject2()
    {
        if (object1 != null && object2 != null)
        {
            object1.gameObject.SetActive(false); // Desactiva el objeto 1
            object2.gameObject.SetActive(true);  // Activa el objeto 2
        }
    }

    // Método para obtener la posición del objeto activo (object1 o object2)
    public Vector3 GetActiveObjectPosition()
    {
        if (object1 != null && object1.gameObject.activeSelf)
            return object1.position;

        if (object2 != null && object2.gameObject.activeSelf)
            return object2.position;

        return Vector3.zero; // En caso de que ambos estén desactivados
    }
}
