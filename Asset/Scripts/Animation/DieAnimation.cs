using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DieAnimation : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float moveDuration;
    public Vector3 moveDirection = Vector3.up;
    float startTime;
    bool isMoving = false; // To track if the object should be moving

    void Start()
    {
        // Use a coroutine to delay the movement until the next frame to ensure proper initialization
        StartCoroutine(InitializeMovement());
    }

    // Coroutine to initialize movement after the first frame
    private IEnumerator InitializeMovement()
    {
        // Wait for the next frame before starting the movement
        yield return null;

        // After waiting a frame, start the movement
        startTime = Time.time; // Record the start time when movement begins
        isMoving = true; // Start moving the object
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // Move the object as long as it's allowed to move
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            // Check if the movement duration has passed
            if (Time.time - startTime >= moveDuration)
            {
                // Stop the movement by setting isMoving to false
                isMoving = false;
            }
        }
    }
}
