using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMochilaContents : MonoBehaviour
{
    private Collider2D playerCollider;

    void Update()
    {
        if (playerCollider != null && Input.GetKeyDown(KeyCode.E))
        {
            DisplayMochilaContents();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollider = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollider = null;
        }
    }

    private void DisplayMochilaContents()
    {
        Debug.Log("Contenido actual de la mochila:");
        foreach (var item in PickUp.mochila)
        {
            Debug.Log(item.Name);
        }
    }
}
