using UnityEngine;

public class ConstantRotate : MonoBehaviour
{
    public float xRate, yRate, zRate = 0.0f;// Rotation speed in degrees per second

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its Y-axis at rotationSpeed degrees per second
        transform.Rotate(xRate * Time.deltaTime, yRate * Time.deltaTime, zRate * Time.deltaTime);
    }
}
