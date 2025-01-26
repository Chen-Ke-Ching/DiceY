using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float scaleSpeed = 1f;
    [SerializeField] float maxScale = 2f;
    [SerializeField] float minScale = 1f;
    private bool isGrowing = true;
    void Update()
    {        
        transform.Rotate(0, 0, Mathf.Sin(rotationSpeed * Time.deltaTime));
                
        if (isGrowing)
        {
            transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;

            if (transform.localScale.x >= maxScale)
            {
                isGrowing = false;
            }
        }
        else
        {
            transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;

            if (transform.localScale.x <= minScale)
            {
                isGrowing = true;
            }
        }
    }
}
