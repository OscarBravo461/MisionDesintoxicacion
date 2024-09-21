using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpcionMulti_T3 : MonoBehaviour
{
    public Button True, False, Surrender;
    private int[] receivedNumbers;
    public TextMeshProUGUI Question_txt;
    public Canvas Preguntas;
    public string[] Questionario = new string[]{
    "1","2","3","4","5","6","7","8","9","0"
    };
    public string[,] Facts = {
    { "10a","20a","30a "},{ "10a","20a","30a "},{ "10a","20a","30a "}
    };
    public bool[] Results = new bool[]{
    true,
    false,
    true,
    true,
    true,
    false,
    true,
    false,
    false,
    false,
    false,
    true,
    true,
    true,
    false,
    true,
    true,
    true,
    false,
    false
    };
    [Range(0.1f, 10f)]// <= Hacer variable tipo barra de volumen
    public float waitTime = 15f;
    int Counter = 0;
    void Start()
    {
        Surrender.gameObject.SetActive(false);
        // Asignar eventos a los botones
        True.onClick.AddListener(() => AnswerQuestion(true));
        False.onClick.AddListener(() => AnswerQuestion(false));
        Surrender.onClick.AddListener(() => StartCoroutine(Close(0))); //probablemente esto se cambie a futuro,si llega a haber penalizaciones por rendirse
        DisplayQuestion();
    }
    void OnEnable()
    {
        ResetButtons();
        DisplayQuestion();
    }
    public void ReceiveNumbers(int[] numbers)
    {
        receivedNumbers = numbers;
    }

    void ResetButtons()
    {
        True.image.color = Color.white;
        False.image.color = Color.white;
        True.interactable = true;
        False.interactable = true;
    }
    void DisplayQuestion()
    {
        if (receivedNumbers != null)
        {
            Question_txt.text = Questionario[receivedNumbers[Counter]];

        }
    }

    void AnswerQuestion(bool answer)
    {
        bool correctAnswer = Results[receivedNumbers[Counter]];
        // Validar la respuesta
        if (answer == correctAnswer)
        {
            Question_txt.text = "HECHO" + Facts[receivedNumbers[Counter]];
            if (answer)
            {
                True.image.color = Color.green;
            }
            else
            {
                False.image.color = Color.green;
            }
        }
        else
        {
            Question_txt.text = "HECHO" + Facts[receivedNumbers[Counter]];
            if (answer)
            {
                True.image.color = Color.red;
            }
            else
            {
                False.image.color = Color.red;
            }
        }
        True.interactable = false;
        False.interactable = false;
        Counter++;
        if (Counter >= receivedNumbers.Length)
        {
            // Solicitar actualización de números
            GCJuego1 juego = FindObjectOfType<GCJuego1>(); // Asegúrate de que el nombre de la clase sea correcto
            if (juego != null)
            {
                juego.uniqueNumbers = juego.GenerateUniqueNumbers(); // Genera nuevos números
                juego.Counter = 0; // Reiniciar el contador en GCJuego
                ReceiveNumbers(juego.uniqueNumbers); // Actualiza el arreglo recibido
            }
            Counter = 0; // Reinicia el contador local si es necesario
        }

        // Iniciar la corrutina para cerrar el canvas
        StartCoroutine(Close(waitTime));
    }

    IEnumerator Close(float waitTime)
    {
        Surrender.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        Preguntas.gameObject.SetActive(false);
    }
}
