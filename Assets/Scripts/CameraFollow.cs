using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
    public GameObject playerObject;
    public SpriteRenderer background;
    
	public float xSmooth = 8f;		// How smoothly the camera catches up with it's target movement in the x axis.
	public float ySmooth = 8f;		// How smoothly the camera catches up with it's target movement in the y axis.

	private Transform playerTransform;		// Reference to the player's transform.

    void Awake ()
	{
        // Setting up the reference.
        playerTransform = playerObject.transform;
	}


	bool CheckXMargin()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - playerTransform.position.x) > 0;
	}

    bool CheckYMargin()
    {
        // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
        return Mathf.Abs(transform.position.y - playerTransform.position.y) > 0;
    }

    void Update ()
	{
		TrackPlayer();
	}
	
	
	void TrackPlayer ()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;

        // If the player has moved beyond the x and y margin...
        if (CheckXMargin())
        {
            // ... Lerp between the camera's current x position and the player's current x position.
            targetX = Mathf.Lerp(transform.position.x, playerTransform.position.x, xSmooth * Time.deltaTime);
        }

        if (CheckYMargin())
        {
            // ... Lerp between the camera's current x position and the player's current x position.
            targetY = Mathf.Lerp(transform.position.y, playerTransform.position.y, ySmooth * Time.deltaTime);
        }

        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
        targetX = Mathf.Clamp(targetX, ((horzExtent/2) + background.sprite.bounds.min.x), (background.sprite.bounds.max.x - (horzExtent/2))); targetX = Mathf.Clamp(targetX, ((horzExtent / 2) + background.sprite.bounds.min.x), (background.sprite.bounds.max.x - (horzExtent / 2)));
        targetY = Mathf.Clamp(targetY, ((vertExtent / 2) + background.sprite.bounds.min.y), (background.sprite.bounds.max.y - (vertExtent / 2)));
        
        // Set the camera's position to the target position with the same z component. Add some smoothness to the camera movement
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
