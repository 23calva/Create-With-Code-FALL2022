using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float Speed = 40f;

    void Update()
    {
        transform.Translate( Speed * Vector3.forward * Time.deltaTime );
    }
}
