using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FollowParents : MonoBehaviour {

    Vector3 pos;
    Text text;

    public float msgDuration = 3;

    float counter;
    private bool dialogStarted;

    void Start()
    {
        text = GameObject.Find("PText").GetComponent<Text>();
        GameObject.Find("Parentsimg").GetComponent<Image>().enabled = false;

        pos = GameObject.Find("Parents").transform.position;
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
    }
    public void SetMessage(string msg)
    {
        GameObject.Find("Parentsimg").GetComponent<Image>().enabled = true;
        text.text = msg;
        counter = Time.time;
    }
    IEnumerator Dialog()
    {
        GameObject.Find("TextBox").GetComponent<InspectBoxCtrl>().SetMessage("Morning.");
        yield return new WaitForSeconds(3);
        SetMessage("Happy 16th birthday dear!");
        yield return new WaitForSeconds(3);
        SetMessage("We got you a present, go up to the attic.");
        yield return new WaitForSeconds(3);
        GameObject.Find("TextBox").GetComponent<InspectBoxCtrl>().SetMessage("K.");
    }
}
