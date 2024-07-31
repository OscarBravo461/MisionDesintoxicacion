using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preguntas : MonoBehaviour
{
    public GameObject True, False;
    private int[] receivedNumbers;
    private int Counter;

    public void ReceiveNumbers(int[] numbers)
    {
        receivedNumbers = numbers;
        ProcessNumbers();
    }

    void ProcessNumbers()
    {
        foreach (int number in receivedNumbers)
        {
            //Debug.Log("Received number: " + number);
        }
    }
    public void UpdateCounter(int count)
    {
        Counter = count;
        Debug.Log("pregunta no." + Counter);
    }
}
