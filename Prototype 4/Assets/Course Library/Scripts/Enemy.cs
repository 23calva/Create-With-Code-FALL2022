using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody body;
    private GameObject player;

    private void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        body.AddForce(lookDirection * speed);

        if(transform.position.y < -10f) Destroy(this.gameObject);
    }
}
