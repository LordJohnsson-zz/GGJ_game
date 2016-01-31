using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ActivateSymbol : MonoBehaviour {

    public static bool mouseDown;
    public GameObject[] candels;

    private Vector3 mouseDownPosition;

    Ray2D ray;
    RaycastHit2D hit;
    private bool firstCollision;
    private Vector2 lineStartPos;
    private Vector2 lineEndPos;
    private LineRenderer newLine;
    private bool drawLine;
    private List<Vector3> positionList = new List<Vector3>();

    // Update is called once per frame
    void Update () {
        
        if (Input.GetMouseButton(0))
        {
            mouseDownPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            mouseDownPosition.z = 0;

            hit = Physics2D.Raycast(mouseDownPosition, Vector2.zero);
            //Debug.Log("TESTI Hit " + hit.collider.gameObject);

            if (hit.collider.gameObject != null)
            {
                Debug.Log("TESTI Collider");
                foreach (var candel in candels)
                {
                    if (hit.collider.gameObject.name == candel.name)
                    {
                        if(!positionList.Contains(hit.collider.transform.position))
                        {
                            Debug.Log("TESTI!");
                            positionList.Add(hit.collider.transform.position);
                            GetComponent<LineRenderer>().SetPositions(positionList.ToArray());
                        }
                    }
                }

                if (hit.collider.gameObject.name == "Candel")
                {
                    if (!drawLine)
                    {
                        if (firstCollision)
                        {
                            lineStartPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                            firstCollision = false;
                        }
                        else
                        {
                            lineEndPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                            drawLine = true;
                        }
                    }
                    else
                    {
                        newLine.SetPosition(0, lineStartPos);
                        newLine.SetPosition(1, lineEndPos);
                        drawLine = false;
                    }
                    
                }
            }
        }
	}

    void OnPointerDown()
    {
        mouseDown = true;
    }
    void OnPointerUp()
    {
        mouseDown = false;
    }
}
