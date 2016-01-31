using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Kitchen")
        {
            print(SceneManager.GetActiveScene().name + ", "+ PlayerPrefs.GetString("startPoint"));
            if (PlayerPrefs.GetString("startPoint") != "rightEntrance" || PlayerPrefs.GetString("startPoint") == null || PlayerPrefs.GetString("startPoint") == string.Empty)
            {
                PlayerPrefs.SetString("startPoint", "leftEntrance");
                facingRight = true;
            }
        }
        string startPosGO = PlayerPrefs.GetString("startPoint");
        Vector3 startPos = GameObject.Find(startPosGO).GetComponent<Transform>().position;
        transform.position = startPos;
        targetPos = transform.position;
    }

    //void Start () {

    //    Transform startNode = null;
    //    if (GameObject.FindGameObjectWithTag("StartNode") != null)
    //    {
    //        if (GameObject.FindGameObjectWithTag("StartNode").transform != null)
    //        {
    //            startNode = GameObject.FindGameObjectWithTag("StartNode").transform;
    //        }

    //        if (startNode != null)
    //        {
    //            transform.position = startNode.position;
    //        }
    //    }
        
    //}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetTrigger = null;
            Vector3 mouseDownPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
                    targetTrigger = null;
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
            GetComponent<Animator>().SetBool("isWalking", true);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, playerSpeed);
        }
        else
        {
            if (targetTrigger != null)
            {
                if (transform.position == targetPos)
                {
                    //käännä objektia kohti
                    if (targetPos.x < targetTrigger.transform.position.x)
                    {
                        facingRight = true;
                    }
                    else if (targetPos.x == targetTrigger.transform.position.x)
                    {
                        //Do nothing
                    }
                    else
                    {
                        facingRight = false;
                    }

                    targetPos = transform.position;
                    targetTrigger.Interract();

                    targetTrigger = null;
                    GetComponent<Animator>().SetBool("isWalking", false);
                }
            }
            GetComponent<Animator>().SetBool("isWalking", false);
        }

        SetFacing();
    }

    public void TakeItem()
    {
        if (targetTrigger != null)
        {
            targetTrigger.AddToInventory();
        }
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
