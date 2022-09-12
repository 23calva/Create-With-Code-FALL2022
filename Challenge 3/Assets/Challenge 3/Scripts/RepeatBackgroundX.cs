using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    PlayerControllerX Player;

    Vector3 startPos;
    float repeatWidth;

    void Start()
    {
        startPos = transform.position; // Establish the default starting position 
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Set repeat width to half of the background

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerX>();
    }

    void Update()
    {
        if (Player.gameOver) return;

        // If background moves left by its repeat width, move it back to start position
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}


