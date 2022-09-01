using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 20f;
    public float TurnSpeed = 45f;

    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * Speed);
        transform.Rotate( Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * TurnSpeed);
    }
}
