using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    float leftLimit = -30;
    float bottomLimit = -5;

    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }
    }
}
