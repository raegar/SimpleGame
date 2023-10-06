using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0f; // Speed of the player movement
    private Vector3 targetPosition; // Target position to move to
    private bool isMoving = false; // Flag to check if the player should move

    // Start is called before the first frame update
    void Start()
    {
        // Initialize target position to current position
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Calculate the distance from the camera to the object
            float zDistance = transform.position.z - Camera.main.transform.position.z;

            // Convert mouse position to world coordinates using the calculated Z-distance
            targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));
            targetPosition.z = 0; // Reset z-coordinate to 0 as we're assuming a 2D game
            isMoving = true;
        }

        // Move the player towards the target position
        if (isMoving)
        {
            float step = speed * Time.deltaTime; // Calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Stop moving if the player reaches the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                isMoving = false;
            }
        }
    }
}
