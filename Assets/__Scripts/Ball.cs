using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();   
        rb.AddForce(10, -60, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 clampPos = Camera.main.WorldToViewportPoint(this.transform.position);
        clampPos.x = Mathf.Clamp01(clampPos.x);
        clampPos.y = Mathf.Clamp01(clampPos.y);
        // Update position.
        Vector3 newPos = Camera.main.ViewportToWorldPoint(clampPos);
        this.transform.position = newPos;
        */
        Vector3 pos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (pos.y > 1.1f || pos.y < -0.1f)
        {
            Destroy(gameObject);
        }
    }
}
