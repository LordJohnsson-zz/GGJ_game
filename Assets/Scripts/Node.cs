using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

    public bool StartNode = false;

    void Awake()
    {
        if (StartNode)
        {
            gameObject.tag = "StartNode";
        }
    }
}
