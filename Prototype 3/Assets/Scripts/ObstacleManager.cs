using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] Prefabs;
    public Vector3 StartPos;

    float SpawnDelay = 2f;
    float SpawnRate = 2f;

    float XRange = -10f;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", SpawnDelay, SpawnRate );
    }

    void Update()
    {
        foreach (var obj in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            obj.transform.Translate(Vector3.left * 10f * Time.deltaTime);

            if (obj.transform.position.x < XRange)
                Destroy(obj);
        }
    }

    void SpawnObstacle()
    {
        int rnd = Random.Range(0, Prefabs.Length);
        var obj = Instantiate(Prefabs[rnd], StartPos, Prefabs[rnd].transform.rotation);
    }
}
