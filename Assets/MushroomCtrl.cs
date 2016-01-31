using UnityEngine;
using System.Collections;

public class MushroomCtrl : MonoBehaviour {

    SleepingDem sleep;
    bool triggered = false;



    void Awake()
    {
        GetComponent<Animator>().speed = 0;
    }

    void Start()
    {
        sleep = GameObject.Find("Nukkuva").GetComponent<SleepingDem>();
    }
    void Update() { 
        if (sleep.toTea && !triggered)
	    {
            triggered = true;
            GetComponent<Animator>().speed = 1;
            GetComponent<Collider2D>().enabled = false;
	    }
    }

}
