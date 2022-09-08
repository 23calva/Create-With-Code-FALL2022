using UnityEngine;

public class Background : MonoBehaviour
{
    Player Player;

    public float Speed = 30f;
    public float XRepeat = -27f;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (Player.GameOver)
        {
            CancelInvoke();
            return;
        }

        transform.Translate(Vector3.left * Speed * Time.deltaTime);

        if (transform.position.x < XRepeat)
            transform.position = new Vector3(45f, transform.position.y, transform.position.z);
    }
}
