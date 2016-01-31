using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InspectBoxCtrl : MonoBehaviour {

    Text text;

    public float msgDuration = 3;

    float counter;

    void Update()
    {
        if (Time.time > counter + msgDuration)
        {
            text.text = string.Empty;
            GameObject.Find("bubbleImg").GetComponent<Image>().enabled = false;
        }
    }

    void Awake()
    {
        text = GetComponent<Text>();
        GameObject.Find("bubbleImg").GetComponent<Image>().enabled = false;
    }

    public void SetMessage(string msg)
    {
        GameObject.Find("bubbleImg").GetComponent<Image>().enabled = true;
        text.text = msg;
        counter = Time.time;
    }
	
}
