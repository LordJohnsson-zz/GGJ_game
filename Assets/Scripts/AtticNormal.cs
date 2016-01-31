using UnityEngine;
using System.Collections;

public class AtticNormal : MonoBehaviour {

    Trigger BookCollected;

    bool started = false;

    void Start()
    {
        BookCollected = GameObject.Find("book").GetComponent<Trigger>();
    }

    void Update()
    {
        if (BookCollected.Collected && !started)
        {
            StartCoroutine(SendMessage());
            started = true;
        }
    }

    IEnumerator SendMessage()
    {
        print("YOLO");
        GameObject.Find("TextBox").GetComponent<InspectBoxCtrl>().SetMessage("Ooh, a Demon Summoning Handbook?! Finally they treat me like an adult…!");
        yield return new WaitForSeconds(3);
        GameObject.Find("TextBox").GetComponent<InspectBoxCtrl>().SetMessage("I want to summon myself a demon that will fulfil all my dreams and destroy all my enemies.");
        yield return new WaitForSeconds(3);
        GameObject.Find("TextBox").GetComponent<InspectBoxCtrl>().SetMessage("The book says I should light all the five candles to summon the demon. Let’s get to it!");
    }
}
