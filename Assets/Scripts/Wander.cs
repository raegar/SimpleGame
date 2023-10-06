using UnityEngine;

public class Wander : MonoBehaviour
{
    public float speed = 3.0f;
    private Vector2 targetPosition;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        float zDistance = transform.position.z - Camera.main.transform.position.z;

        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zDistance));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, zDistance));

        minX = bottomLeft.x;
        maxX = topRight.x;
        minY = bottomLeft.y;
        maxY = topRight.y;

        // Initialize target position to current position
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // If the enemy reaches the target position, get a new target position
        if ((Vector2)transform.position == targetPosition)
        {
            GetNewTargetPosition();
        }
    }

    void GetNewTargetPosition()
    {
        // Generate a random target position within camera bounds
        targetPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }
}
