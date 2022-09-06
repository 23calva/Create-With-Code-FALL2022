using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Food;
    public float Speed = 20f;
    float Range = 20f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate( horizontal * Speed * Vector3.right * Time.deltaTime );

        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, - Range, Range);
        transform.position = pos;

        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            Instantiate(Food, transform.position, Food.transform.rotation);
        }
    }
}
