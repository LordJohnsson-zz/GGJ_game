using UnityEngine;
using System.Collections;

public class CandelScript : MonoBehaviour
{
    public GameObject candel;

    void OnMouseDown()
    {
        candel.SetActive(true);
        gameObject.SetActive(false);
    }

}