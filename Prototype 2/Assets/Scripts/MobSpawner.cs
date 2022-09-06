using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject[] Animals;
    float Range = 20f;

    public float StartDelay = 2f;
    public float SpawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating( "SpawnRandomAnimal", StartDelay, SpawnInterval );
    }

    void SpawnRandomAnimal()
    {
        int i = Random.Range( 0, Animals.Length );
        Vector3 pos = new Vector3(Random.Range( -Range, Range ), 0f, 30f );

        Instantiate( Animals[i], pos, Animals[i].transform.rotation );
    }
}
