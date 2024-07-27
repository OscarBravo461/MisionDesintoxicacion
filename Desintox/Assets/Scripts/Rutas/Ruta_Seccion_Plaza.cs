using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruta_Seccion_Plaza : MonoBehaviour
{
    Transform[] casillas_Plaza;
    public List<Transform> listaDeCasillas_Plaza = new List<Transform>();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        FillNodes();

        for (int i = 0; i < listaDeCasillas_Plaza.Count; i++)
        {
            Vector3 currentPos = listaDeCasillas_Plaza[i].position;
            if (i > 0)
            {
                Vector3 prevPos = listaDeCasillas_Plaza[i - 1].position;
                Gizmos.DrawLine(prevPos, currentPos);
            }
        }
    }

    void FillNodes()
    {
        listaDeCasillas_Plaza.Clear();
        casillas_Plaza = GetComponentsInChildren<Transform>();
        foreach (Transform t in casillas_Plaza)
        {
            if (t != this.transform)
            {
                listaDeCasillas_Plaza.Add(t);
            }
        }
    }
}
