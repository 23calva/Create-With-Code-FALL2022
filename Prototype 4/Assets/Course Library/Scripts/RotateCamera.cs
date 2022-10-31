using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;

    void Update()
    {
        var input = Input.GetAxis("Horizontal");
        transform.Rotate(-input * rotationSpeed * Time.deltaTime * Vector3.up);
    }
}
