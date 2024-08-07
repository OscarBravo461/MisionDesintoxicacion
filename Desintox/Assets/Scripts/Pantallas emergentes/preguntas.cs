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
    "¿Las drogas en México se declararon ilegales en el año 1940?",
    "El término “adicciones” se refiere solo al abuso y consumo de sustancias tales como el tabaco, la bebida y las drogas",
    "¿México cuenta con Centro de Atención Ciudadana contra las Adicciones?",
    "Realizar de forma constante y excesiva actividades como: el ejercicio, los videojuegos y redes sociales, ¿cuenta como adicciones?",
    "¿Jugar constantemente juegos de azar en casinos se puede considerar una adicción?",
    "¿Jugar a videojuegos, juegos de azar y pasar el rato en redes sociales  son actividades que directamente vuelven adictos a las personas?",
    "¿El ácido sulfúrico puede utilizarse para la elaboración de drogas como la cocaína?",
    "¿El ácido acetil salicílico es el nombre científico de la marihuana?",
    "No pasa nada si sólo se consumen drogas los fines de semana",
    "¿Las personas con dependencia a las drogas tomaron una decisión equivocada?",
    "¿SI TOMO MUCHO ALCOHOL ME HARÉ MENOS RESISTENTE?",
    "¿PARA PASARLO BIEN HAY QUE BEBER ALCOHOL?",
    "¿UNA INTOXICACIÓN GRAVE CON ALCOHOL PUEDE PRODUCIR LA MUERTE?",
    "¿EL ALCOHOL BAJA LA TEMPERATURA CORPORAL?",
    "¿EL CONSUMO DE MARIHUANA NO HACE DAÑO?",
    "¿EL ALCOHOL MATA NEURONAS?",
    "¿EL CONSUMO EN EDAD TEMPRANO TIENE CONSECUENCIAS?",
    "MIENTRAS MÁS JOVEN SE COMIENCE A CONSUMIR DROGAS, MÁS PROBABILIDADES HAY DE SER DEPENDIENTE",
    "¿EL ALCOHOL NOS PONE “BIEN HAPPY 'S”?",
    "LA MARIHUANA NO AFECTA LOS PULMONES"
    };
    public string[] Facts = new string[]{
    ": En 1940, último año de su mandato como presidente, Lázaro Cárdenas promulgó un Reglamento Federal de Toxicomanías en el que se eliminaron diversos decretos punitivos que consideraban el consumo, posesión y venta de drogas como un delito.",
    ": La adicción es una enfermedad neurológica que se caracteriza por una búsqueda patológica de la recompensa o alivio a través del uso de una sustancia u otras acciones.",
    ": En el Centro de Atención Ciudadana contra las Adicciones un grupo de especialistas te escucha para ofrecerte: Prevención y atención del consumo de sustancias adictivas y orientación a sus familiares. Tratamiento breve para dejar de fumar. Entre otros servicios.",
    ": El riesgo de caer en una adicción es parte de la vida. Lo que sucede es que a veces no lo percibimos. Los seres humanos podemos crear dependencia hacia cualquier cosa, incluso hacia el fútbol, señala el doctor Hugo España, toxicólogo y especialista en adicciones.",
    ": La ludopatía es un trastorno de orden psicológico que lleva a la persona a jugar y apostar repetidamente en un casino u otro sistema de apuestas, afectando de forma negativa a la vida personal, familiar y vocacional. También se aplica a la adicción patológica a los juegos electrónicos en general.",
    ": Se ha demostrado que estas actividades por sí mismas no generan dependencia, ludopatía o adicción y si bien se registran casos que ligan a estas actividades la realidad es que casi cualquier actividad sin medida puede generar adicción en una persona.",
    ": El ácido sulfúrico, acetona, permanganato de potasio, etc. Es extraído hasta su forma final en cocaína (clorhidrato de cocaína).",
    ": El ácido acetilsalicílico o AAS, conocido popularmente como aspirina, nombre de una marca que pasó al uso común, es un fármaco de la familia de los salicilatos. Se utiliza como medicamento para tratar el dolor, la fiebre y la inflamación, debido a su efecto inhibidor, no selectivo, de la ciclooxigenasa.",
    ": Debe recordarse que algunos efectos graves del consumo como es el caso del “golpe de calor” son independientes del tiempo que se lleve consumiendo. Por otra parte, consumir todos los fines de semana conlleva un riesgo evidente. Además hay que tener en cuenta que los efectos del fin de semana se prolongan durante varios días.",
    ": Desde el 2019, los Estados Miembro de las Naciones Unidas han reconocido que la dependencia a las drogas es un asunto de salud pública relacionado con múltiples factores. Esto significa que existen diversas variables que incrementan la posibilidad de que alguien comience a utilizar drogas o desarrolle problemas de salud mental por su consumo.",
    ": El consumir frecuentemente el alcohol te generará una resistencia cada vez más fuerte al punto donde no será suficiente con unas pocas copas.",
    ": El alcohol produce una “buena onda” temporal, que termina cuando se acaba el efecto. Beber en exceso puede traer un buen momento, pero luego podemos sentirnos cansados, deprimidos o nerviosos. Unas copas de más a veces puede traernos una “buena resaca”.",
    ": Si la intoxicación es grave, existe un alto riesgo de morir, ya que puede causar parálisis respiratoria y compromiso cardiovascular. También puede provocar pérdida de conocimiento, problemas respiratorios, gastritis crónica y alterar el funcionamiento del hígado, lo que puede llevar finalmente a una cirrosis hepática. Además puede provocar una hepatitis aguda que eventualmente puede causar la muerte.",
    ": Al llegar al cerebro el alcohol activa unos centros que causan caída en la temperatura corporal; por eso, la hipotermia es una de las consecuencias más rápidas y contundentes del consumo de alcohol.",
    ": La marihuana puede generar dependencia. Su consumo produce dificultades en la capacidad de aprendizaje, problemas de concentración, altera la memoria inmediata y desmotiva.",
    ": Sí se ha comprobado que el alcohol causa degeneración neuronal y dificulta la comunicación entre las neuronas.",
    ": El consumo temprano tiene consecuencias graves en niños, niñas y adolescentes, y se debe evitar en todas las circunstancias.",
    ": Diversas investigaciones señalan que mientras más temprano se inicie el consumo de drogas, más probabilidades hay de generar una adicción (dependencia de las drogas). Esto se debe a que el organismo joven se encuentra en desarrollo y, por lo tanto, es más vulnerable a los efectos de las drogas.",
    ": El alcohol hace que la gente se desinhiba, pero hay quienes al beber tienen reacciones negativas que pueden provocar problemas con la ley, violencia, conflictos con la familia, la pareja o en el trabajo.",
    ": La marihuana afecta los pulmones porque el humo se retiene en ellos, conteniendo monóxido de carbono. Esto inflama los pulmones y produce riesgos de contraer enfermedades como la neumonía, bronquitis crónica, etc."
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
