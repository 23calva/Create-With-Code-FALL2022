using UnityEngine;

public class Player : MonoBehaviour
{
    Animator Animator;
    Rigidbody Body;

    float JumpForce = 10f;
    float GravityModifier = 2f;

    bool IsGrounded;
    public bool GameOver;

    void Start()
    {
        Animator = GetComponent<Animator>();
        Body = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
    }

    void Update()
    {
        if (GameOver) return;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            IsGrounded = false;
            Body.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            Animator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
        else if (other.collider.CompareTag("Obstacle"))
        {
            GameOver = true;

            // Push the obstacle over.
            other.rigidbody.isKinematic = false;
            other.rigidbody.tag = "NoCollideWithPlayer";
            other.rigidbody.AddForce(Vector3.right * 10f, ForceMode.Impulse);

            Animator.SetBool("Death_b", true);
            Animator.SetInteger("DeathType_int", 1);
        }
    }
}
