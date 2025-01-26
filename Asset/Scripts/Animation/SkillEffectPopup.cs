using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectPopup : MonoBehaviour
{
    [SerializeField] float moveSpeed;    // Speed at which the object moves up
    [SerializeField] float stayTime;      // Time the object stays at the top
    [SerializeField] float moveDistance;  // How high the object moves before stopping

    private bool isMovingUp = true;
    private float distanceMoved = 0f;

    void Update()
    {
        // Move the object up
        if (isMovingUp)
        {
            float moveAmount = moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.up * moveAmount);

            distanceMoved += moveAmount;

            // Stop when the object has moved the specified distance
            if (distanceMoved >= moveDistance)
            {
                isMovingUp = false;
                Invoke("DestroyObject", stayTime);  // Delay destruction
            }
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);  // Destroy the object
    }
}
