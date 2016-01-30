using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

    [Header("Lisää polun nodet listaan scenestä\nvasemmalta oikealle!!!!")]
    [Space()]
    public List<Transform> PathNodes;

    void OnDrawGizmos()
    {
        if (PathNodes.Count != 0)
        {
            for (int i = 0; i < PathNodes.Count; i++)
            {
                if (i > 0 || i == PathNodes.Count)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(PathNodes[i].position, PathNodes[i - 1].position);
                }
            }
        }
    }

}
