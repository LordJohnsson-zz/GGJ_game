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
        gameObject.AddComponent<BoxCollider2D>();
    }

    void Interract()
    {
        GameObject.Find("TextBox").GetComponent<Text>().text = "<b>" + Name + "</b>" + "\n" + Info;
    }

    void OnMouseDown()
    {
        Interract();
    }

}
