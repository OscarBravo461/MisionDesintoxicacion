using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCJuego_T3 : MonoBehaviour
{
    //Varible que va a sacar la ubicacion del objeto a enfocar
    GameObject objetivo;
    //Varible para decidir numericamente que objeto dentro del juego va a ser el que se enfoque
    public int objetivo_camara = 0;


    //Metodo que mediante de un switch busca los objetos a enfocar usando las tags que tenga el mismo, el cambio de enfoque es suave y no instantaneo
    private void Seguir()
    {
        switch (objetivo_camara)
        {
            case 0:
                objetivo = GameObject.FindGameObjectWithTag("camaralibre");
                break;
            case 1:
                objetivo = GameObject.FindGameObjectWithTag("Player1");
                break;
            case 2:
                objetivo = GameObject.FindGameObjectWithTag("Player2");
                break;
            case 3:
                objetivo = GameObject.FindGameObjectWithTag("Player3");
                break;
            case 4:
                objetivo = GameObject.FindGameObjectWithTag("Player4");
                break;
        }
        //Estas lineas cambian en la Virtual camara el objeto designado que debe seguir
        CinemachineVirtualCamera cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        cinemachineVirtualCamera.m_Follow = objetivo.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        Seguir();
    }

    // Update is called once per frame
    void Update()
    {
        //Como los cambios son en tiempo real llamo el metodo aqui, solo con cambiar la variable de "objetivo_camara" desde el CamaraController en Unity se deberia cambiar el enfoque

        //nota: En el juego final con que se mande a llamar el metodo con cambio de turno deberia bastar ya que
        //CineMachine hace el seguimiento del objetivo automaticamente sin necesidad de actualizar las 
        //coordenadas de la camara directamente, solo del objeto
        Seguir();
    }
}
