using UnityEngine;
using System.Collections;

public class btnTake : MonoBehaviour {

    PlayerController playerCtrl;

    void Awake()
    {
        playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void OnMouseDown()
    {
        playerCtrl.TakeItem();
    }
}
