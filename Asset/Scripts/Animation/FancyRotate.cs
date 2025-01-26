using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyRotate : MonoBehaviour
{
    [SerializeField] float maxRotationSpeed = 360f;  // Initial fast rotation speed in degrees per second
    [SerializeField] float decelerationTime = 3f;    // Time to slow down completely (in seconds)
    [SerializeField] float directionChangeTime = 5f; // Time when the rotation direction will change

    float currentSpeed;
    float timeElapsed;
    bool rotatingClockwise = true;

    void Start()
    {
        // Initialize current speed to max rotation speed
        currentSpeed = maxRotationSpeed;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        // Decelerate the rotation speed over time
        if (timeElapsed < decelerationTime)
        {
            currentSpeed = Mathf.Lerp(maxRotationSpeed, 0f, timeElapsed / decelerationTime);
        }
        else
        {
            currentSpeed = 0f; // Stop rotation once deceleration is complete
        }

        // Change the rotation direction after a set time
        if (timeElapsed > directionChangeTime)
        {
            rotatingClockwise = !rotatingClockwise; // Reverse the direction
            timeElapsed = 0f; // Reset timer for the next cycle
            currentSpeed = maxRotationSpeed; // Start rotating fast again
        }

        // Rotate the object
        float rotationDirection = rotatingClockwise ? 1f : -1f;
        transform.Rotate(Vector3.forward, currentSpeed * rotationDirection * Time.deltaTime);
    }
}
