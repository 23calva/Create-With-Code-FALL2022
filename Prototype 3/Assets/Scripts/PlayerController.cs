using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody Body;

    float JumpForce = 10f;
    float GravityModifier = 2f;

    bool IsGrounded;

    void Start()
    {
        Body = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            IsGrounded = false;
            Body.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        IsGrounded = true;
    }
}
