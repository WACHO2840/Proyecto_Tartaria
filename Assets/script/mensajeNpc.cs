using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class mensajeNpc : MonoBehaviour
{
    private bool isPlayerRange; // Indica si el jugador está dentro del rango del NPC
    [SerializeField] private GameObject animacionNpc; // Referencia al objeto de animación del NPC
    [SerializeField, TextArea(4, 6)] private String[] dialogoLineas; // Array del diálogo del NPC
    [SerializeField] private GameObject dialogoPanel; //panel de diálogo
    [SerializeField] private TMP_Text dialogoTexto; //texto de diálogo en formato TextMeshPro

    private float tiempo = 0.05f; // Tiempo entre cada letra que aparece en el texto

    private bool didDialogueStar; // Indica si el diálogo ha comenzado
    private int lineaIndex; // Índice actual de la línea de diálogo que se está mostrando

    void Update()
    {
        // Verifica si el jugador está en rango y presiona el botón de interacción ("Fire1")
        // Fire1 -> click derecho
        // Fire2 -> click izquierdo
        if (isPlayerRange && Input.GetButtonDown("Fire1"))
        {
            if (!didDialogueStar) // Si el diálogo no ha comenzado
            {
                InicioDialogo(); // Comienza el diálogo
            }
            else if (dialogoTexto.text == dialogoLineas[lineaIndex]) // Si se ha mostrado toda la línea actual
            {
                SiguienteFrase(); // Muestra la siguiente línea de diálogo
            }
            else
            {
                StopAllCoroutines(); // Detiene todas las corrutinas (detener la animación de mostrar letra por letra)
                dialogoTexto.text = dialogoLineas[lineaIndex]; // Muestra la línea completa de una vez
            }
        }
    }

    private void InicioDialogo()
    {
        didDialogueStar = true; // Marca que el diálogo ha comenzado
        dialogoPanel.SetActive(true); // Activa el panel de diálogo
        animacionNpc.SetActive(false); // Desactiva la animación del NPC mientras habla
        lineaIndex = 0; // Inicia desde la primera línea de diálogo
        Time.timeScale = 0f; // Pausa el tiempo en el juego (para detener el movimiento del jugador)
        StartCoroutine(ShowLine()); // Inicia la corrutina para mostrar letra por letra la línea de diálogo
    }

    private void SiguienteFrase()
    {
        lineaIndex++; // Avanza al siguiente índice de línea de diálogo
        if (lineaIndex < dialogoLineas.Length) // Verifica si hay más líneas de diálogo por mostrar
        {
            StartCoroutine(ShowLine()); // Muestra la siguiente línea de diálogo letra por letra
        }
        else
        {
            didDialogueStar = false; // Marca que el diálogo ha terminado
            dialogoPanel.SetActive(false); // Desactiva el panel de diálogo
            animacionNpc.SetActive(true); // Reactiva la animación del NPC
            Time.timeScale = 1f; // Reanuda el tiempo en el juego
        }
    }

    private IEnumerator ShowLine()
    {
        dialogoTexto.text = string.Empty; // Borra el texto actual del diálogo

        foreach (char ch in dialogoLineas[lineaIndex]) // Recorre cada letra de la línea de diálogo actual
        {
            dialogoTexto.text += ch; // Agrega la letra al texto de diálogo
            yield return new WaitForSecondsRealtime(tiempo); // Espera un tiempo antes de mostrar la siguiente letra
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // El jugador esta creado bajo el nombre de player
        if (collision.gameObject.CompareTag("Player")) // Verifica si el objeto que entra es el jugador
        {
            isPlayerRange = true; // Establece que el jugador está dentro del rango del NPC
            animacionNpc.SetActive(true); // Activa la animación del NPC

            // pruebas de Debug para salida de consola
            // Debug.Log("Dialogo"); // Muestra un mensaje de depuración (para verificar el inicio del diálogo)
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Verifica si el objeto que sale es el jugador
        {
            isPlayerRange = false; // Establece que el jugador está fuera del rango del NPC
            animacionNpc.SetActive(false); // Desactiva la animación del NPC
                                           // pruebas de Debug para salida de consola
            // Debug.Log("Dialogo"); // Muestra un mensaje de depuración (para verificar el fin del diálogo)
        }
    }
}
