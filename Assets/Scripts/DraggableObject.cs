using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    // Update is called once per frame
    void Update()
    {
        // Check for mouse button press
        if (Input.GetMouseButtonDown(0))
        {
            // Perform a raycast to check if the mouse cursor is over this GameObject
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                isDragging = true;

                // Calculate the distance from the camera to the object to get the correct Z-coordinate
                float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

                // Calculate the offset between the mouse cursor and the GameObject's position
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen));
                offset = gameObject.transform.position - worldPoint;
            }
        }

        // Check for mouse button release
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Move the GameObject while dragging
        if (isDragging)
        {
            // Again, calculate the distance from the camera to the object
            float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

            // Translate the screen point to world point
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen));

            // Update the object's position
            gameObject.transform.position = worldPoint + offset;
        }
    }
}
