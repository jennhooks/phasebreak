using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject ballPrefab;
    public float spawnTime = 1f;
    public GameObject ghost;
    public Vector3 spawnPosition;
    public float minVelocityX = -40;
    public float maxVelocityX = 40;
    public float minVelocityY = 0;
    public float maxVelocityY = 40;

    void SpawnBall()
    {
        // Get random velocity
        float velocityX = Random.Range(minVelocityX, maxVelocityX);
        float velocityY = Random.Range(minVelocityY, maxVelocityY);
        // Setup spawning
        GameObject ballGo = Instantiate<GameObject>(ballPrefab);
        Ball ball = ballGo.GetComponent<Ball>();
        // Set vars
        ballGo.transform.position = spawnPosition;
        ball.ballSpawnerGo = this.gameObject;
        ball.startingVelocity = new Vector3(velocityX, velocityY, 0);
        // Remove ghost
        ghost.SetActive(false);
    }

    public void SpawnBallDelayed()
    {
        ghost.SetActive(true);
        Invoke("SpawnBall", spawnTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnBallDelayed();
    }
}
