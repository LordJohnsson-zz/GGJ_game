using UnityEngine;
using System.Collections;

public class SleepingDem : MonoBehaviour {


    Trigger teademon;
    public bool triggered = false;
    public Sprite kannu;

    public bool toTea = false;

    void Awake()
    {
        GetComponent<Animator>().speed = 0;
    }

    void Start()
    {
        teademon = GameObject.Find("TeaDemon").GetComponent<Trigger>();
    }
    void Update()
    {
        if (teademon.Collected && !triggered)
        {
            triggered = true;
            GetComponent<Animator>().speed = 1;
        }
    }

    void OnMouseDown()
    {
        print("shieet");
        if (triggered)
        {
            GetComponent<Animator>().enabled = false;
            GameObject.Find("Nukkuva").GetComponent<Trigger>().Info = string.Empty;
            GetComponent<SpriteRenderer>().sprite = kannu;
            toTea = true;
        }
    }
}
