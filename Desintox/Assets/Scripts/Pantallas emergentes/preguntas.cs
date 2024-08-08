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
    "Las drogas en Mexico se declararon ilegales en el anio 1940?",
    "El termino adicciones se refiere solo al abuso y consumo de sustancias tales como el tabaco, la bebida y las drogas",
    "Mexico cuenta con Centro de Atencion Ciudadana contra las Adicciones?",
    "Realizar de forma constante y excesiva actividades como: el ejercicio, los videojuegos y redes sociales, cuenta como adicciones?",
    "Jugar constantemente juegos de azar en casinos se puede considerar una adiccion?",
    "Jugar a videojuegos, juegos de azar y pasar el rato en redes sociales  son actividades que directamente vuelven adictos a las personas?",
    "El acido sulfurico puede utilizarse para la elaboracion de drogas como la cocaina?",
    "El acido acetil salicilico es el nombre cientifico de la marihuana?",
    "No pasa nada si solo se consumen drogas los fines de semana",
    "Las personas con dependencia a las drogas tomaron una decision equivocada?",
    "SI TOMO MUCHO ALCOHOL ME HARe MENOS RESISTENTE?",
    "PARA PASARLO BIEN HAY QUE BEBER ALCOHOL?",
    "UNA INTOXICACIoN GRAVE CON ALCOHOL PUEDE PRODUCIR LA MUERTE?",
    "EL ALCOHOL BAJA LA TEMPERATURA CORPORAL?",
    "EL CONSUMO DE MARIHUANA NO HACE DAniO?",
    "EL ALCOHOL MATA NEURONAS?",
    "EL CONSUMO EN EDAD TEMPRANO TIENE CONSECUENCIAS?",
    "MIENTRAS MaS JOVEN SE COMIENCE A CONSUMIR DROGAS, MaS PROBABILIDADES HAY DE SER DEPENDIENTE",
    "EL ALCOHOL NOS PONE BIEN HAPPY'S?",
    "LA MARIHUANA NO AFECTA LOS PULMONES"
    };
    public string[] Facts = new string[]{
    ": En 1940, ultimo anio de su mandato como presidente, Lazaro Cardenas promulgo un Reglamento Federal de Toxicomanias en el que se eliminaron diversos decretos punitivos que consideraban el consumo, posesion y venta de drogas como un delito.",
    ": La adiccion es una enfermedad neurologica que se caracteriza por una busqueda patologica de la recompensa o alivio a traves del uso de una sustancia u otras acciones.",
    ": En el Centro de Atencion Ciudadana contra las Adicciones un grupo de especialistas te escucha para ofrecerte: Prevencion y atencion del consumo de sustancias adictivas y orientacion a sus familiares. Tratamiento breve para dejar de fumar. Entre otros servicios.",
    ": El riesgo de caer en una adiccion es parte de la vida. Lo que sucede es que a veces no lo percibimos. Los seres humanos podemos crear dependencia hacia cualquier cosa, incluso hacia el futbol, senala el doctor Hugo Espana, toxicologo y especialista en adicciones.",
    ": La ludopatia es un trastorno de orden psicologico que lleva a la persona a jugar y apostar repetidamente en un casino u otro sistema de apuestas, afectando de forma negativa a la vida personal, familiar y vocacional. Tambien se aplica a la adiccion patologica a los juegos electronicos en general.",
    ": Se ha demostrado que estas actividades por si mismas no generan dependencia, ludopatia o adiccion y si bien se registran casos que ligan a estas actividades la realidad es que casi cualquier actividad sin medida puede generar adiccion en una persona.",
    ": El acido sulfurico, acetona, permanganato de potasio, etc. Es extraido hasta su forma final en cocaina (clorhidrato de cocaina).",
    ": El acido acetilsalicilico o AAS, conocido popularmente como aspirina, nombre de una marca que paso al uso comun, es un farmaco de la familia de los salicilatos. Se utiliza como medicamento para tratar el dolor, la fiebre y la inflamacion, debido a su efecto inhibidor, no selectivo, de la ciclooxigenasa.",
    ": Debe recordarse que algunos efectos graves del consumo como es el caso del golpe de calor son independientes del tiempo que se lleve consumiendo. Por otra parte, consumir todos los fines de semana conlleva un riesgo evidente. Ademas hay que tener en cuenta que los efectos del fin de semana se prolongan durante varios dias.",
    ": Desde el 2019, los Estados Miembro de las Naciones Unidas han reconocido que la dependencia a las drogas es un asunto de salud publica relacionado con multiples factores. Esto significa que existen diversas variables que incrementan la posibilidad de que alguien comience a utilizar drogas o desarrolle problemas de salud mental por su consumo.",
    ": El consumir frecuentemente el alcohol te generara una resistencia cada vez mas fuerte al punto donde no sera suficiente con unas pocas copas.",
    ": El alcohol produce una buena onda temporal, que termina cuando se acaba el efecto. Beber en exceso puede traer un buen momento, pero luego podemos sentirnos cansados, deprimidos o nerviosos. Unas copas de mas a veces puede traernos una buena resaca.",
    ": Si la intoxicacion es grave, existe un alto riesgo de morir, ya que puede causar paralisis respiratoria y compromiso cardiovascular. Tambien puede provocar perdida de conocimiento, problemas respiratorios, gastritis cronica y alterar el funcionamiento del higado, lo que puede llevar finalmente a una cirrosis hepatica. Ademas puede provocar una hepatitis aguda que eventualmente puede causar la muerte.",
    ": Al llegar al cerebro el alcohol activa unos centros que causan caida en la temperatura corporal; por eso, la hipotermia es una de las consecuencias mas rapidas y contundentes del consumo de alcohol.",
    ": La marihuana puede generar dependencia. Su consumo produce dificultades en la capacidad de aprendizaje, problemas de concentracion, altera la memoria inmediata y desmotiva.",
    ": Si se ha comprobado que el alcohol causa degeneracion neuronal y dificulta la comunicacion entre las neuronas.",
    ": El consumo temprano tiene consecuencias graves en ninios, ninias y adolescentes, y se debe evitar en todas las circunstancias.",
    ": Diversas investigaciones senalan que mientras mas temprano se inicie el consumo de drogas, mas probabilidades hay de generar una adiccion (dependencia de las drogas). Esto se debe a que el organismo joven se encuentra en desarrollo y, por lo tanto, es mas vulnerable a los efectos de las drogas.",
    ": El alcohol hace que la gente se desinhiba, pero hay quienes al beber tienen reacciones negativas que pueden provocar problemas con la ley, violencia, conflictos con la familia, la pareja o en el trabajo.",
    ": La marihuana afecta los pulmones porque el humo se retiene en ellos, conteniendo monoxido de carbono. Esto inflama los pulmones y produce riesgos de contraer enfermedades como la neumonia, bronquitis cronica, etc."
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
            Question_txt.text = "HECHO"+Facts[receivedNumbers[Counter]];
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
        // Iniciar la corrutina para cerrar el canvas
        StartCoroutine(Close(5f));
       
    }

    IEnumerator Close(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Preguntas.gameObject.SetActive(false);
    }
}
