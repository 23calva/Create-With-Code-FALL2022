using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float Maxs = 30f;
    public float Mins = -10f;

    void FixedUpdate()
    {
        foreach ( GameObject obj in GameObject.FindGameObjectsWithTag("Animal") )
        {
            TryDestroy(obj);
        }
        foreach ( GameObject obj in GameObject.FindGameObjectsWithTag("Food") )
        {
            TryDestroy(obj);
        }
    }

    void TryDestroy( GameObject obj )
    {
        if ( obj.transform.position.z > Maxs || obj.transform.position.z < Mins )
        {
            Destroy(obj);
        }
        else if (obj.transform.position.z < Mins )
        {
            Debug.Log("Game Over Nerd!");
            Destroy(obj);
        }
    }
}
