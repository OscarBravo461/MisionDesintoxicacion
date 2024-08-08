using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCJuego : MonoBehaviour
{
    //RandomsUnity -->  https://rusbenguzman.medium.com/generating-random-numbers-in-unity-spanish-ddd63e7795e
    public int[] uniqueNumbers = new int[20];
    public Canvas preguntas;
    public int Counter = 0;

    void Start()
    {
        uniqueNumbers = GenerateUniqueNumbers();
    }

    public int[] GenerateUniqueNumbers()
    {
        int[] numbers = { 0, 1, 2, 3, 4, 5,6,7,8,9,10,11,12,13,14,15,16,17,18,19};
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
        if (Input.GetKeyDown(KeyCode.V)&& Counter<(uniqueNumbers.Length))
        {
            bool isActive = !preguntas.gameObject.activeSelf;
            if (preguntas != null)
            {
                preguntas.gameObject.SetActive(true);
            }
            if (isActive)
            {
                Counter++;
                if (Counter >= uniqueNumbers.Length)
                {
                    uniqueNumbers = GenerateUniqueNumbers();
                    Counter = 0;
                }

            }
        }

        preguntas sender = FindObjectOfType<preguntas>();//envia el arreglo
        if (sender != null)
        {
            sender.ReceiveNumbers(uniqueNumbers);
        }
    }
}
