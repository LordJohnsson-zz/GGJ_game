using UnityEngine;
using System.Collections;

public class WalkableAreaCtrl : MonoBehaviour {

    public Texture2D walkIcon;

    void OnMouseEnter()
    {
        //Cursor.SetCursor(walkIcon, new Vector2(0.1f, 0.1f), CursorMode.Auto);
    }
    void OnMouseExit()
    {
        //Cursor.SetCursor(null, new Vector2(0.1f, 0.1f), CursorMode.Auto);
    }
}
