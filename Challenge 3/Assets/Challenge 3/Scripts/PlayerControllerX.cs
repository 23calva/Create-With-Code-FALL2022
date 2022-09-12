using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    float gravityModifier = 1f;
    Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bumpSound;

    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }

    void Update()
    {
        if (gameOver) return;

        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * floatForce * Time.deltaTime);
        }
        // Player cannot go above y level 14 or below 4. If so, remove velocity.
        var pos = transform.position;
        if (transform.position.y > 14f)
        {
            transform.position = new Vector3(pos.x, 14f, pos.z);
            playerRb.velocity = Vector3.zero;
        }
        else if (transform.position.y < 4f)
        {
            transform.position = new Vector3(pos.x, 4f, pos.z);
            playerRb.velocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            playerAudio.PlayOneShot(bumpSound, 1.0f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 
        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        }
    }
}
