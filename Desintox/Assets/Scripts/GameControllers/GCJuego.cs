using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCJuego : MonoBehaviour
{
    //RandomsUnity -->  https://rusbenguzman.medium.com/generating-random-numbers-in-unity-spanish-ddd63e7795e
    private int[] uniqueNumbers = new int[6];
    public Canvas preguntas;
    private int Counter = -1;

    void Start()
    {
        uniqueNumbers = GenerateUniqueNumbers();
    }

    int[] GenerateUniqueNumbers()
    {
        int[] numbers = { 0, 1, 2, 3, 4, 5};
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
        if (Input.GetKeyDown(KeyCode.V)&& Counter<(uniqueNumbers.Length-1))
        {
            bool isActive = !preguntas.gameObject.activeSelf;
            if (preguntas != null)
            {
                preguntas.gameObject.SetActive(true);
            }
            if (isActive)
            {
                Counter++;
            }
        }

        preguntas sender = FindObjectOfType<preguntas>();//envia el arreglo
        if (sender != null)
        {
            sender.ReceiveNumbers(uniqueNumbers);
        }
    }
}
