using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class preguntas : MonoBehaviour
{
    public Button True, False;
    private int[] receivedNumbers;
    public TextMeshProUGUI Question_txt;
    private bool isQuestionAnswered;
    int Counter;
    public Canvas Preguntas;
    public string[] Questionario = new string[]{
        "Test_true",
        "Test_false",
        "Test_true",
        "Test_false",
        "Test_true",
        "Test_false"
    };
    public bool[] Results = new bool[]{
        true,
        false,
        true,
        false,
        true,
        false,
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
        // Mostrar la pregunta y resetear los colores de los botones cada vez que se active el canvas
        DisplayQuestion();
        ResetButtons();

    }
    public void ReceiveNumbers(int[] numbers)
    {
        receivedNumbers = numbers;

    }

    public void UpdateCounter(int count)
    {
        Counter = count;
        Debug.Log("pregunta no." + (Counter+1));
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
        Question_txt.text = Questionario[receivedNumbers[Counter]];

        // Imprimir la respuesta correcta para la pregunta actual
        Debug.Log("Respuesta correcta para la pregunta actual: " + Results[receivedNumbers[Counter]]);
    }

    void AnswerQuestion(bool answer)
    {
        bool correctAnswer = Results[receivedNumbers[Counter]];
        // Validar la respuesta
        if (answer == correctAnswer)
        {
            Debug.Log("Respuesta correcta.");
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
            Debug.Log("Respuesta incorrecta.");
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

        // Iniciar la corrutina para cerrar el canvas
        StartCoroutine(Close(2f));
    }

    IEnumerator Close(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Preguntas.gameObject.SetActive(false);
    }
}
