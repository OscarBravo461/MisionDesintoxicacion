using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GCJuego_T3 : MonoBehaviour
{
    // Declarando los GameObjects de la indicacion de que jugador tirara el dado, el numero que saquen y el turno solamente para poder tener un orden con los dados
    public TextMeshProUGUI JD;
    public TextMeshProUGUI Nj1;
    public TextMeshProUGUI Nj2;
    public TextMeshProUGUI Nj3;
    public TextMeshProUGUI Nj4;
    public int turno = 1;
    public int n1 = 0;
    public int n2 = 0;
    public int n3 = 0;
    public int n4 = 0;
    
    public void generar_random_jugadores()
    {
        bool repetido=false;
        switch (turno)
        {
            case 1:
                int r1 =Random.Range(1, 4);
                n1= r1;
                Nj1.text = ""+r1;
                turno++;
                break;
            case 2:
                int r2 =Random.Range(1, 4);
                n2=r2;
                if (!repetido)
                {
                    if (n1 == r2)
                    {
                        repetido = true;
                    }

                }
                else
                {
                    if (n1 == r2)
                    {
                        goto case 2;
                    }
                }
                Nj2.text = "" + r2;
                turno++;
                break;
            case 3:
                int r3 =Random.Range(1, 4);
                n3 = r3;
                if (!repetido)
                {
                    if (n1 == r3)
                    {
                        repetido = true;
                    }
                    if (n2 == r3)
                    {
                        repetido = true;
                    }

                }
                else
                {
                    if (n1 == r3)
                    {
                        goto case 3;
                    }
                    if (n2 == r3)
                    {
                        goto case 3;
                    }
                }
                Nj3.text = "" + r3;
                turno++;
                break;
            case 4:
                int r4 =Random.Range(1, 4);
                n4 = r4;
                if (!repetido)
                {
                    if (n1 == r4)
                    {
                        repetido = true;
                    }
                    if (n2 == r4)
                    {
                        repetido = true;
                    }
                    if (n3 == r4)
                    {
                        repetido = true;
                    }

                }
                else
                {
                    if (n1 == r4)
                    {
                        goto case 4;
                    }
                    if (n2 == r4)
                    {
                        goto case 4;
                    }
                    if (n3 == r4)
                    {
                        goto case 4;
                    }
                }
                Nj4.text = "" + r4;
                turno++;
                break;
        }
        



    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
