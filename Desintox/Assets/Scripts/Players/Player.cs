using System.Collections;
using UnityEngine;

//Pienso que se podría hacer de una forma en la que este sea un método base y que mediante herencia se pasara a los demás ya que así solo tendriamos que cambiar los vectores y
//poner el update en cada uno de los players pero sin repetir absolutamente todo esto, pero no supe como poder cambiar los vectores (pipipipipipipi) y tampoco el tema de los turnos
//entonces mejor lo deje como una posibilidad
public class Player : MonoBehaviour
{
    //Touch touch; --> Aspectos que podremos ocupar al momento de hacerlo para android
    //OpcionMulti_T3 PMultiples = new OpcionMulti_T3();
    public Player_2 script_Player2;
    public Player_3 script_Player3;
    public Player_4 script_Player4;
    public OpcionMulti_T3 scriptOpcionMulti;
    public CCJuego_T3 scriptCamara;
    public Canvas preguntas;
    public Canvas Multi_op;
    Vector3 SectorEscuela = new Vector3(-9.2f, 5.3f, 0f);
    Vector3 SectorCiudad = new Vector3(8.9f, 5.3f, 0f);
    Vector3 SectorPlaza = new Vector3(-9.2f, -3.7f, 0f);
    Vector3 SectorParque = new Vector3(8.9f, -3.7f, 0f);
    Vector3 VueltaAlPuente = new Vector3(-2f, 2f, 0f);
    public Ruta rutaEscuela;
    public Ruta rutaCiudad;
    public Ruta rutaPlaza;
    public Ruta rutaParque;
    public GCJuego gc;
    public int pasos; //Esta variable es la que controla cuánto avanza el jugador ---> Cambiar por el dado
    public int turno;
    public float speed = 20f; //Velocidad a la que se mueve el jugador
    public bool enTurno = false;
    int posicionEnRuta;
    int valor_anterior;
    bool seMueve = false;
    bool isOnSeccion;
    bool vueltaEscuela = false;
    bool vueltaCiudad = false;
    bool vueltaPlaza = false;
    bool vueltaParque = false;
    int seccionElegida;

    void Update()
    {
        switch (turno)
        {
            case 1:
                if (!isOnSeccion && enTurno == true) //Evualua si se seleccionó una sección
                {
                    if (Input.GetMouseButtonDown(0)) // Input.touchcount > 0 --> Aspectos que podremos ocupar al momento de hacerlo para android
                    {
                        //touch = Input.GetTouch(0); --> Aspectos que podremos ocupar al momento de hacerlo para android
                        StartCoroutine(MovimientoDeSeccion());
                    }
                }

                if (Input.GetKeyDown(KeyCode.F) && seMueve == false && isOnSeccion && enTurno == true)
                {
                    pasos = Random.Range(1, 7);
                    switch (seccionElegida)
                    {
                        case 1:
                            StartCoroutine(MovimientoSeccionEscuela());
                            break;
                        case 2:
                            StartCoroutine(MovimientoSeccionCiudad());
                            break;
                        case 3:
                            StartCoroutine(MovimientoSeccionPlaza());
                            break;
                        case 4:
                            StartCoroutine(MovimientoSeccionParque());
                            break;
                    }
                    StartCoroutine(esperar());

                }
                break;

            case 2:
                if (!isOnSeccion && enTurno == true)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        StartCoroutine(MovimientoDeSeccion());
                    }
                }

