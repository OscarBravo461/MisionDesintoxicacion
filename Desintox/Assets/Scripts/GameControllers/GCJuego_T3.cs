using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GCJuego_T3 : MonoBehaviour
{
    // Declaracion de la indicacion de que jugador tirara el dado
    public TextMeshProUGUI JD;
    //Declaracion de la indicacion visual del numero que saco cadad jugador
    public TextMeshProUGUI Nj1;
    public TextMeshProUGUI Nj2;
    public TextMeshProUGUI Nj3;
    public TextMeshProUGUI Nj4;
    //Indicacion de que turno final tienen los jugadores
    public TextMeshProUGUI T1;
    public TextMeshProUGUI T2;
    public TextMeshProUGUI T3;
    public TextMeshProUGUI T4;
    //Variable que sirve para que el codigo sepa que jugador es el que tira los dados
    public int turno = 1;
    //variable para las repeticiones de tiro
    public int turno2 = 1;
    //codigos hechos para poder comparar los casos en los que se repitan los numeros mas facil
    public int n1 = 0;
    public int n2 = 0;
    public int n3 = 0;
    public int n4 = 0;

    public int sit1 = 0;
    public int sit2 = 0;
    public int sit3 = 0;
    public int sit4 = 0;    
    public int sit5 = 0;
    public int sit6 = 0;
    public int repe = 0;
    
    //Funcionamiento del boton
    public void generar_random_jugadores()
    {
        //Se decide el resutlado de los dados dependiendo del turno del jugador correspondiente ademas de hacerse comprobaciones por si hay repeticiones
        switch (turno)
        {
            case 1:
                int r1 =UnityEngine.Random.Range(1, 4);
                n1= r1;
                Nj1.text = ""+r1;
                turno++;
                JD.text = "Es turno del jugador 2";
                break;
            case 2:
                int r2 =UnityEngine.Random.Range(1, 4);
                n2=r2;
                if (n1 == n2)
                {
                    repe++;
                    sit1++;
                    Debug.Log("sit1 Happen");
                }
                Nj2.text = ""+r2;

                turno++;
                JD.text = "Es turno del jugador 3";
                break;
            case 3:
                int r3 =UnityEngine.Random.Range(1, 4);
                n3 = r3;
                if (n1 == n3)
                {
                    repe++;
                    sit2++;
                    if (sit1==1)
                    {
                        sit2 = 0;
                        Debug.Log("Se repitio el caso 3  sit2");
                        goto case 3;
                    }
                    Debug.Log("sit2 Happen");
                }
                if (n2 == n3)
                {
                    repe++;
                    sit3++;
                    if (sit1 == 1)
                    {
                        sit3 = 0;
                        Debug.Log("Se repitio el caso 3 sit3");
                        goto case 3;
                    }
                    Debug.Log("sit3 Happen");
                }
                JD.text = "Es turno del jugador 4";
                Nj3.text = "" + r3;
                turno++;
                break;
            case 4:
                int r4 =UnityEngine.Random.Range(1, 4);
                n4 = r4;
                if (n1 == n4)
                {
                    repe++;
                    sit4++;
                    if (sit1 == 1)
                    {
                        sit4 = 0;
                        Debug.Log("Se repitio el caso 4 sit4 1");
                        goto case 4;
                    }
                    if (sit2 == 1)
                    {
                        sit4 = 0;
                        Debug.Log("Se repitio el caso 4 sit4 2");
                        goto case 4;
                    }
                    Debug.Log("sit4 Happen");
                }
                if (n2 == n4)
                {
                    repe++;
                    sit5++;
                    if (sit1 == 1)
                    {
                        sit5 = 0;
                        Debug.Log("Se repitio el caso 4 sit5 1");
                        goto case 4;
                    }
                    if (sit3 == 1)
                    {
                        sit5 = 0;
                        Debug.Log("Se repitio el caso 4 sit5 2");
                        goto case 4;
                    }
                    Debug.Log("sit5 Happen");
                }
                if (n3 == n4)
                {
                    repe++;
                    sit6++;
                    if (sit3 == 1)
                    {
                        sit6 = 0;
                        Debug.Log("Se repitio el caso 4 sit6 1");
                        goto case 4;
                    }
                    if (sit2 == 1)
                    {
                        sit6 = 0;
                        Debug.Log("Se repitio el caso 4 sit6 2");
                        goto case 4;
                    }
                    Debug.Log("sit6 Happen");

                }
                Nj4.text = "" + r4;
                turno = 0;
                Debug.Log("Se repitio " + repe + "veces");

                if (sit1 == 1)
                {
                    if (sit6 == 1)
                    {
                        turno = 1;
                        //aqui estaria bueno poner una ventana emergente que diga que se repiten todos los tiros
                        JD.text = ("Es turno del Jugador 1");
                    }
                    else
                    {
                        Debug.Log("Jugadores 1 y 2 repiten tirada");
                        JD.text = ("Es turno del Jugador 1");
                        turno = 5;
                        if (n3 > n4)
                        {
                            T3.text = ("1");
                            T4.text = ("2");
                            Debug.Log("Primer turno J3, Segundo Turno J4");
                        }
                        else
                        {
                            T4.text = ("1");
                            T3.text = ("2");
                            Debug.Log("Primer turno J4, Segundo Turno J3");
                        }
                    }
                }
                else if (sit2 == 1)
                {
                    if (sit5 == 1)
                    {
                        turno = 1;
                        //aqui estaria bueno poner una ventana emergente que diga que se repiten todos los tiros
                        JD.text = ("Es turno del Jugador 1");
                    }
                    else
                    {
                        Debug.Log("Jugadores 1 y 3 repiten tirada");
                        turno = 6;
                        JD.text = ("Es turno del Jugador 1");
                        if (n2 > n4)
                        {
                            T2.text = ("1");
                            T4.text = ("2");
                            Debug.Log("Primer turno J2, Segundo Turno J4");
                        }
                        else
                        {
                            T4.text = ("1");
                            T2.text = ("2");
                            Debug.Log("Primer turno J4, Segundo Turno J2");
                        }

                    }
                }
                else if (sit3 == 1)
                {
                    if (sit4 == 1)
                    {
                        turno = 1;
                        //aqui estaria bueno poner una ventana emergente que diga que se repiten todos los tiros
                        JD.text = ("Es turno del Jugador 1");
                    }
                    else
                    {
                        Debug.Log("Jugadores 2 y 3 repiten tirada");
                        turno = 7;
                        JD.text = ("Es turno del Jugador 2");
                        if (n1 > n4)
                        {
                            T1.text = ("1");
                            T4.text = ("2");
                            Debug.Log("Primer turno J1, Segundo Turno J4");
                        }
                        else
                        {
                            T4.text = ("1");
                            T1.text = ("2");
                            Debug.Log("Primer turno J4, Segundo Turno J1");
                        }
                    }
                }
                else if (sit4 == 1)
                {
                    Debug.Log("Jugadores 1 y 4 repiten tirada");
                    turno = 8;
                    JD.text = ("Es turno del Jugador 1");
                    if (n2 > n3)
                    {
                        T2.text = ("1");
                        T3.text = ("2");
                        Debug.Log("Primer turno J2, Segundo Turno J3");
                    }
                    else
                    {
                        T3.text = ("1");
                        T2.text = ("2");
                        Debug.Log("Primer turno J3, Segundo Turno J2");
                    }
                }
                else if (sit5 == 1)
                {
                    Debug.Log("Jugadores 2 y 4 repiten tirada");
                    turno = 9;
                    JD.text = ("Es turno del Jugador 2");
                    if (n1 > n3)
                    {
                        T1.text = ("1");
                        T3.text = ("2");
                        Debug.Log("Primer turno J1, Segundo Turno J3");
                    }
                    else
                    {
                        T3.text = ("1");
                        T1.text = ("2");
                        Debug.Log("Primer turno J3, Segundo Turno J1");
                    }
                }
                else if (sit6 == 1)
                {
                    Debug.Log("Jugadores 3 y 4 repiten tirada");
                    turno = 10;
                    JD.text = ("Es turno del Jugador 3");
                    if (n1 > n2)
                    {
                        T1.text = ("1");
                        T2.text = ("2");
                        Debug.Log("Primer turno J1, Segundo Turno J2");
                    }
                    else
                    {
                        T2.text = ("1");
                        T1.text = ("2");
                        Debug.Log("Primer turno J2, Segundo Turno J1");
                    }
                }
                sit1 = 0;
                sit2 = 0;
                sit3 = 0;
                sit4 = 0;
                sit5 = 0;
                sit6 = 0;
                break;
            case 5:
                if(turno2== 1)
                {
                    r1 = UnityEngine.Random.Range(1, 4);
                    n1 = r1;
                    Nj1.text = "" + r1;
                    turno2++;
                    JD.text = ("Es turno del Jugador 2");
                }
                else if (turno2 == 2)
                {
                    r2 = UnityEngine.Random.Range(1, 4);
                    n1 = r2;
                    if (n1 == n2)
                    {
                        Debug.Log("Se repitio el tiro del J2");
                        goto case 5;
                    }
                    Nj2.text = "" + r2;
                    if (n1 > n2)
                    {
                        T1.text = ("3");
                        T2.text = ("4");
                        Debug.Log("Tercer turno J1, Cuarto Turno J2");
                    }
                    else
                    {
                        T2.text = ("4");
                        T1.text = ("3");
                        Debug.Log("Cuarto turno J2, Tercer Turno J1");
                    }
                    turno2++;
                }
                break;
            case 6:
                if (turno2 == 1)
                {
                    r1 = UnityEngine.Random.Range(1, 4);
                    n1 = r1;
                    Nj1.text = "" + r1;
                    turno2++;
                    JD.text = ("Es turno del Jugador 3");
                }
                else if (turno2 == 2)
                {
                    r3 = UnityEngine.Random.Range(1, 3);
                    n3 = r3;
                    if (n1 == n3)
                    {
                        Debug.Log("Se repitio el tiro del J3");
                        goto case 6;
                    }
                    Nj3.text = "" + r3;
                    if (n1 > n3)
                    {
                        T1.text = ("3");
                        T3.text = ("4");
                        Debug.Log("Tercer turno J1, Cuarto Turno J3");
                    }
                    else
                    {
                        T3.text = ("3");
                        T1.text = ("4");
                        Debug.Log("Tercer turno J3, Cuarto Turno J4");
                    }
                    turno2++;
                }
                break;
            case 7:
                if(turno2 == 1)
                {
                    r2 = UnityEngine.Random.Range(1, 4);
                    n2 = r2;
                    Nj2.text = "" + r2;
                    turno2++;
                    JD.text = ("Es turno del Jugador 2");
                }
                else if (turno2 == 2)
                {
                    r3 = UnityEngine.Random.Range(1, 3);
                    n3 = r3;
                    if (n2 == n3)
                    {
                        Debug.Log("Se repitio el tiro del J3");
                        goto case 7;
                    }
                    Nj3.text = "" + r3;
                    turno2++;
                    if (n2 > n3)
                    {
                        T2.text = ("3");
                        T3.text = ("4");
                        Debug.Log("Tercer turno J2, Cuarto Turno J3");
                    }
                    else
                    {
                        T3.text = ("3");
                        T2.text = ("4");
                        Debug.Log("Cuarto turno J3, Tercer Turno J2");
                    }
                }
                break;
            case 8:
                if (turno2 == 1)
                {
                    r1 = UnityEngine.Random.Range(1, 4);
                    n1 = r1;
                    Nj1.text = "" + r1;
                    turno2++;
                    JD.text = ("Es turno del Jugador 4");
                }
                else if (turno2 == 2)
                {
                    r4 = UnityEngine.Random.Range(1, 3);
                    n4 = r4;
                    if (n1 == n4)
                    {
                        Debug.Log("Se repitio el tiro del J4");
                        goto case 8;
                    }
                    Nj4.text = "" + r4;
                    if (n1 > n4)
                    {
                        T1.text = ("3");
                        T4.text = ("4");
                        Debug.Log("Tercer turno J1, Cuarto Turno J4");
                    }
                    else
                    {
                        T4.text = ("3");
                        T1.text = ("4");
                        Debug.Log("Cuarto turno J4, Tercer Turno J1");
                    }
                    turno2++;
                }
                break;
            case 9:
                if (turno2 == 1)
                {
                    r2 = UnityEngine.Random.Range(1, 4);
                    n2 = r2;
                    Nj2.text = "" + r2;
                    turno2++;
                    JD.text = ("Es turno del Jugador 2");
                }
                else if (turno2 == 2)
                {
                    r4 = UnityEngine.Random.Range(1, 3);
                    n4 = r4;
                    if (n2 == n4)
                    {
                        Debug.Log("Se repitio el tiro del J4");
                        goto case 9;
                    }
                    Nj4.text = "" + r4;
                    turno2++;
                    if (n2 > n4)
                    {
                        T2.text = ("3");
                        T4.text = ("4");
                        Debug.Log("Tercer turno J2, Cuarto Turno J4");
                    }
                    else
                    {
                        T4.text = ("3");
                        T2.text = ("4");
                        Debug.Log("Cuarto turno J4, Tercer Turno J2");
                    }
                }
                break;
            case 10:
                if (turno2 == 1)
                {
                    r3 = UnityEngine.Random.Range(1, 4);
                    n3 = r3;
                    Nj3.text = "" + r3;
                    turno2++;
                    JD.text = ("Es turno del Jugador 4");
                }
                else if (turno2 == 2)
                {
                    r4 = UnityEngine.Random.Range(1, 3);
                    n4 = r4;
                    if (n3 == n4)
                    {
                        Debug.Log("Se repitio el tiro del J4");
                        goto case 10;
                    }
                    Nj4.text = "" + r4;
                    if (n3 > n4)
                    {
                        T3.text = ("3");
                        T4.text = ("4");
                        Debug.Log("Tercer turno J3, Cuarto Turno J4");
                    }
                    else
                    {
                        T4.text = ("3");
                        T3.text = ("4");
                        Debug.Log("Cuarto turno J4, Tercer Turno J3");
                    }
                    turno2++;
                }
                break;
        }
        



    }
    void Start()
    {
                JD.text = "Es turno del jugador 1";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
