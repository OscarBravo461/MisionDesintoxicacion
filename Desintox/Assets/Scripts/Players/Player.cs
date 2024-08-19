using System.Collections;
using UnityEngine;

//Pienso que se podría hacer de una forma en la que este sea un método base y que mediante herencia se pasara a los demás ya que así solo tendriamos que cambiar los vectores y
//poner el update en cada uno de los players pero sin repetir absolutamente todo esto, pero no supe como poder cambiar los vectores (pipipipipipipi) y tampoco el tema de los turnos
//entonces mejor lo deje como una posibilidad
public class Player : MonoBehaviour
{
    //Touch touch; --> Aspectos que podremos ocupar al momento de hacerlo para android
    Vector3 SectorEscuela = new Vector3(-9.2f, 5.3f, 0f);
    Vector3 SectorCiudad = new Vector3(8.9f, 5.3f, 0f);
    Vector3 SectorPlaza = new Vector3(-9.2f, -3.7f, 0f);
    Vector3 SectorParque = new Vector3(8.9f, -3.7f, 0f);
    Vector3 VueltaAlPuente = new Vector3(-2f, 2f, 0f);
    public Ruta rutaEscuela;
    public Ruta rutaCiudad;
    public Ruta rutaPlaza;
    public Ruta rutaParque;
    public int pasos; //Esta variable es la que controla cuánto avanza el jugador ---> Cambiar por el dado
    public GCJuego gc;
    int posicionEnRuta;
    bool seMueve = false;
    bool isOnSeccion;
    bool vueltaEscuela = false;
    int seccionElegida;

    void Update()
    {
        if (gc.turno == 1)
        {
            if (!isOnSeccion) //Evualua si se seleccionó una sección
            {
                if (Input.GetMouseButtonDown(0)) // Input.touchcount > 0 --> Aspectos que podremos ocupar al momento de hacerlo para android
                {
                    //touch = Input.GetTouch(0); --> Aspectos que podremos ocupar al momento de hacerlo para android
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
        if(seMueve)
        {
            yield break;
        }
        seMueve = true;

        while(pasos > 0)
        {
            if(vueltaEscuela == false)
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
        gc.turno = 2;
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
            posicionEnRuta++;

            posicionEnRuta %= rutaCiudad.listaDeCasillas.Count;
            Vector3 siguientePosicion = rutaCiudad.listaDeCasillas[posicionEnRuta].position;
            while (MoverDeCasilla(siguientePosicion)) { yield return null; }

            yield return new WaitForSeconds(0.2f);
            pasos--;

            if (posicionEnRuta % rutaCiudad.listaDeCasillas.Count == 0)
            {
                    while (MoverDeCasilla(VueltaAlPuente)) { yield return null; }
                    isOnSeccion = false;
                    seccionElegida = 0;
            }
        }
        seMueve = false;
        gc.turno = 2;
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
            posicionEnRuta++;

            posicionEnRuta %= rutaPlaza.listaDeCasillas.Count;
            Vector3 siguientePosicion = rutaPlaza.listaDeCasillas[posicionEnRuta].position;
            while (MoverDeCasilla(siguientePosicion)) { yield return null; }

            yield return new WaitForSeconds(0.2f);
            pasos--;

            if (posicionEnRuta % rutaPlaza.listaDeCasillas.Count == 0)
            {
                while (MoverDeCasilla(VueltaAlPuente)) { yield return null; }
                isOnSeccion = false;
                seccionElegida = 0;
            }
        }
        seMueve = false;
        gc.turno = 2;
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
            posicionEnRuta++;

            posicionEnRuta %= rutaParque.listaDeCasillas.Count;
            Vector3 siguientePosicion = rutaParque.listaDeCasillas[posicionEnRuta].position;
            while (MoverDeCasilla(siguientePosicion)) { yield return null; }

            yield return new WaitForSeconds(0.2f);
            pasos--;

            if (posicionEnRuta % rutaParque.listaDeCasillas.Count == 0)
            {
                while (MoverDeCasilla(VueltaAlPuente)) { yield return null; }
                isOnSeccion = false;
                seccionElegida = 0;
            }
        }
        seMueve = false;
        gc.turno = 2;
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
        return objetivo != (transform.position = Vector3.MoveTowards(transform.position, objetivo, 12f * Time.deltaTime));//Está línea evalua si la posición actual del jugador es distinta
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
}

