using UnityEngine;

public class Background : MonoBehaviour
{
    public float Speed = 30f;
    public float XRepeat = -27f;

    void Update()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);

        if (transform.position.x < XRepeat)
            transform.position = new Vector3(45f, transform.position.y, transform.position.z);
    }
}
