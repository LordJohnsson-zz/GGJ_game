using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TeademonDialog : MonoBehaviour {

    Vector3 pos;
    Text text;

    public float msgDuration = 3;

    float counter;
    private bool dialogStarted;

    Trigger teademon;

    bool pressedTheTea = false;

    void Start()
    {
        text = GameObject.Find("PText").GetComponent<Text>();
        GameObject.Find("Parentsimg").GetComponent<Image>().enabled = false;

        pos = GameObject.Find("TeaDemon").transform.position;
        pos.y += 4;
        pos.x += 4;
        transform.position = pos;
        teademon = GameObject.Find("TeaDemon").GetComponent<Trigger>();
    }

    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(pos);

        if (teademon.Collected && !pressedTheTea)
        {
            StartCoroutine(FirstDialog());
            pressedTheTea = true;
        }

        if (Time.time > counter + msgDuration)
        {
            text.text = string.Empty;
            GameObject.Find("Parentsimg").GetComponent<Image>().enabled = false;
        }
    }
    public void SetMessage(string msg)
    {
        GameObject.Find("Parentsimg").GetComponent<Image>().enabled = true;
        text.text = msg;
        counter = Time.time;
    }

    IEnumerator FirstDialog()
    {
        SetMessage("Strange how a teapot can represent at the same time the comforts of solitude and the pleasures of company.");
        yield return new WaitForSeconds(3);
    }
}
