using UnityEngine;
using System.Collections;

public class demon2main : MonoBehaviour {

    Trigger teademon;

    bool pressedTheTea = false;

    void Start()
    {
        teademon = GameObject.Find("TeaDemon").GetComponent<Trigger>();
    }
	
	// Update is called once per frame
	void Update () {
        if (teademon.Collected && !pressedTheTea)
        {
            StartCoroutine(FirstDialog());
            pressedTheTea = true;
        }
	}

    IEnumerator FirstDialog()
    {
        yield return new WaitForSeconds(1);
    }
}
