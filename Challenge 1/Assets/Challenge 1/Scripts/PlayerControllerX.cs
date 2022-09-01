using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    void Start()
    {

    }

    void FixedUpdate()
    {
        // move the plane forward at a constant rate
        transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * speed * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Input.GetAxis("Horizontal") * Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
