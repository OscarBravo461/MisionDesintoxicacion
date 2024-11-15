using System.Collections;
using UnityEngine;

public class Player_3 : MonoBehaviour
{
    public Player script_Player1;
    public Player_2 script_Player2;
    public Player_4 script_Player4;
    public OpcionMulti_T3 scriptOpcionMulti;
    public CCJuego_T3 scriptCamara;
    public Canvas preguntas;
    public Canvas Multi_op;
    Vector3 SectorEscuela = new Vector3(-9.2f, 3.9f, 0f);
    Vector3 SectorCiudad = new Vector3(8.9f, 3.9f, 0f);
    Vector3 SectorPlaza = new Vector3(-9.2f, -5.3f, 0f);
    Vector3 SectorParque = new Vector3(8.9f, -5.3f, 0f);
    Vector3 VueltaAlPuente = new Vector3(-2f, -2f, 0f);
    public Ruta rutaEscuela;
    public Ruta rutaCiudad;
    public Ruta rutaPlaza;
    public Ruta rutaParque;
    public GCJuego gc;
    public int pasos;
    public int turno;
    public float speed = 20f;
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
                if (!isOnSeccion && enTurno == true)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        if (pasos == 0)
                            pasos = Random.Range(1, 7);
                        StartCoroutine(MovimientoDeSeccion());
                        StartCoroutine(primerMovimiento());
                        StartCoroutine(esperar());
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
                    if (Input.GetMouseButtonDown(1))
                    {
                        if (pasos == 0)
                            pasos = Random.Range(1, 7);
                        StartCoroutine(MovimientoDeSeccion());
                        StartCoroutine(primerMovimiento());
                        StartCoroutine(esperar());
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
                    if (Input.GetMouseButtonDown(1))
                    {
                        if (pasos == 0)
                            pasos = Random.Range(1, 7);
                        StartCoroutine(MovimientoDeSeccion());
                        StartCoroutine(primerMovimiento());
                        StartCoroutine(esperar());
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
                    if (Input.GetMouseButtonDown(1))
                    {
                        if (pasos == 0)
                            pasos = Random.Range(1, 7);
                        StartCoroutine(MovimientoDeSeccion());
                        StartCoroutine(primerMovimiento());
                        StartCoroutine(esperar());
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
            }

            if (posicionEnRuta % rutaEscuela.listaDeCasillas.Count == 0)//Evalua si se llego de nuevo al inicio de la sección para que el player vuelva al puente
            {
                vueltaEscuela = true;
            }
        }
        seMueve = false;
        gc.turno = 4;
    }
    //Todos los métodos tienen la misma lógica, solo adecuada a cada sección
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
            }
            if (posicionEnRuta % rutaCiudad.listaDeCasillas.Count == 0)
            {

                vueltaCiudad = true;
            }
        }
        seMueve = false;
        gc.turno = 4;
    }
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
            }
            if (posicionEnRuta % rutaPlaza.listaDeCasillas.Count == 0)
            {

                vueltaPlaza = true;
            }
        }
        seMueve = false;
        gc.turno = 4;
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
            }
            if (posicionEnRuta % rutaParque.listaDeCasillas.Count == 0)
            {

                vueltaParque = true;
            }
        }
        seMueve = false;
        gc.turno = 4;
    }
    IEnumerator MovimientoDeSeccion()
    {
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;

        while (!isOnSeccion)
        {
            Vector3 SeccionObjetivo = Camera.main.ScreenToWorldPoint(Input.mousePosition); //touch.position
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
        pasos--;
    }

    bool MoverDeCasilla(Vector3 objetivo)
    {
        if (vueltaEscuela || vueltaCiudad || vueltaPlaza || vueltaParque)
        {
            vueltaEscuela = false;
            vueltaCiudad = false;
            vueltaPlaza = false;
            vueltaParque = false;
        }
        return objetivo != (transform.position = Vector3.MoveTowards(transform.position, objetivo, speed * Time.deltaTime));
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
        Debug.Log("so");
        scriptCamara.objetivo_camara = 0;
        yield return new WaitForSeconds(10);
        scriptCamara.objetivo_camara = valor_anterior;
    }
    public IEnumerator esperar()
    {
        Debug.Log("Entro en P3");
        yield return new WaitForSeconds(2);
        switch (turno)
        {
            case 1:

                if (script_Player1.turno == 2)
                {
                    script_Player1.enTurno = true;
                    enTurno = false;
                }
                else if (script_Player2.turno == 2)
                {
                    script_Player2.enTurno = true;
                    enTurno = false;
                }
                else
                {
                    script_Player4.enTurno = true;
                    enTurno = false;
                }
                break;
            case 2:
                if (script_Player1.turno == 3)
                {
                    script_Player1.enTurno = true;
                    enTurno = false;
                }
                else if (script_Player2.turno == 3)
                {
                    script_Player2.enTurno = true;
                    enTurno = false;
                }
                else
                {
                    script_Player4.enTurno = true;
                    enTurno = false;
                }
                break;
            case 3:
                if (script_Player1.turno == 4)
                {
                    script_Player1.enTurno = true;
                    enTurno = false;
                }
                else if (script_Player2.turno == 4)
                {
                    script_Player2.enTurno = true;
                    enTurno = false;
                }
                else
                {
                    script_Player4.enTurno = true;
                    enTurno = false;
                }
                break;
            case 4:
                if (script_Player1.turno == 1)
                {
                    script_Player1.enTurno = true;
                    enTurno = false;
                }
                else if (script_Player2.turno == 1)
                {
                    script_Player2.enTurno = true;
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
    public IEnumerator primerMovimiento()
    {
        Debug.Log("P3 se mueve hacia una seccion");
        yield return new WaitForSeconds(1);
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
    }
}

