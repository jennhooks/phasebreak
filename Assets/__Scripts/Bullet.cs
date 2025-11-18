using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 startingVelocity = new Vector3(0, -30, 0);
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();   
        rb.AddForce(startingVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if ball is off the screen
        Vector3 pos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (pos.y > 1.1f || pos.y < -0.1f || pos.x > 0.70f || pos.x < 0.30f)
        {
            // Delete self
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go != null && other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent.gameObject.GetComponent<Player>().playerHealth -= damage;
            Destroy(gameObject);
        }
    }
}
