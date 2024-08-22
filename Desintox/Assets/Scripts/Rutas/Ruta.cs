using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruta : MonoBehaviour
{
    Transform[] casillas;
    public List<Transform> listaDeCasillas = new List<Transform>();

    private void OnDrawGizmos() //Se utiliza para dibujar la línea guía
    {
        Gizmos.color = Color.blue;
        FillNodes();

        for (int i = 0; i < listaDeCasillas.Count; i++)
        {
            Vector3 currentPos = listaDeCasillas[i].position;
            if (i > 0)
            {
                Vector3 prevPos = listaDeCasillas[i - 1].position;
                Gizmos.DrawLine(prevPos, currentPos);
            }
        }
    }

    void FillNodes() //Se utiliza para obtener todos los transforms (coordenadas) de cada casilla y ponerlos en una lista
    {
        listaDeCasillas.Clear();
        casillas = GetComponentsInChildren<Transform>();
        foreach (Transform t in casillas)
        {
            if (t != this.transform)
            {
                listaDeCasillas.Add(t);
            }
        }
    }
}
