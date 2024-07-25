using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruta_Seccion_Escuela : MonoBehaviour
{
    Transform[] casillas_Escuela;
    public List<Transform> listaDeCasillas_Escuela = new List<Transform>();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        FillNodes();

        for (int i = 0; i < listaDeCasillas_Escuela.Count; i++)
        {
            Vector3 currentPos = listaDeCasillas_Escuela[i].position;
            if (i > 0)
            {
                Vector3 prevPos = listaDeCasillas_Escuela[i - 1].position;
                Gizmos.DrawLine(prevPos, currentPos);
            }
        }
    }

    void FillNodes()
    {
        listaDeCasillas_Escuela.Clear();
        casillas_Escuela = GetComponentsInChildren<Transform>();
        foreach (Transform t in casillas_Escuela)
        {
            if (t != this.transform)
            {
                listaDeCasillas_Escuela.Add(t);
            }
        }
    }
}
