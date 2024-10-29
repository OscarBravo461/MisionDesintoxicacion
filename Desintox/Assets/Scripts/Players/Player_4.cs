using System.Collections;
using UnityEngine;

public class Player_4 : MonoBehaviour
{
    //Touch touch;
    public OpcionMulti_T3 scriptOpcionMulti;
    public CCJuego_T3 scriptCamara;
    public Canvas preguntas;
    public Canvas Multi_op;
    Vector3 SectorEscuela = new Vector3(-11.5f, 3.9f, 0f);
    Vector3 SectorCiudad = new Vector3(11.3f, 3.9f, 0f);
    Vector3 SectorPlaza = new Vector3(-11.5f, -5.3f, 0f);
    Vector3 SectorParque = new Vector3(11.3f, -5.3f, 0f);
    Vector3 VueltaAlPuente = new Vector3(2f, -2f, 0f);
    public Ruta rutaEscuela;
    public Ruta rutaCiudad;
    public Ruta rutaPlaza;
    public Ruta rutaParque;
    public GCJuego gc;
    public int pasos;
    public float speed = 20f;
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
        if(gc.turno == 4)
        {
            if (!isOnSeccion)
            {
                if (Input.GetMouseButtonDown(0)) // Input.touchcount > 0
                {
                    //touch = Input.GetTouch(0);
                    StartCoroutine(MovimientoDeSeccion());
                }
            }

            if (Input.GetKeyDown(KeyCode.F) && seMueve == false && isOnSeccion)
            {
                switch (seccionElegida)
                {
                    case 1:
                        pasos = 1;
                        StartCoroutine(MovimientoSeccionEscuela());
                        Debug.Log("Hola");
                        break;
                    case 2:
                        pasos = 1;
                        StartCoroutine(MovimientoSeccionCiudad());
                        break;
                    case 3:
                        pasos = 1;
                        StartCoroutine(MovimientoSeccionPlaza());
                        break;
                    case 4:
                        pasos = 1;
                        StartCoroutine(MovimientoSeccionParque());
                        break;
                }

            }
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
        gc.turno = 1;
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
        gc.turno = 1;
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
        gc.turno = 1;
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
        gc.turno = 1;
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
}

