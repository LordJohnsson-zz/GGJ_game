using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Trigger : MonoBehaviour {

    public TriggerType type;
    public string Name = "Joku esine";
    [TextArea(4,100)]
    public string Info = "Tämä esine näyttää vanhalta";

    void Awake()
    {
        if (gameObject.GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }
        gameObject.tag = "Trigger";
    }

    public void Interract()
    {
        StopCoroutine(ClearTextBox());
        GameObject.Find("TextBox").GetComponent<Text>().text = "<b>" + Name + "</b>" + "\n" + Info;
        StartCoroutine(ClearTextBox());
    }

    IEnumerator ClearTextBox()
    {
        yield return new WaitForSeconds(3);
        GameObject.Find("TextBox").GetComponent<Text>().text = string.Empty;
    }

    void OnMouseEnter()
    {
        transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
    }
    void OnMouseExit()
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
}
