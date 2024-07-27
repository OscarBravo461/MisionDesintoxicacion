using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruta_Seccion_Parque : MonoBehaviour
{
    Transform[] casillas_Parque;
    public List<Transform> listaDeCasillas_Parque = new List<Transform>();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        FillNodes();

        for (int i = 0; i < listaDeCasillas_Parque.Count; i++)
        {
            Vector3 currentPos = listaDeCasillas_Parque[i].position;
            if (i > 0)
            {
                Vector3 prevPos = listaDeCasillas_Parque[i - 1].position;
                Gizmos.DrawLine(prevPos, currentPos);
            }
        }
    }

    void FillNodes()
    {
        listaDeCasillas_Parque.Clear();
        casillas_Parque = GetComponentsInChildren<Transform>();
        foreach (Transform t in casillas_Parque)
        {
            if (t != this.transform)
            {
                listaDeCasillas_Parque.Add(t);
            }
        }
    }
}
