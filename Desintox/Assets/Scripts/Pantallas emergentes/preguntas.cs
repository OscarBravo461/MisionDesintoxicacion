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
    public Canvas Preguntas;
    public string[] Questionario = new string[]{
    "�Las drogas en M�xico se declararon ilegales en el a�o 1940?",
    "El t�rmino �adicciones� se refiere solo al abuso y consumo de sustancias tales como el tabaco, la bebida y las drogas",
    "�M�xico cuenta con Centro de Atenci�n Ciudadana contra las Adicciones?",
    "Realizar de forma constante y excesiva actividades como: el ejercicio, los videojuegos y redes sociales, �cuenta como adicciones?",
    "�Jugar constantemente juegos de azar en casinos se puede considerar una adicci�n?",
    "�Jugar a videojuegos, juegos de azar y pasar el rato en redes sociales  son actividades que directamente vuelven adictos a las personas?",
    "�El �cido sulf�rico puede utilizarse para la elaboraci�n de drogas como la coca�na?",
    "�El �cido acetil salic�lico es el nombre cient�fico de la marihuana?",
    "No pasa nada si s�lo se consumen drogas los fines de semana",
    "�Las personas con dependencia a las drogas tomaron una decisi�n equivocada?",
    "�SI TOMO MUCHO ALCOHOL ME HAR� MENOS RESISTENTE?",
    "�PARA PASARLO BIEN HAY QUE BEBER ALCOHOL?",
    "�UNA INTOXICACI�N GRAVE CON ALCOHOL PUEDE PRODUCIR LA MUERTE?",
    "�EL ALCOHOL BAJA LA TEMPERATURA CORPORAL?",
    "�EL CONSUMO DE MARIHUANA NO HACE DA�O?",
    "�EL ALCOHOL MATA NEURONAS?",
    "�EL CONSUMO EN EDAD TEMPRANO TIENE CONSECUENCIAS?",
    "MIENTRAS M�S JOVEN SE COMIENCE A CONSUMIR DROGAS, M�S PROBABILIDADES HAY DE SER DEPENDIENTE",
    "�EL ALCOHOL NOS PONE �BIEN HAPPY 'S�?",
    "LA MARIHUANA NO AFECTA LOS PULMONES"
    };
    public string[] Facts = new string[]{
    ": En 1940, �ltimo a�o de su mandato como presidente, L�zaro C�rdenas promulg� un Reglamento Federal de Toxicoman�as en el que se eliminaron diversos decretos punitivos que consideraban el consumo, posesi�n y venta de drogas como un delito.",
    ": La adicci�n es una enfermedad neurol�gica que se caracteriza por una b�squeda patol�gica de la recompensa o alivio a trav�s del uso de una sustancia u otras acciones.",
    ": En el Centro de Atenci�n Ciudadana contra las Adicciones un grupo de especialistas te escucha para ofrecerte: Prevenci�n y atenci�n del consumo de sustancias adictivas y orientaci�n a sus familiares. Tratamiento breve para dejar de fumar. Entre otros servicios.",
    ": El riesgo de caer en una adicci�n es parte de la vida. Lo que sucede es que a veces no lo percibimos. Los seres humanos podemos crear dependencia hacia cualquier cosa, incluso hacia el f�tbol, se�ala el doctor Hugo Espa�a, toxic�logo y especialista en adicciones.",
    ": La ludopat�a es un trastorno de orden psicol�gico que lleva a la persona a jugar y apostar repetidamente en un casino u otro sistema de apuestas, afectando de forma negativa a la vida personal, familiar y vocacional. Tambi�n se aplica a la adicci�n patol�gica a los juegos electr�nicos en general.",
    ": Se ha demostrado que estas actividades por s� mismas no generan dependencia, ludopat�a o adicci�n y si bien se registran casos que ligan a estas actividades la realidad es que casi cualquier actividad sin medida puede generar adicci�n en una persona.",
    ": El �cido sulf�rico, acetona, permanganato de potasio, etc. Es extra�do hasta su forma final en coca�na (clorhidrato de coca�na).",
    ": El �cido acetilsalic�lico o AAS, conocido popularmente como aspirina, nombre de una marca que pas� al uso com�n, es un f�rmaco de la familia de los salicilatos. Se utiliza como medicamento para tratar el dolor, la fiebre y la inflamaci�n, debido a su efecto inhibidor, no selectivo, de la ciclooxigenasa.",
    ": Debe recordarse que algunos efectos graves del consumo como es el caso del �golpe de calor� son independientes del tiempo que se lleve consumiendo. Por otra parte, consumir todos los fines de semana conlleva un riesgo evidente. Adem�s hay que tener en cuenta que los efectos del fin de semana se prolongan durante varios d�as.",
    ": Desde el 2019, los Estados Miembro de las Naciones Unidas han reconocido que la dependencia a las drogas es un asunto de salud p�blica relacionado con m�ltiples factores. Esto significa que existen diversas variables que incrementan la posibilidad de que alguien comience a utilizar drogas o desarrolle problemas de salud mental por su consumo.",
    ": El consumir frecuentemente el alcohol te generar� una resistencia cada vez m�s fuerte al punto donde no ser� suficiente con unas pocas copas.",
    ": El alcohol produce una �buena onda� temporal, que termina cuando se acaba el efecto. Beber en exceso puede traer un buen momento, pero luego podemos sentirnos cansados, deprimidos o nerviosos. Unas copas de m�s a veces puede traernos una �buena resaca�.",
    ": Si la intoxicaci�n es grave, existe un alto riesgo de morir, ya que puede causar par�lisis respiratoria y compromiso cardiovascular. Tambi�n puede provocar p�rdida de conocimiento, problemas respiratorios, gastritis cr�nica y alterar el funcionamiento del h�gado, lo que puede llevar finalmente a una cirrosis hep�tica. Adem�s puede provocar una hepatitis aguda que eventualmente puede causar la muerte.",
    ": Al llegar al cerebro el alcohol activa unos centros que causan ca�da en la temperatura corporal; por eso, la hipotermia es una de las consecuencias m�s r�pidas y contundentes del consumo de alcohol.",
    ": La marihuana puede generar dependencia. Su consumo produce dificultades en la capacidad de aprendizaje, problemas de concentraci�n, altera la memoria inmediata y desmotiva.",
    ": S� se ha comprobado que el alcohol causa degeneraci�n neuronal y dificulta la comunicaci�n entre las neuronas.",
    ": El consumo temprano tiene consecuencias graves en ni�os, ni�as y adolescentes, y se debe evitar en todas las circunstancias.",
    ": Diversas investigaciones se�alan que mientras m�s temprano se inicie el consumo de drogas, m�s probabilidades hay de generar una adicci�n (dependencia de las drogas). Esto se debe a que el organismo joven se encuentra en desarrollo y, por lo tanto, es m�s vulnerable a los efectos de las drogas.",
    ": El alcohol hace que la gente se desinhiba, pero hay quienes al beber tienen reacciones negativas que pueden provocar problemas con la ley, violencia, conflictos con la familia, la pareja o en el trabajo.",
    ": La marihuana afecta los pulmones porque el humo se retiene en ellos, conteniendo mon�xido de carbono. Esto inflama los pulmones y produce riesgos de contraer enfermedades como la neumon�a, bronquitis cr�nica, etc."
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

    int Counter=0;
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

        }
    }

    void AnswerQuestion(bool answer)
    {
        bool correctAnswer = Results[receivedNumbers[Counter]];
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
