using UnityEngine;
using System.Collections;

public class obtainKey : MonoBehaviour {

    private bool isCollected;

    void Start()
    {
        isCollected = true;
    }

	// Update is called once per frame
	void Update () {
        
        if (gameObject.GetComponent<Trigger>().Collected)
        {
            if (isCollected)
            {
                GameObject.Find("Octopussy").GetComponent<Animator>().SetBool("keyCollected", true);
                GameObject.Find("Octopussy").GetComponent<Animator>().SetBool("eyesClosed", false);
                gameObject.SetActive(false);
                isCollected = false;
            }
        }
        
	}
}
