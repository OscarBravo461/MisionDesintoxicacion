using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//Pienso que se podría hacer de una forma en la que este sea un método base y que mediante herencia se pasara a los demás ya que así solo tendriamos que cambiar los vectores y
//poner el update en cada uno de los players pero sin repetir absolutamente todo esto, pero no supe como poder cambiar los vectores (pipipipipipipi) y tampoco el tema de los turnos
//entonces mejor lo deje como una posibilidad
public class Player : MonoBehaviour
{
    //Touch touch; --> Aspectos que podremos ocupar al momento de hacerlo para android
    //OpcionMulti_T3 PMultiples = new OpcionMulti_T3();
    public Player script_Player2;
    public Player script_Player3;
    public Player script_Player4;
    public OpcionMulti_T3 scriptOpcionMulti;
    public CCJuego_T3 scriptCamara;
    public Canvas preguntas;
    public Canvas Multi_op;
    public Button botonDados;
    public SpriteRenderer sprite;
    public Vector3 SectorCiudad = new Vector3(-7.54f, 5.93f, 0f);
    public Vector3 SectorPlaza = new Vector3(8.67f, 5.21f, 0f);
    public Vector3 SectorEscuela = new Vector3(-13.66f, -3.7f, 0f);
    public Vector3 SectorParque = new Vector3(21.56f, -8.24f, 0f);
    public Vector3 VueltaAlPuente = new Vector3(-2f, 2f, 0f);
    public Vector3 puntoTPCafeCiudad = new Vector3(-0f, 0f, 0f);
    public Vector3 puntoTPRosaEscuela = new Vector3(-0f, 0f, 0f);
    public Vector3 puntoTPCafeParque = new Vector3(0f, 0f, 0f);
    public Vector3 puntoTPRosaParque = new Vector3(0f, 0f, 0f);
    public Ruta rutaEscuela;
    public Ruta rutaCiudad;
    public Ruta rutaPlaza;
    public Ruta rutaParque;
    public GCJuego gc;
    public int pasos = 0; //Esta variable es la que controla cuánto avanza el jugador ---> Cambiar por el dado
    public int turno;
    public int playerID;
    public float speed = 20f; //Velocidad a la que se mueve el jugador
    public float tiempoEsperaDinamico;
    public bool enTurno = false;
    public bool botonPresionado = false; //Para que no pueda tirar el dado más de 1 vez por turno
    public int posicionEnRuta;
    int valor_anterior;
    int corazones = 0;
    public int seccionElegida;
    public bool seMueve = false;
    public bool isOnSeccion;
    bool vueltaEscuela = false;
    bool vueltaCiudad = false;
    bool vueltaPlaza = false;
    bool vueltaParque = false;
    public bool puente = false;
    public bool tp = false;
    public bool evento = false;
    public bool eventoAutomatico = false;

    void Update()
    {
        switch (turno)
        {
            case 1:
                if (enTurno)
                    scriptCamara.objetivo_camara = playerID;
                if (!isOnSeccion && enTurno == true) //Evualua si se seleccionó una sección
                {
                    botonDados.interactable = false;
                    if (Input.GetMouseButtonDown(1))// Input.touchcount > 0 --> Aspectos que podremos ocupar al momento de hacerlo para android
                    {                               //touch = Input.GetTouch(0); --> Aspectos que podremos ocupar al momento de hacerlo para android
                        StartCoroutine(MovimientoDeSeccion());
                    }
                }
                break;
            case 2:
                if (enTurno)
                    scriptCamara.objetivo_camara = playerID;
                if (!isOnSeccion && enTurno == true)
                {
                    botonDados.interactable = false;
                    if (Input.GetMouseButtonDown(1))
                    {
                        StartCoroutine(MovimientoDeSeccion());
                    }
                }
                break;
            case 3:
                if (enTurno)
                    scriptCamara.objetivo_camara = playerID;
                if (!isOnSeccion && enTurno == true)
                {
                    botonDados.interactable = false;
                    if (Input.GetMouseButtonDown(1))
                    {
                        StartCoroutine(MovimientoDeSeccion());
                    }
                }
                break;
            case 4:
                if (enTurno)
                    scriptCamara.objetivo_camara = playerID;
                if (!isOnSeccion && enTurno == true)
                {
                    botonDados.interactable = false;
                    if (Input.GetMouseButtonDown(1))
                    {
                        StartCoroutine(MovimientoDeSeccion());
                    }
                }
                break;
        }
    }

