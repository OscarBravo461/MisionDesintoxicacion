using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MusicChangeTrigger : MonoBehaviour
{


    public GameObject Zona;
    int area;

    private void OnTriggerEnter2D(Collider2D collider)
    {

        Debug.Log("Trigger");
        if (collider.tag.Equals("Player1"))
        {
            string nombre =Zona.tag.ToString();
            Debug.Log(nombre);
            switch (nombre)
            {
                case "Ciudad":
                    area = 5;
                    break;
                case "Escuela":
                    area = 4;
                    break;
                case "Plaza":
                    area = 1;
                    break;
                case "Parque":
                    area = 2;
                    break;
            }
            AudioManager.instance.SetMusicArea(area);
            Debug.Log(area);
            Debug.Log("cambio");
        }
        
    }
}
