using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    float DogCooldown = 0.5f;
    float TimeSinceDogSpawn;

    void Update()
    {
        TimeSinceDogSpawn += Time.deltaTime;

        // On spacebar press, send dog
        if (TimeSinceDogSpawn > DogCooldown && Input.GetKeyDown(KeyCode.Space))
        {
            TimeSinceDogSpawn = 0f;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
