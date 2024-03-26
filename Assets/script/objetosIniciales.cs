using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetosIniciales : MonoBehaviour
{
    public GameObject objeto1;
    public GameObject objeto2;

    private GameObject objetoSeleccionado;

    // Start is called before the first frame update
    void Start()
    {
        // Al inicio, ninguno de los objetos está seleccionado
        objetoSeleccionado = null;
    }

    // Método para seleccionar el primer objeto
    public void SeleccionarObjeto1()
    {
        objetoSeleccionado = objeto1;
        objeto2.SetActive(false); // Desactivar objeto2 para evitar su selección
    }

    // Método para seleccionar el segundo objeto
    public void SeleccionarObjeto2()
    {
        objetoSeleccionado = objeto2;
        objeto1.SetActive(false); // Desactivar objeto1 para evitar su selección
    }

    // Método para deseleccionar el objeto seleccionado
    public void DeseleccionarObjeto()
    {
        // Reactivar ambos objetos
        objeto1.SetActive(true);
        objeto2.SetActive(true);
        objetoSeleccionado = null;
    }

    // Método para obtener el objeto seleccionado
    public GameObject ObtenerObjetoSeleccionado()
    {
        return objetoSeleccionado;
    }
}