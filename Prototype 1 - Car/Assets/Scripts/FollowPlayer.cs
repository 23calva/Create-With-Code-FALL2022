using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    public Vector3 Offset;

    void Start()
    {
        Offset = new Vector3(0, 5f, -10f);
    }

    void LateUpdate()
    {
        transform.position = Player.transform.position + Offset;
        //transform.rotation = Quaternion.Slerp(Player.transform.rotation, transform.rotation, 0.1f);
    }
}
