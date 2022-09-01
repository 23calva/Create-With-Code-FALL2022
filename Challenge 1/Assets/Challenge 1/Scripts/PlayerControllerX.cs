using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject Propeller;

    public float Speed = 20f;
    public float RotationSpeed = 60f;

    void Start()
    {
        Propeller = GameObject.Find("Propeller");
    }

    void FixedUpdate()
    {
        // move the plane forward at a constant rate
        transform.Translate( Vector3.forward * Speed * Time.deltaTime);

        // tilt the plane left/right based on up/down keys
        transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * RotationSpeed * Time.deltaTime);

        // tilt the plane up/down based on up/downkeys
        transform.Rotate(Input.GetAxis("Vertical") * Vector3.right * RotationSpeed * Time.deltaTime);

        Propeller?.transform.Rotate(Vector3.forward, 10f);
    }
}
