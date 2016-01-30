using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    [Range(0, 1)]
    public float playerSpeed;

    PolygonCollider2D walkableArea;
    Trigger targetTrigger;
    Vector3 targetPos;
    bool facingRight;

    void Awake()
    {
        walkableArea = GameObject.Find("WalkableArea").GetComponent<PolygonCollider2D>();
    }

    void Start () {

        Transform startNode = null;
        if (GameObject.FindGameObjectWithTag("StartNode") != null)
        {
            if (GameObject.FindGameObjectWithTag("StartNode").transform != null)
            {
                startNode = GameObject.FindGameObjectWithTag("StartNode").transform;
            }

            if (startNode != null)
            {
                transform.position = startNode.position;
            }
        }
        targetPos = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mouseDownPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseDownPos.z = transform.position.z;

            RaycastHit2D hit = Physics2D.Raycast(mouseDownPos, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Trigger")
                {
                    Transform[] walkTargets = hit.collider.GetComponentsInChildren<Transform>();
                    Vector3 closestWalkTarget = walkTargets[0].position;

                    foreach (var item in walkTargets)
                    {
                        if (Vector3.Distance(item.position, transform.position) < Vector3.Distance(closestWalkTarget, transform.position))
                        {
                            closestWalkTarget = item.position;
                        }
                    }

                    targetTrigger = hit.collider.GetComponent<Trigger>();

                    targetPos = closestWalkTarget;
                    targetPos.z = transform.position.z;
                }
                else
                {
                    if (walkableArea.OverlapPoint(mouseDownPos))
                    {
                        targetPos = mouseDownPos;
                        targetPos.z = transform.position.z;
                    }
                }
            }
            CheckFacing();
        }

        //Liikuta
        if (transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, playerSpeed);
            if (targetTrigger != null)
            {
                if (transform.position == targetPos)
                {
                    targetTrigger.Interract();
                    targetPos = transform.position;
                    targetTrigger = null;
                }
            }
        }
        SetFacing();
    }

    private void SetFacing()
    {
        Quaternion q;
        if (facingRight)
        {
            q = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            q = new Quaternion(0, 180, 0, 0);
        }
        transform.localRotation = q;
    }

    private void CheckFacing()
    {
        if (transform.position.x < targetPos.x)
        {
            facingRight = true;
        }
        if (transform.position.x > targetPos.x)
        {
            facingRight = false;
        }
    }
}
