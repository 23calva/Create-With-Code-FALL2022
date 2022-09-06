using UnityEngine;

public class FoodCollision : MonoBehaviour
{
    void OnTriggerEnter( Collider other )
    {
        // Ground was getting deleted, can't have that now can we?
        if (!other.CompareTag("Animal"))
            return;

        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
