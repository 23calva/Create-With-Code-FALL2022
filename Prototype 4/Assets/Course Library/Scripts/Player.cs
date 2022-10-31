using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject powerupIndicator;
    private Rigidbody body;
    private GameObject focalPoint;
    public float speed;
    public bool hasPowerup;
    public float powerupStrength = 15f;

    private void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {
        var input = Input.GetAxis("Vertical");
        body.AddForce(input * speed * focalPoint.transform.forward);

        powerupIndicator.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            var enemyBody = collision.gameObject.GetComponent<Rigidbody>();
            var distance = collision.gameObject.transform.position - transform.position;

            Debug.Log($"Collided with {collision.gameObject.name} with powerup set to {hasPowerup}");

            enemyBody.AddForce(distance * powerupStrength, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }
}
