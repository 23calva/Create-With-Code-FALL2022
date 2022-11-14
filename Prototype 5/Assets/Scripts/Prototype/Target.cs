using UnityEngine;

namespace Prototype
{
    public class Target : MonoBehaviour
    {
        private Rigidbody playerRB;

        public ParticleSystem explosionParticle;
        public int pointValue;

        private int minSpeed = 14;
        private int maxSpeed = 18;
        private int maxTorque = 10;
        private int xRange = 4;
        private int ySpawnPos = -6;

        private void Start()
        {
            playerRB = gameObject.GetComponent<Rigidbody>();
            playerRB.AddForce(RandomForce(), ForceMode.Impulse);
            playerRB.AddTorque(RandomTorque(), ForceMode.Impulse);
            transform.position = RandomStartPos();
        }

        private void OnMouseDown()
        {
            if(!GameManager.i.isGameActive)
                return;

            Destroy(gameObject);
            GameManager.i.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, transform.rotation);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(gameObject.GetComponent<Rigidbody>().velocity.y < Vector3.up.y && other.gameObject.name == "Sensor")
            {
                Destroy(gameObject);
                if (gameObject.CompareTag("Bad"))
                {
                    GameManager.i.GameOver();
                }
            }
        }

        private Vector3 RandomForce() => Vector3.up * Random.Range(minSpeed, maxSpeed);

        private Vector3 RandomTorque() => new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));

        private Vector3 RandomStartPos() => new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}