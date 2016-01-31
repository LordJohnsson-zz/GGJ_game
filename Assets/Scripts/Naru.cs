using UnityEngine;
using System.Collections;

public class Naru : MonoBehaviour {

    Trigger naru;

    void Start()
    {
        naru = GameObject.Find("naru").GetComponent<Trigger>();
    }

    void Update()
    {
        if (naru.Collected)
        {
            Pull();
        }
    }

    void Pull()
    {
        GameObject.Find("tikkaat").GetComponent<Animator>().enabled = true;
    }
}
