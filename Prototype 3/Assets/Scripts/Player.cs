using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip[] ExplosionSounds;
    public AudioClip[] JumpSounds;
    public ParticleSystem ExplosionFX;
    public ParticleSystem DirtFX;

    AudioSource AudioSource;
    Animator Animator;
    Rigidbody Body;

    [Space(16)]
    public bool GameOver;
    bool IsGrounded;
    float JumpForce = 100f;
    float GravityModifier = 2f;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
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
            AudioSource.PlayOneShot(GetRandomSound(JumpSounds));
            DirtFX.Stop();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            IsGrounded = true;

            DirtFX.Play();
        }
        else if (other.collider.CompareTag("Obstacle"))
        {
            GameOver = true;

            // Push the obstacle over.
            other.rigidbody.isKinematic = false;
            other.rigidbody.tag = "NoCollideWithPlayer";
            other.rigidbody.AddForce(Vector3.right * 10f, ForceMode.Impulse);

            // Animation
            Animator.SetBool("Death_b", true);
            Animator.SetInteger("DeathType_int", 1);
            // Sound
            AudioSource.PlayOneShot(GetRandomSound(ExplosionSounds));
            // Particles
            DirtFX.Stop();
            ExplosionFX.Play();
        }
    }

    AudioClip GetRandomSound( AudioClip[] audio )
    {
        int i = Random.Range(0, audio.Length);
        return audio[i];
    }
}
