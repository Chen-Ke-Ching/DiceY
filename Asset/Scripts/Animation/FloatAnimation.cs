using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAnimation : MonoBehaviour
{
    [SerializeField] float floatHeight = 0.5f;
    [SerializeField] float floatSpeed = 2f;

    Vector3 startPos;

    void Start()
    {
        // Record the initial position of the object
        startPos = transform.position;
    }

    void Update()
    {
        // Create a floating effect by using sine wave
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPos.x, startPos.y + newY, startPos.z);
    }
}
