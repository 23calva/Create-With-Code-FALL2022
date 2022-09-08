using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] Prefabs;
    public Player Player;

    Vector3 SpawnPos = Vector3.right * 25f;
    float SpawnDelay = 2f, SpawnRate = 2f;
    float XRange = -10f, YRange = -3f;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", SpawnDelay, SpawnRate );
    }

    void Update()
    {
        if ( Player.GameOver )
        {
            CancelInvoke();
            return;
        }

        foreach (var obj in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            obj.transform.Translate(Vector3.left * 10f * Time.deltaTime, Space.World);

            if (obj.transform.position.x < XRange || obj.transform.position.y < YRange)
            {
                Destroy(obj);
            }
        }
    }

    void SpawnObstacle()
    {
        int rnd = Random.Range(0, Prefabs.Length);
        Instantiate(Prefabs[rnd], SpawnPos, Prefabs[rnd].transform.rotation);
    }
}
