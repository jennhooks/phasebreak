using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject bulletPrefab;
    public float spawnTime = 0.333f;
    public float cooldownTime = 2.0f;
    public float burstDistFactor = 0.3f;
    public int burstCount = 3;
    public Vector3 spawnPosition;
    public float velocityX = 0;
    public float velocityY = -40f;
    public float magnitude = -40f;
    public float rotation = -30f;

    void SpawnBullet()
    {
        // Setup spawning
        GameObject bulletGo = Instantiate<GameObject>(bulletPrefab);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        // Set vars
        bulletGo.transform.position = spawnPosition;
        bulletGo.transform.Rotate(0, 0, rotation);
        bullet.magnitude = magnitude;
    }

    public void SpawnBulletDelayed()
    {
        for (int i = 0; i < burstCount; i++)
            Invoke("SpawnBullet", (spawnTime * i) + (burstDistFactor * i));
        Invoke("SpawnBulletDelayed", spawnTime * burstCount + cooldownTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnBulletDelayed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