                if (Input.GetKeyDown(KeyCode.F) && seMueve == false && isOnSeccion && enTurno == true)
                {
                    pasos = Random.Range(1, 7);
                    switch (seccionElegida)
                    {
                        case 1:
                            StartCoroutine(MovimientoSeccionEscuela());
                            break;
                        case 2:
                            StartCoroutine(MovimientoSeccionCiudad());
                            break;
                        case 3:
                            StartCoroutine(MovimientoSeccionPlaza());
                            break;
                        case 4:
                            StartCoroutine(MovimientoSeccionParque());
                            break;
                    }
                    StartCoroutine(esperar());


                }
                break;
            case 3:
                if (!isOnSeccion && enTurno == true)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        StartCoroutine(MovimientoDeSeccion());
                    }
                }

                if (Input.GetKeyDown(KeyCode.F) && seMueve == false && isOnSeccion && enTurno == true)
                {
                    pasos = Random.Range(1, 7);
                    switch (seccionElegida)
                    {
                        case 1:
                            StartCoroutine(MovimientoSeccionEscuela());
                            break;
                        case 2:
                            StartCoroutine(MovimientoSeccionCiudad());
                            break;
                        case 3:
                            StartCoroutine(MovimientoSeccionPlaza());
                            break;
                        case 4:
                            StartCoroutine(MovimientoSeccionParque());
                            break;
                    }
                    StartCoroutine(esperar());

                }
                break;

            case 4:
                if (!isOnSeccion && enTurno == true)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        StartCoroutine(MovimientoDeSeccion());
                    }
                }

                if (Input.GetKeyDown(KeyCode.F) && seMueve == false && isOnSeccion && enTurno == true)
                {
                    pasos = Random.Range(1, 7);
                    switch (seccionElegida)
                    {
                        case 1:
                            StartCoroutine(MovimientoSeccionEscuela());
                            break;
                        case 2:
                            StartCoroutine(MovimientoSeccionCiudad());
                            break;
                        case 3:
                            StartCoroutine(MovimientoSeccionPlaza());
                            break;
                        case 4:
                            StartCoroutine(MovimientoSeccionParque());
                            break;
                    }
                    StartCoroutine(esperar());

                }
                break;
        }
    }

    public IEnumerator MovimientoSeccionEscuela()
    {
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;

        while (pasos > 0)
        {
            if (vueltaEscuela == false)
            {
                posicionEnRuta++;

                posicionEnRuta %= rutaEscuela.listaDeCasillas.Count; //Evalua si se encuentra en la última casilla antes de completar la sección para permitir que avance al convertirse en 0 de nuevo
                Vector3 siguientePosicion = rutaEscuela.listaDeCasillas[posicionEnRuta].position;
                while (MoverDeCasilla(siguientePosicion)) { yield return null; } //Ejecuta el recorrido

                yield return new WaitForSeconds(0.2f);
            }
            pasos--;

            if (vueltaEscuela == true)
            {
                while (MoverDeCasilla(VueltaAlPuente)) { yield return null; }
                isOnSeccion = false;
                seccionElegida = 0;
            }

            if (posicionEnRuta % rutaEscuela.listaDeCasillas.Count == 0)//Evalua si se llego de nuevo al inicio de la sección para que el player vuelva al puente
            {
                vueltaEscuela = true;
            }
        }
        seMueve = false;
    }
    //Todos los métodos tienen la misma lógica, solo adecuada a cada sección
    public IEnumerator MovimientoSeccionCiudad()
    {
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;

        while (pasos > 0)
        {
            if (vueltaCiudad == false)
            {
                posicionEnRuta++;

                posicionEnRuta %= rutaCiudad.listaDeCasillas.Count;
                Vector3 siguientePosicion = rutaCiudad.listaDeCasillas[posicionEnRuta].position;
                while (MoverDeCasilla(siguientePosicion)) { yield return null; }

                yield return new WaitForSeconds(0.2f);
            }
            pasos--;

            if (vueltaCiudad == true)
            {
                while (MoverDeCasilla(VueltaAlPuente)) { yield return null; }
                isOnSeccion = false;
                seccionElegida = 0;
            }
            if (posicionEnRuta % rutaCiudad.listaDeCasillas.Count == 0)
            {

                vueltaCiudad = true;
            }
        }
        seMueve = false;
    }
    public IEnumerator MovimientoSeccionPlaza()
    {
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;

        while (pasos > 0)
        {
            if (vueltaPlaza == false)
            {
                posicionEnRuta++;

                posicionEnRuta %= rutaPlaza.listaDeCasillas.Count;
                Vector3 siguientePosicion = rutaPlaza.listaDeCasillas[posicionEnRuta].position;
                while (MoverDeCasilla(siguientePosicion)) { yield return null; }

                yield return new WaitForSeconds(0.2f);
            }
            pasos--;

            if (vueltaPlaza == true)
            {
                while (MoverDeCasilla(VueltaAlPuente)) { yield return null; }
                isOnSeccion = false;
                seccionElegida = 0;
            }
            if (posicionEnRuta % rutaPlaza.listaDeCasillas.Count == 0)
            {

                vueltaPlaza = true;
            }
        }
        seMueve = false;
    }
    public IEnumerator MovimientoSeccionParque()
    {
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;

        while (pasos > 0)
        {
            if (vueltaParque == false)
            {
                posicionEnRuta++;

                posicionEnRuta %= rutaParque.listaDeCasillas.Count;
                Vector3 siguientePosicion = rutaParque.listaDeCasillas[posicionEnRuta].position;
                while (MoverDeCasilla(siguientePosicion)) { yield return null; }

                yield return new WaitForSeconds(0.2f);
            }
            pasos--;

            if (vueltaParque == true)
            {
                while (MoverDeCasilla(VueltaAlPuente)) { yield return null; }
                isOnSeccion = false;
                seccionElegida = 0;
            }
            if (posicionEnRuta % rutaParque.listaDeCasillas.Count == 0)
            {

                vueltaParque = true;
            }
        }
        seMueve = false;
    }
    public IEnumerator MovimientoDeSeccion() //Evalua donde se toco con el mouse para mover al jugador de una sección a otra
    {
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;

        while (!isOnSeccion)
        {
            Vector3 SeccionObjetivo = Camera.main.ScreenToWorldPoint(Input.mousePosition); //touch.position --> Aspectos que podremos ocupar al momento de hacerlo para android
            if (SeccionObjetivo.x < -8 && SeccionObjetivo.x > -12 && SeccionObjetivo.y > 3 && SeccionObjetivo.y < 6)
            {
                while (MoverDeCasilla(SectorEscuela)) { yield return null; }
            }
            if (SeccionObjetivo.x > 8 && SeccionObjetivo.x < 12 && SeccionObjetivo.y > 3 && SeccionObjetivo.y < 6)
            {
                while (MoverDeCasilla(SectorCiudad)) { yield return null; }
            }
            if (SeccionObjetivo.x < -8 && SeccionObjetivo.x > -12 && SeccionObjetivo.y > -6 && SeccionObjetivo.y < -3)
            {
                while (MoverDeCasilla(SectorPlaza)) { yield return null; }
            }
            if (SeccionObjetivo.x > 8 && SeccionObjetivo.x < 12 && SeccionObjetivo.y > -6 && SeccionObjetivo.y < -3)
            {
                while (MoverDeCasilla(SectorParque)) { yield return null; }
            }

            yield return new WaitForSeconds(0.2f);
        }
        seMueve = false;
    }

    bool MoverDeCasilla(Vector3 objetivo) //Es el método que ejecuta el movimiento
    {
        if (vueltaEscuela || vueltaCiudad || vueltaPlaza || vueltaParque)
        {
            vueltaEscuela = false;
            vueltaCiudad = false;
            vueltaPlaza = false;
            vueltaParque = false;
        }
        return objetivo != (transform.position = Vector3.MoveTowards(transform.position, objetivo, speed * Time.deltaTime));//Está línea evalua si la posición actual del jugador es distinta
                                                                                                                            //a la del objetivo, si si,
                                                                                                                            //entonces devuelve el valor true y hace que se mueva
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Escuela":
                isOnSeccion = true;
                seccionElegida = 1;
                break;
            case "Ciudad":
                isOnSeccion = true;
                seccionElegida = 2;
                break;
            case "Plaza":
                isOnSeccion = true;
                seccionElegida = 3;
                break;
            case "Parque":
                isOnSeccion = true;
                seccionElegida = 4;
                break;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Preguntas":
                if (!seMueve)
                    preguntas.gameObject.SetActive(true);
                break;
            case "Multiple":
                if (!seMueve)
                {
                    Multi_op.gameObject.SetActive(true);
                    scriptOpcionMulti.empiezar();
                    scriptOpcionMulti.reinicio();
                }
                break;
            case "Ruleta":
                if (!seMueve)
                {
                    valor_anterior = scriptCamara.objetivo_camara;
                    StartCoroutine(esperaCamara());
                }
                break;
        }
    }
    public IEnumerator esperaCamara()
    {
        scriptCamara.objetivo_camara = 0;
        yield return new WaitForSeconds(10);
        scriptCamara.objetivo_camara = valor_anterior;
    }

    public IEnumerator esperar()
    {
        Debug.Log("Entro en P1");
        yield return new WaitForSeconds(2);
        switch (turno)
        {
            case 1:
                if (script_Player2.turno == 2)
                {
                    script_Player2.enTurno = true;
                    enTurno = false;
                }
                else if (script_Player3.turno == 2)
                {
                    script_Player3.enTurno = true;
                    enTurno = false;
                }
                else
                {
                    script_Player4.enTurno = true;
                    enTurno = false;
                }
                break;
            case 2:
                if (script_Player2.turno == 3)
                {
                    script_Player2.enTurno = true;
                    enTurno = false;
                }
                else if (script_Player3.turno == 3)
                {
                    script_Player3.enTurno = true;
                    enTurno = false;
                }
                else
                {
                    script_Player4.enTurno = true;
                    enTurno = false;
                }
                break;
            case 3:
                if (script_Player2.turno == 4)
                {
                    script_Player2.enTurno = true;
                    enTurno = false;
                }
                else if (script_Player3.turno == 4)
                {
                    script_Player3.enTurno = true;
                    enTurno = false;
                }
                else if (script_Player4.turno == 4)
                {
                    script_Player4.enTurno = true;
                    enTurno = false;
                }
                break;
            case 4:
                if (script_Player2.turno == 1)
                {
                    script_Player2.enTurno = true;
                    enTurno = false;
                }
                else if (script_Player3.turno == 1)
                {
                    script_Player3.enTurno = true;
                    enTurno = false;
                }
                else
                {
                    script_Player4.enTurno = true;
                    enTurno = false;
                }
                break;
        }
    }
}

