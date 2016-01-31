using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour {

    public TriggerType type;
    public string Name = "Joku esine";
    [TextArea(4,100)]
    public string Info = "Tämä esine näyttää vanhalta";
    public string targetSceneName;
    public string targetSceneStartPoint;

    public bool isObjective = false;

    public Trigger Required;
    public bool Collected = false;
    public bool zoomOnMouseOver = false;
    public bool dontDismiss = false;

    public Texture2D interactIcon;
    public Texture2D walkToIcon;
    public Texture2D sceneChangeIcon;

    void Awake()
    {
        if (gameObject.GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }
        gameObject.tag = "Trigger";
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void Interract()
    {
        if (type == TriggerType.InteractableObj)
        {
            if (Info != string.Empty)
            {
                GameObject.Find("TextBox").GetComponent<InspectBoxCtrl>().SetMessage(Info);
            }
            if (isObjective)
            {
                Collected = true;
                if (!dontDismiss)
                {
                    if (GetComponent<SpriteRenderer>() != null)
                    {
                        GetComponent<SpriteRenderer>().enabled = false;
                    }
                    GetComponent<Collider2D>().enabled = false;
                }
            }
        }
        else if (type == TriggerType.Trasition)
        {
            if (Required != null)
            {
                if (Required.Collected)
                {
                    StartCoroutine(FadeOut());
                }
                else
                {
                    GameObject.Find("TextBox").GetComponent<InspectBoxCtrl>().SetMessage(Info);
                }
            }
            else
            {
                StartCoroutine(FadeOut());
            }
        }
    }

    IEnumerator FadeOut()
    {
        Animator fadeAnim = GameObject.Find("FadeImage").GetComponent<Animator>();
        fadeAnim.Play("fadeToBlack");
        yield return new WaitForSeconds(1);
        if (targetSceneName != string.Empty)
        {
            PlayerPrefs.SetString("startPoint", targetSceneStartPoint);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            SceneManager.LoadScene(targetSceneName);
        }
    }

    public void AddToInventory()
    {
        
    }

    void OnMouseEnter()
    {
        if (zoomOnMouseOver)
        {
            var scale = transform.localScale * 1.05f;
            transform.localScale = scale;
        }
        //if (type == TriggerType.InteractableObj)
        //{
        //    Cursor.SetCursor(interactIcon, new Vector2(0,0), CursorMode.Auto);
        //}
        if (type == TriggerType.Trasition)
        {
            Cursor.SetCursor(sceneChangeIcon, new Vector2(0, 0), CursorMode.Auto);
        }
    }

    void OnMouseExit()
    {

        if (zoomOnMouseOver)
        {
            var scale = transform.localScale * .95f;
            transform.localScale = scale;
        }
        if (type == TriggerType.Trasition)
        {
            Cursor.SetCursor(null, new Vector2(0, 0), CursorMode.Auto);
        }
    }
}
