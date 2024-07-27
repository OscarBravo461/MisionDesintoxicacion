using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruta_Seccion_Ciudad : MonoBehaviour
{
    Transform[] casillas_Ciudad;
    public List<Transform> listaDeCasillas_Ciudad = new List<Transform>();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        FillNodes();

        for (int i = 0; i < listaDeCasillas_Ciudad.Count; i++)
        {
            Vector3 currentPos = listaDeCasillas_Ciudad[i].position;
            if (i > 0)
            {
                Vector3 prevPos = listaDeCasillas_Ciudad[i - 1].position;
                Gizmos.DrawLine(prevPos, currentPos);
            }
        }
    }

    void FillNodes()
    {
        listaDeCasillas_Ciudad.Clear();
        casillas_Ciudad = GetComponentsInChildren<Transform>();
        foreach (Transform t in casillas_Ciudad)
        {
            if (t != this.transform)
            {
                listaDeCasillas_Ciudad.Add(t);
            }
        }
    }
}
