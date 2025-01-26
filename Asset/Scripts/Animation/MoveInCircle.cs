using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInCircle : MonoBehaviour
{
    [SerializeField] float radius = 5f;         // Radius of the circle
    [SerializeField] float speed = 2f;          // Speed of movement (how fast it completes the circle)
    [SerializeField] Vector3 centerPoint = Vector3.zero;  // The center of the circle (could be the object's current position)

    private float angle = 0f;

    void Update()
    {
        // Calculate the new position in a circle using sin and cos
        angle += speed * Time.deltaTime; // Increase the angle based on time and speed

        // Use Sin and Cos to calculate the x and z positions
        float x = centerPoint.x + Mathf.Cos(angle) * radius;
        float y = centerPoint.y + Mathf.Sin(angle) * radius;

        // Update the position of the object
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
