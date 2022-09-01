using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    public Vector3 offset;

    void Start()
    {
        offset = new Vector3(0f, 5f, -15f);
    }

    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}
