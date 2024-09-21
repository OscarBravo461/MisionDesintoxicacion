using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class OpcionMulti_T3 : MonoBehaviour
{
    //Declaracion de todos los objetos del canvas que se utilizaran
    public Button btt1, btt2, btt3, btt4;
    public TextMeshProUGUI pregutext, op1, op2, op3, op4;
    public Canvas Multi_op;
    //p representa la pregunta o respuesta que se ejecutara en ese turno seleccionada aleatoriamente mas adelante
    public int p;
    //array con todas las preguntas
    public string[] Questionario = new string[]{
    "¿Qué son las drogas?","¿A qué edad (promedio) empiezan las adicciones a las drogas?","¿Cuál es la razón por la que es difícil dejar una adicción?",
        "¿Cuál droga es la más conocida en México?","¿Cuántas muertes al año hay por el uso de drogas en México?","¿Quién es más propenso a consumir drogas?",
        "¿Cuando se consumen drogas siendo menor afecta diferentes aspectos como?","¿El síndrome de abstinencia se produce cuando?","¿Cual de las siguientes sustancias son ilegales?",
        "¿Cuando el consumó de drogas se vuelve problemático?","¿Qué síntomas nocivos para la salud crea el vapeo y el cigarro?","¿Qué es la sibilancia?",
        "¿Cómo se puede dar la sibilancia?","¿El vapeo puede dañar el ambiente?","¿Qué pasa con el cerebro cuando una persona usa drogas","¿Qué funciones son afectadas por el uso de las drogas?",
        "¿Qué problemas causa fumar tabaco?","¿Qué problemas da el fumar embarazada o fumar cerca de una persona embarazada?","¿Qué es el alcoholismo?","¿Qué problemas causa el alcoholismo?"
    };
    //array bidimensional con todas las respuesta
    public string[,] Respuestas = {
         { "Son sustancias que cambian que modifican y alteran los sentidos","20a","30a","40a"}
        ,{ "15 años","24 años","13 años", "10 años"}
        ,{ "Sindrome de abstinencia","20a","30a", "40a"}
        ,{ "Marihuana y la cocaína","20a","30a", "40a"}
        ,{ "Más de 53k","Menos de 10k","Más de 212k", "Ninguna"}
        ,{ "Los adolescentes","Todos los jóvenes","Los adultos", "Todas las personas"}
        ,{ "El desarrollo físico y psicológico de los jóvenes","20a","30a", "40a"}
        ,{ "10a","Deja de consumir la sustancia a la que es adicto","30a", "40a"}
        ,{ "Todas las anteriores","Extasis","Alcohol, tabaco y café", "Pan dulce"}
        ,{ "Todas son correctas","Cuando afecta su forma de vida","Cuando afecta tu salud", "Cuando afecta tus relaciones sociales y familiares"}
        ,{ "dado a su nicotina sus efectos nocivos son tos, sibilancia, náuseas, vómitos, dolores de cabeza y mareos","20a","30a", "40a"}
        ,{ "son problemas respiratorios","Son problemas problemosos","Es un silbido", "Es un pitido en el oído"}
        ,{ "Por medio del consumo de tabaco y Vape","no se que es sibilancia","Consumo excesivo de alcohol", "Un exceso de sibila"}
        ,{ "Si","20a","30a", "40a"}
        ,{ "La mayoría de las drogas afectan el circuito de recompensa del cerebro","20a","30a", "40a"}
        ,{ "El aprendizaje, el criterio, la capacidad de tomar decisiones, el estrés, la memoria y el comportamiento","20a","30a", "40a"}
        ,{ "Puede provocar cáncer","Puede relajarte","Olerás a rosas", "Puede provocar agresividad"}
        ,{ "Un parto prematuro, puede nacer el bebé con bajo peso, síndrome de muerte súbita del lactante, asma y problemas pulmonares en el bebe","20a","30a", "40a"}
        ,{ "Es la manera de ser feliz","No se","Incapacidad de dejar el alcohol", "40a"}
        ,{ "Alta presión arterial","Enfermedad cardiaca","Enfermedad del hígado", "Problemas digestivos"}
    };
    //Este arreglo tiene el dato que opcion de las respuesta es la correcta
    public int[] correcta = { 1, 1, 1, 1, 1, 1, 1, 1, 2, 3, 1, 1, 1, 1, 1, 1, 1, 1, 3, 3 };
    //tiempo de espera despues de contestar en lo que se cierra la ventana
    public float waitTime = 5f;
    
    void Start()
    {

    }

    void Update()
    {
        //activa el evento con la letra b
        if (Input.GetKeyDown(KeyCode.B))
        {
            Multi_op.gameObject.SetActive(true);
            empiezar();
            reinicio();
        }
    }
    //Selecciona la pregunta y la escribe junto con sus respuesta
    public void empiezar()
    {
        int p = UnityEngine.Random.Range(0, 20);
        pregutext.text = (Questionario[p]);
        op1.text = (Respuestas[p, 0]);
        op2.text = (Respuestas[p, 1]);
        op3.text = (Respuestas[p, 2]);
        op4.text = (Respuestas[p, 3]);

    }
    //Determina si la respuesta de cada boton es correcta o incorrecta
    public void bt1()
    {
        if (correcta[p] == 1)
        {
            Debug.Log("ACERTASTE");
            descativar();
            color();
        }
        else
        {
            Debug.Log("Fallaste");
            descativar();
            color();
        }
        StartCoroutine(Close(waitTime));
    }
    public void bt2()
    {
        if (correcta[p] == 2)
        {
            Debug.Log("ACERTASTE");
            descativar();
            color();

        }
        else
        {
            Debug.Log("Fallaste");
            descativar();
            color();
        }
        StartCoroutine(Close(waitTime));
    }
    public void bt3()
    {
        if (correcta[p] == 3)
        {
            Debug.Log("ACERTASTE");
            descativar();
            color();
        }
        else
        {
            Debug.Log("Fallaste");
            descativar();
            color();
        }
        StartCoroutine(Close(waitTime));
    }
    public void bt4()
    {
        if (correcta[p] == 4)
        {
            Debug.Log("ACERTASTE");
            descativar();
            color();
        }
        else
        {
            Debug.Log("Fallaste");
            descativar();
            color();
        }
        StartCoroutine(Close(waitTime));
    }
    //Segun cual sea la respuesat correcta le pone un color  al boton, rojo incorrecto, verde correcto
    public void color()
    {
        switch(correcta[p])
        {
            case 1:
                btt1.image.color = Color.green;
                btt2.image.color = Color.red;
                btt3.image.color = Color.red;
                btt4.image.color = Color.red;
                break;
            case 2:
                btt2.image.color = Color.green;
                btt1.image.color = Color.red;
                btt3.image.color = Color.red;
                btt4.image.color = Color.red;
                break;
            case 3:
                btt3.image.color = Color.green;
                btt1.image.color = Color.red;
                btt2.image.color = Color.red;
                btt4.image.color = Color.red;
                break;
            case 4:
                btt4.image.color = Color.green;
                btt1.image.color = Color.red;
                btt2.image.color = Color.red;
                btt3.image.color = Color.red;
                break;
        }
    }
    //Desactiva los botones despues de presionarlos
    public void descativar()
    {
        btt1.enabled = false;
        btt2.enabled = false;
        btt3.enabled = false;
        btt4.enabled = false;
    }
    //reinicia el color de los botones y los vuelve a activar
    public void reinicio()
    {
        btt1.enabled = true;
        btt2.enabled = true;
        btt3.enabled = true;
        btt4.enabled = true;
        btt1.image.color = Color.white;
        btt2.image.color = Color.white;
        btt3.image.color = Color.white;
        btt4.image.color = Color.white;

    }
    //cierra la ventana del evento
    IEnumerator Close(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Multi_op.gameObject.SetActive(false);
    }
}
