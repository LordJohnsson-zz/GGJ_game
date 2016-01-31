using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FollowPlayer : MonoBehaviour
{
	public Vector3 offset;          // The offset at which the Health Bar follows the player.
	private Transform player;		// Reference to the player.
    Sprite bubble;

	void Awake ()
	{
        // Setting up the reference.
        player = GameObject.Find("Player").GetComponent<Transform>();
        bubble = GameObject.Find("bubbleImg").GetComponent<Image>().sprite;
	}

	void Update ()
	{
        var targetPos = Camera.main.WorldToScreenPoint(player.position + offset);
        transform.position = targetPos;
    }
}
