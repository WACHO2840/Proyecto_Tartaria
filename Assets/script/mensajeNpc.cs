using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class mensajeNpc : MonoBehaviour
{
    private bool isPlayerRange;
    [SerializeField] private GameObject animacionNpc;
    [SerializeField, TextArea(4, 6)] private String[] dialogoLineas;
    [SerializeField] private GameObject dialogoPanel;

    [SerializeField] private TMP_Text dialogoTexto;

    private float tiempo = 0.05f;

    private bool didDialogueStar;
    private int lineaIndex;

    void Update()
    {
        if (isPlayerRange && Input.GetButtonDown("Fire1"))
        {
            if (!didDialogueStar)
            {
                InicioDialogo();
            }
            else if (dialogoTexto.text == dialogoLineas[lineaIndex])
            {
                SiguienteFrase();
            }
            else
            {
                StopAllCoroutines();
                dialogoTexto.text = dialogoLineas[lineaIndex];
            }
        }
    }

    private void InicioDialogo()
    {
        didDialogueStar = true;
        dialogoPanel.SetActive(true);
        animacionNpc.SetActive(false);
        lineaIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void SiguienteFrase()
    {
        lineaIndex++;
        if (lineaIndex < dialogoLineas.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStar = false;
            dialogoPanel.SetActive(false);
            animacionNpc.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogoTexto.text = string.Empty;

        foreach (char ch in dialogoLineas[lineaIndex])
        {
            dialogoTexto.text += ch;
            yield return new WaitForSecondsRealtime(tiempo);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            isPlayerRange = true;
            animacionNpc.SetActive(true);
            Debug.Log("Dialogo");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerRange = false;
            animacionNpc.SetActive(false);
            Debug.Log("Dialogo");
        }
    }
}