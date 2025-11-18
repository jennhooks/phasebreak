using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject ballSpawnerGo;
    public Vector3 startingVelocity;

    // Start is called before the first frame update
    void Start()
    {
        // Apply initial force
        Rigidbody rb = this.GetComponent<Rigidbody>();   
        rb.AddForce(startingVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if ball is off the screen
        Vector3 pos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (pos.y > 1.1f || pos.y < -0.1f)
        {
            // Set up next ball
            BallSpawner ballSpawner;
            ballSpawner = ballSpawnerGo.GetComponent<BallSpawner>();
            ballSpawner.SpawnBallDelayed();
            // Delete self
            Destroy(gameObject);
        }
    }
}
