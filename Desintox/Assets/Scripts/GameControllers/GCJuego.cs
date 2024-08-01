using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCJuego : MonoBehaviour
{
    //RandomsUnity -->  https://rusbenguzman.medium.com/generating-random-numbers-in-unity-spanish-ddd63e7795e
    public int size = 6;
    private int[] uniqueNumbers;
    public Canvas preguntas;
    private int Counter = -1;

    void Start()
    {
        // Generar el arreglo de números únicos
        uniqueNumbers = GenerateUniqueNumbers(size);

        // Mostrar los números únicos generados
        foreach (int number in uniqueNumbers)
        {
            Debug.Log(number);
        }
    }

    int[] GenerateUniqueNumbers(int size)
    {
        int[] numbers = new int[size];
        for (int i = 0; i < size; i++)
        {
            numbers[i] = i;
        }
        // Mezclar el arreglo
        for (int i = 0; i < numbers.Length; i++)
        {
            int temp = numbers[i];
            int randomIndex = Random.Range(i, numbers.Length);
            numbers[i] = numbers[randomIndex];
            numbers[randomIndex] = temp;
        }
        return numbers;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)&& Counter<uniqueNumbers.Length)
        {
            bool isActive = !preguntas.gameObject.activeSelf;
            if (preguntas != null)
            {
                preguntas.gameObject.SetActive(true);
            }
            if (isActive)
            {
                Counter++;
                Debug.Log("Canvas opened " + (Counter+1)+ " times");

                // Enviar el conteo al otro script
                preguntas otherScript = FindObjectOfType<preguntas>();
                if (otherScript != null)
                {
                    otherScript.UpdateCounter(Counter);
                }
            }
        }

        preguntas sender = FindObjectOfType<preguntas>();
        if (sender != null)
        {
            sender.ReceiveNumbers(uniqueNumbers);
        }
    }
}
