using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPopUp : MonoBehaviour
{

    public GameObject interactKeyUI;
    // Start is called before the first frame update
    void Start()
    {
        interactKeyUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactKeyUI.SetActive(true);
        }
        else
        {
            interactKeyUI.SetActive(false);
        }
    }

    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactKeyUI.SetActive(false);
        }
    }*/
}