    public IEnumerator MovimientoSeccionCiudad()
    {
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;

        int pasosWhile = pasos;
        while (pasosWhile > 0)
        {
            if (vueltaEscuela == false)
            {
                posicionEnRuta++;

                posicionEnRuta %= rutaEscuela.listaDeCasillas.Count; //Evalua si se encuentra en la última casilla antes de completar la sección para permitir que avance al convertirse en 0 de nuevo
                Vector3 siguientePosicion = rutaEscuela.listaDeCasillas[posicionEnRuta].position;
                while (MoverDeCasilla(siguientePosicion)) { yield return null; } //Ejecuta el recorrido

                yield return new WaitForSeconds(0.2f);
                pasos--;
            }
            pasosWhile--;

            if (vueltaEscuela == true)
            {
                while (MoverDeCasilla(VueltaAlPuente)) { yield return null; }
                isOnSeccion = false;
                seccionElegida = 0;
                botonDados.interactable = false;
                puente = true;
            }

            if (posicionEnRuta % rutaEscuela.listaDeCasillas.Count == 0)//Evalua si se llego de nuevo al inicio de la sección para que el player vuelva al puente
            {
                vueltaEscuela = true;
            }
        }
        seMueve = false;
    }
    //Todos los métodos tienen la misma lógica, solo adecuada a cada sección
    public IEnumerator MovimientoSeccionPlaza()
    {
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;

        int pasosWhile = pasos;
        while (pasosWhile > 0)
        {
            if (vueltaCiudad == false)
            {
                posicionEnRuta++;

                posicionEnRuta %= rutaCiudad.listaDeCasillas.Count;
                Vector3 siguientePosicion = rutaCiudad.listaDeCasillas[posicionEnRuta].position;
                while (MoverDeCasilla(siguientePosicion)) { yield return null; }

                yield return new WaitForSeconds(0.2f);
                pasos--;
            }
            pasosWhile--;
            if (vueltaCiudad == true)
            {
                while (MoverDeCasilla(VueltaAlPuente)) { yield return null; }
                isOnSeccion = false;
                seccionElegida = 0;
                botonDados.interactable = false;
                puente = true;
            }
            if (posicionEnRuta % rutaCiudad.listaDeCasillas.Count == 0)
            {

                vueltaCiudad = true;
            }
        }
        seMueve = false;
    }
    public IEnumerator MovimientoSeccionEscuela()
    {
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;

        int pasosWhile = pasos;
        while (pasosWhile > 0)
        {
            if (vueltaPlaza == false)
            {
                posicionEnRuta++;

                posicionEnRuta %= rutaPlaza.listaDeCasillas.Count;
                Vector3 siguientePosicion = rutaPlaza.listaDeCasillas[posicionEnRuta].position;
                while (MoverDeCasilla(siguientePosicion)) { yield return null; }

                yield return new WaitForSeconds(0.2f);
                pasos--;
            }
            pasosWhile--;

            if (vueltaPlaza == true)
            {
                while (MoverDeCasilla(VueltaAlPuente)) { yield return null; }
                isOnSeccion = false;
                seccionElegida = 0;
                botonDados.interactable = false;
                puente = true;
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

        int pasosWhile = pasos;
        while (pasosWhile > 0)
        {
            if (vueltaParque == false)
            {
                posicionEnRuta++;

                posicionEnRuta %= rutaParque.listaDeCasillas.Count;
                Vector3 siguientePosicion = rutaParque.listaDeCasillas[posicionEnRuta].position;
                while (MoverDeCasilla(siguientePosicion)) { yield return null; }

                yield return new WaitForSeconds(0.2f);
                pasos--;
            }
            pasosWhile--;

            if (vueltaParque == true)
            {
                while (MoverDeCasilla(VueltaAlPuente)) { yield return null; }
                isOnSeccion = false;
                seccionElegida = 0;
                botonDados.interactable = false;
                puente = true;
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
                while (MoverDeCasilla(SectorCiudad)) { yield return null; }
            }
            if (SeccionObjetivo.x > -26 && SeccionObjetivo.x < -16 && SeccionObjetivo.y > -11 && SeccionObjetivo.y < 1.5)
            {
                while (MoverDeCasilla(SectorEscuela)) { yield return null; }
            }
            if (SeccionObjetivo.x < -8 && SeccionObjetivo.x > -12 && SeccionObjetivo.y > -6 && SeccionObjetivo.y < -3)
            {
                while (MoverDeCasilla(SectorPlaza)) { yield return null; }
            }
            if (SeccionObjetivo.x > 11.5 && SeccionObjetivo.x < 28 && SeccionObjetivo.y > -16 && SeccionObjetivo.y < -1.5)
            {
                while (MoverDeCasilla(SectorParque)) { yield return null; }
            }

            yield return new WaitForSeconds(0.2f);
        }
        if (pasos > 0)
        {
            ActivarMovimiento();
        }
        else
        {
            botonDados.interactable = true;
            seMueve = false;
        }
    }
    public IEnumerator TP_CafeEnParque()
    {
        sprite.enabled = false;
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;
        while (MovimientoAlTP(puntoTPCafeCiudad)) { yield return null; }
        yield return new WaitForSeconds(10f);
        seMueve = false;

    }
    public IEnumerator TP_CafeEnCiudad()
    {
        sprite.enabled = false;
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;
        while (MovimientoAlTP(puntoTPCafeParque)) { yield return null; }
        yield return new WaitForSeconds(10f);
        seMueve = false;

    }
    public IEnumerator TP_RosaEnParque()
    {
        sprite.enabled = false;
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;
        while (MovimientoAlTP(puntoTPRosaEscuela)) { yield return null; }
        yield return new WaitForSeconds(10f);
        seMueve = false;

    }
    public IEnumerator TP_RosaEnEscuela()
    {
        sprite.enabled = false;
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;
        while (MovimientoAlTP(puntoTPRosaParque)) { yield return null; }
        yield return new WaitForSeconds(10f);
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
    bool MovimientoAlTP(Vector3 waypointCafe)
    {
        return waypointCafe != (transform.position = Vector3.MoveTowards(transform.position, waypointCafe, speed * Time.deltaTime));
    }

    public IEnumerator CasillaRetroceso()
    {
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;

        int pasosWhile = 2;
        while (pasosWhile > 0)
        {
            posicionEnRuta--;
            posicionEnRuta %= rutaParque.listaDeCasillas.Count;
            Vector3 siguientePosicion = rutaParque.listaDeCasillas[posicionEnRuta].position;
            while (MoverDeCasilla(siguientePosicion)) { yield return null; }
            yield return new WaitForSeconds(0.2f);
            pasos--;
            pasosWhile--;
        }
        seMueve = false;
        evento = false;
    }
    public IEnumerator CasillaAvanza()
    {
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;

        int pasosWhile = 2;
        while (pasosWhile > 0)
        {
            posicionEnRuta++;
            posicionEnRuta %= rutaParque.listaDeCasillas.Count;
            Vector3 siguientePosicion = rutaParque.listaDeCasillas[posicionEnRuta].position;
            while (MoverDeCasilla(siguientePosicion)) { yield return null; }
            yield return new WaitForSeconds(0.2f);
            pasos--;
            pasosWhile--;
        }
        seMueve = false;
        evento = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Ciudad":
                isOnSeccion = true;
                seccionElegida = 1;
                break;
            case "Plaza":
                isOnSeccion = true;
                seccionElegida = 2;
                break;
            case "Escuela":
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
            case "Corazon":
                if(!seMueve)
                {
                    if (corazones < 50)
                    {
                        eventoAutomatico = true;
                        corazones++;
                    }
                }
                break;
            case "Grillete":
                if (!seMueve)
                {
                    if (corazones > 0)
                    {
                        eventoAutomatico = true;
                        corazones--;
                    }
                }
                break;
            case "Preguntas":
                if (!seMueve)
                {
                    evento = true;
                    preguntas.gameObject.SetActive(true);
                }
                break;
            case "Multiple":
                if (!seMueve)
                {
                    evento = true;
                    Multi_op.gameObject.SetActive(true);
                    scriptOpcionMulti.empiezar();
                    scriptOpcionMulti.reinicio();
                }
                break;
            case "Ruleta":
                if (!seMueve)
                {
                    valor_anterior = scriptCamara.objetivo_camara;
                    evento = true;
                    StartCoroutine(esperaCamara());
                }
                break;
            case "Avanza":
                if (!seMueve)
                {
                    eventoAutomatico = true;
                    StartCoroutine(CasillaAvanza());
                }
                break;
            case "Retro":
                if (!seMueve)
                {
                    eventoAutomatico = true;
                    StartCoroutine(CasillaRetroceso());
                }
                break;
            case "TP_CafeEnParque":
                if (!seMueve && tp == false)
                {
                    posicionEnRuta = 10;
                    StartCoroutine(TP_CafeEnParque());
                    sprite.enabled = true;
                    tp = true;
                }
                break;
            case "TP_RosaEnParque":
                if (!seMueve && tp == false)
                {
                    posicionEnRuta = 4;
                    StartCoroutine(TP_RosaEnParque());
                    sprite.enabled = true;
                    tp = true;
                }
                break;
            case "TP_CafeEnCiudad":
                if (!seMueve && tp == false)
                {
                    posicionEnRuta = 17;
                    StartCoroutine(TP_CafeEnCiudad());
                    sprite.enabled = true;
                    tp = true;
                }
                break;
            case "TP_RosaEnEscuela":
                if (!seMueve && tp == false)
                {
                    posicionEnRuta = 12;
                    StartCoroutine(TP_RosaEnEscuela());
                    sprite.enabled = true;
                    tp = true;
                }
                break;
            case "Recaida":
                if(!seMueve)
                {
                    eventoAutomatico = true;
                    if(corazones > 0)
                    {
                        while(corazones > 0)
                        {
                            corazones--;
                        }
                    }
                    else 
                        corazones = 0;
                }
                break;
        }
    }
    public IEnumerator esperaCamara()
    {
        valor_anterior = scriptCamara.objetivo_camara;
        scriptCamara.objetivo_camara = 0;
        yield return new WaitForSeconds(10);
        scriptCamara.objetivo_camara = valor_anterior;
    }

    public IEnumerator esperar()
    {
        if(puente)
        {
            switch(pasos)
            {
                case 1:
                    tiempoEsperaDinamico = 1.25f;
                    break;
                case 2:
                    tiempoEsperaDinamico = 1.75f;
                    break;
                case 3:
                    tiempoEsperaDinamico = 2.25f;
                    break;
                case 4:
                    tiempoEsperaDinamico = 2.75f;
                    break;
                case 5:
                    tiempoEsperaDinamico = 3.25f;
                    break;
                case 6:
                    tiempoEsperaDinamico = 3.75f;
                    break;
            }
        }
        yield return new WaitForSeconds(tiempoEsperaDinamico);
        botonPresionado = false;
        if (isOnSeccion == true && puente == false && seMueve == false && evento == false && eventoAutomatico == false)
        {
            Debug.Log("Entre al if de cambio de turno");
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
            botonDados.interactable = true;
        }
        else if(tp == true)
        {
            yield return new WaitForSeconds(4);
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
            botonDados.interactable = true;
        }
        else if(eventoAutomatico)
        {
            Debug.Log("Entre en el if de cambio de turno automatico");
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
            botonDados.interactable = true;
            eventoAutomatico = false;
        }
    }

    public void terminarEvento()
    {
        StartCoroutine(eventos());
    }

    public IEnumerator eventos()
    {
        if(isOnSeccion && !seMueve && enTurno)
        {
            yield return new WaitForSeconds(0.5f);
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
            botonDados.interactable = true;
            evento = false;
        }
    }
    public void ActivarMovimiento()
    {
        botonDados.interactable = false;
        if (seMueve == false && isOnSeccion && enTurno == true && !botonPresionado && puente == false)
        {
            botonPresionado = true;
            pasos = Random.Range(1, 7);
            switch (pasos)
            {
                case 1:
                    tiempoEsperaDinamico = 1.25f;
                    break;
                case 2:
                    tiempoEsperaDinamico = 1.75f;
                    break;
                case 3:
                    tiempoEsperaDinamico = 2.25f;
                    break;
                case 4:
                    tiempoEsperaDinamico = 2.75f;
                    break;
                case 5:
                    tiempoEsperaDinamico = 3.25f;
                    break;
                case 6:
                    tiempoEsperaDinamico = 3.75f;
                    break;
            }
            switch (seccionElegida)
            {
                case 1:
                    StartCoroutine(MovimientoSeccionCiudad());
                    break;
                case 2:
                    StartCoroutine(MovimientoSeccionPlaza());
                    break;
                case 3:
                    StartCoroutine(MovimientoSeccionEscuela());
                    break;
                case 4:
                    StartCoroutine(MovimientoSeccionParque());
                    break;
            }
            StartCoroutine(esperar());
        }
        else if (puente == true)
        {
            switch (seccionElegida)
            {
                case 1:
                    seMueve = false;
                    StartCoroutine(MovimientoSeccionCiudad());
                    break;
                case 2:
                    seMueve = false;
                    StartCoroutine(MovimientoSeccionPlaza());
                    break;
                case 3:
                    seMueve = false;
                    StartCoroutine(MovimientoSeccionEscuela());
                    break;
                case 4:
                    seMueve = false;
                    StartCoroutine(MovimientoSeccionParque());
                    break;
            }
            StartCoroutine(esperar());
            puente = false;
        }
        if(tp == true)
           tp = false;
    }
}

