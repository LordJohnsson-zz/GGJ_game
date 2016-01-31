using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FollowDemonRoom1 : MonoBehaviour {

    Vector3 pos;
    Text text;

    public float msgDuration = 3;

    float counter;
    private bool dialogStarted;
    private bool eyesClosed = true;

    void Start()
    {
        text = GameObject.Find("PText").GetComponent<Text>();
        GameObject.Find("Parentsimg").GetComponent<Image>().enabled = false;

        pos = GameObject.Find("Demon").transform.position;
        pos.y += 5;
        transform.position = pos;
    }

    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(pos);

        if (!dialogStarted)
        {
            StartCoroutine(Dialog());
            dialogStarted = true;
        }

        if (Time.time > counter + msgDuration)
        {
            text.text = string.Empty;
            GameObject.Find("Parentsimg").GetComponent<Image>().enabled = false;
        }

        if (GameObject.Find("GoldenKey") != null)
        {
            if (GameObject.Find("GoldenKey").activeSelf && eyesClosed)
            {
                StartCoroutine(DialogAfter());
                eyesClosed = false;
            }
        }

    }
    public void SetMessage(string msg)
    {
        GameObject.Find("Parentsimg").GetComponent<Image>().enabled = true;
        text.text = msg;
        counter = Time.time;
    }
    IEnumerator Dialog()
    {
        GameObject.Find("TextBox").GetComponent<InspectBoxCtrl>().SetMessage("What happened? Where am I?");
        yield return new WaitForSeconds(3);
        GameObject.Find("TextBox").GetComponent<InspectBoxCtrl>().SetMessage("I wanted to summon a demon that could beat up all the dumb kids at school.");
        yield return new WaitForSeconds(3);
        GameObject.Find("TextBox").GetComponent<InspectBoxCtrl>().SetMessage("Or maybe light them on fire.");
        yield return new WaitForSeconds(3);
        GameObject.Find("TextBox").GetComponent<InspectBoxCtrl>().SetMessage("But seems like I got sucked into the demon’s world.");
        yield return new WaitForSeconds(3);
        SetMessage("An eye for an eye will make the whole world blind. :)");
        yield return new WaitForSeconds(3);
        GameObject.Find("TextBox").GetComponent<InspectBoxCtrl>().SetMessage("What?? What is this crap?");
    }

    IEnumerator DialogAfter()
    {
        SetMessage("Meditation is the golden key to all the mysteries of life. ^_^");
        yield return new WaitForSeconds(3);
        GameObject.Find("TextBox").GetComponent<InspectBoxCtrl>().SetMessage("Seriously, what’s up with you ? I figured demons would be more… demony..");
    }
}
