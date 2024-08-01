using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class preguntas : MonoBehaviour
{
    public Button True, False;
    private int[] receivedNumbers;
    public TextMeshProUGUI Question_txt;
    private bool isQuestionAnswered;
    int Counter=0;
    public Canvas Preguntas;
    public string[] Questionario = new string[]{
        "Test_true",
        "Test_false",
        "Test_true",
        "Test_false",
        "Test_true",
    };
    public bool[] Results = new bool[]{
        true,
        false,
        true,
        false,
        true,
    };

    void Start()
    {
        // Asignar eventos a los botones
        True.onClick.AddListener(() => AnswerQuestion(true));
        False.onClick.AddListener(() => AnswerQuestion(false));
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
                Debug.Log($"Index: {receivedNumbers[Counter]}, Pregunta actual: {Questionario[receivedNumbers[Counter]]}, Respuesta correcta: {Results[receivedNumbers[Counter]]}");

        }
        else
        {
            Debug.LogError("receivedNumbers o Counter no están inicializados correctamente.");
        }

    }

    void AnswerQuestion(bool answer)
    {
        bool correctAnswer = Results[receivedNumbers[Counter]];
        Debug.Log($"Index: {receivedNumbers[Counter]}, Answer: {answer}, Correct Answer: {correctAnswer}");
        // Validar la respuesta
        if (answer == correctAnswer)
        {
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
        // Iniciar la corrutina para cerrar el canvas
        StartCoroutine(Close(2f));
       
    }

    IEnumerator Close(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Preguntas.gameObject.SetActive(false);
    }
}
