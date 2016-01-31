using UnityEngine;
using System.Collections;

public class dRoom1Main : MonoBehaviour {

    public GameObject key;
    public GameObject[] demonEyes;

    public int counter;

    private bool eyesActivated;

    void Start()
    {
        eyesActivated = true;
    }

    // Update is called once per frame
    void Update () {

        counter = 0;

        foreach (var eyes in demonEyes)
        {
            if (eyes.activeSelf)
            {
                counter++;
            }
        }

        if (counter == 4)
        {
            if (eyesActivated)
            {
                key.SetActive(true);
                GameObject.Find("Octopussy").GetComponent<Animator>().SetBool("eyesClosed", true);
                eyesActivated = false;
            }
        }
       
	}
}
