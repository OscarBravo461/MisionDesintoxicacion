using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player_2 : MonoBehaviour
{
    //Touch touch;
    Vector3 SectorEscuela = new Vector3(-10.3f, 4.7f, 0f);
    Vector3 SectorCiudad = new Vector3(10.3f, 4.7f, 0f);
    Vector3 SectorPlaza = new Vector3(-10.4f, -4.7f, 0f);
    Vector3 SectorParque = new Vector3(10.4f, -4.7f, 0f);
    Vector3 VueltaAlPuente = new Vector3(2f, 2f, 0f);
    public Ruta_Seccion_Escuela rutaEscuela;
    public Ruta_Seccion_Ciudad rutaCiudad;
    public Ruta_Seccion_Plaza rutaPlaza;
    public Ruta_Seccion_Parque rutaParque;
    public int pasos;
    public GCJuego gc;
    int posicionEnRuta;
    bool seMueve = false;
    bool isOnSeccion;
    int seccionElegida;

    void Update()
    {
        if(gc.turno == 2)
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

    IEnumerator MovimientoSeccionEscuela()
    {
        if(seMueve)
        {
            yield break;
        }
        seMueve = true;

        while(pasos > 0)
        {
            posicionEnRuta++;

            posicionEnRuta %= rutaEscuela.listaDeCasillas_Escuela.Count;
            Vector3 siguientePosicion = rutaEscuela.listaDeCasillas_Escuela[posicionEnRuta].position;
            while (MoverDeCasilla(siguientePosicion)) { yield return null; }

            yield return new WaitForSeconds(0.2f);
            pasos--;

            if (posicionEnRuta % rutaEscuela.listaDeCasillas_Escuela.Count == 0)
            {
                //Podría ponerse una evaluación en caso de que este script se use en general para todos los players, si no sobra
                    while (MoverDeCasilla(VueltaAlPuente)) { yield return null; }
                    isOnSeccion = false;
                    seccionElegida = 0;
            }
        }
        seMueve = false;
        gc.turno = 1;
    }
    IEnumerator MovimientoSeccionCiudad()
    {
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;

        while (pasos > 0)
        {
            posicionEnRuta++;

            posicionEnRuta %= rutaCiudad.listaDeCasillas_Ciudad.Count;
            Vector3 siguientePosicion = rutaCiudad.listaDeCasillas_Ciudad[posicionEnRuta].position;
            while (MoverDeCasilla(siguientePosicion)) { yield return null; }

            yield return new WaitForSeconds(0.2f);
            pasos--;

            if (posicionEnRuta % rutaCiudad.listaDeCasillas_Ciudad.Count == 0)
            {
                    while (MoverDeCasilla(VueltaAlPuente)) { yield return null; }
                    isOnSeccion = false;
                    seccionElegida = 0;
            }
        }
        seMueve = false;
        gc.turno = 1;
    }
    IEnumerator MovimientoSeccionPlaza()
    {
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;

        while (pasos > 0)
        {
            posicionEnRuta++;

            posicionEnRuta %= rutaPlaza.listaDeCasillas_Plaza.Count;
            Vector3 siguientePosicion = rutaPlaza.listaDeCasillas_Plaza[posicionEnRuta].position;
            while (MoverDeCasilla(siguientePosicion)) { yield return null; }

            yield return new WaitForSeconds(0.2f);
            pasos--;

            if (posicionEnRuta % rutaPlaza.listaDeCasillas_Plaza.Count == 0)
            {
                while (MoverDeCasilla(VueltaAlPuente)) { yield return null; }
                isOnSeccion = false;
                seccionElegida = 0;
            }
        }
        seMueve = false;
        gc.turno = 1;
    }
    IEnumerator MovimientoSeccionParque()
    {
        if (seMueve)
        {
            yield break;
        }
        seMueve = true;

        while (pasos > 0)
        {
            posicionEnRuta++;

            posicionEnRuta %= rutaParque.listaDeCasillas_Parque.Count;
            Vector3 siguientePosicion = rutaParque.listaDeCasillas_Parque[posicionEnRuta].position;
            while (MoverDeCasilla(siguientePosicion)) { yield return null; }

            yield return new WaitForSeconds(0.2f);
            pasos--;

            if (posicionEnRuta % rutaParque.listaDeCasillas_Parque.Count == 0)
            {
                while (MoverDeCasilla(VueltaAlPuente)) { yield return null; }
                isOnSeccion = false;
                seccionElegida = 0;
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
        return objetivo != (transform.position = Vector3.MoveTowards(transform.position, objetivo, 12f * Time.deltaTime));
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
    void Start()
    {
        
    }

}

