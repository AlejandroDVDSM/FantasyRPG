using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontCrossBounds : MonoBehaviour
{
    [SerializeField] private float leftBound;
    [SerializeField] private float rightBound;

    private void Update()
    {
        if (transform.position.x >= rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, 0);
        } else if (transform.position.x <= leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, 0);
        }
    }
}
