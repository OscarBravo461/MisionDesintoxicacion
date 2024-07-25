using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player_1 : MonoBehaviour
{
    public Ruta_Seccion_Escuela rutaActual;
    public int pasos;
    int posicionEnRuta;
    bool seMueve = false;
    bool isOnSeccion;
    int seccionElegida;

    void Update()
    {
        if(!isOnSeccion)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(MovimientoDeSeccion());
            }
        }

        if(Input.GetKeyDown(KeyCode.F) && seMueve == false && isOnSeccion)
        {
            pasos = 1;
            StartCoroutine(Movimiento());
        }
    }

    IEnumerator Movimiento()
    {
        if(seMueve)
        {
            yield break;
        }
        seMueve = true;

        while(pasos > 0)
        {
            posicionEnRuta++;
            posicionEnRuta %= rutaActual.listaDeCasillas_Escuela.Count;
            Vector3 siguientePosicion = rutaActual.listaDeCasillas_Escuela[posicionEnRuta].position;
            while (MoverDeCasilla(siguientePosicion)) { yield return null; }

            yield return new WaitForSeconds(0.2f);
            pasos--;
        }
        seMueve = false;
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
            Vector3 SeccionObjetivo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            while (MoverDeCasilla(SeccionObjetivo)) { yield return null; }

            yield return new WaitForSeconds(0.2f);
        }
        seMueve = false;
    }

    bool MoverDeCasilla(Vector3 objetivo)
    {
        return objetivo != (transform.position = Vector3.MoveTowards(transform.position, objetivo, 6f * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Escuela":
                Debug.Log("Hizo Colision");
                isOnSeccion = true;
                seccionElegida = 1;
                break;
        }
    }
    public void botonPrueba()
    {
        Debug.Log("Jelou");
    }
    void Start()
    {
        
    }

}

