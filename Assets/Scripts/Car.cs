using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Vehicle
{
    // INHERITANCE

    private float horizontalInput;

    void FixedUpdate()
    {
        // get the user's horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);

        // turn the car left/right based on left/right arrow keys
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * horizontalInput);
    }
}
