using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Inscribed")]
    public float cooldownTime = 6.0f;
    public GameObject cannonOneGo;
    public GameObject cannonTwoGo;

    Cannon cannonOne;
    Cannon cannonTwo;

    void RandomizeCannonAngles()
    {
        // [0,7)
        int num = Random.Range(0, 7);
        float angle = num * 5;

        // Pick direction to shoot.
        int n = Random.Range(0, 2);
        if (n == 1) {
            angle *= -1;
        }

        cannonOne.rotation = angle;
        cannonTwo.rotation = angle;

        Invoke("RandomizeCannonAngles", cooldownTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        cannonOne = cannonOneGo.GetComponent<Cannon>();
        cannonTwo = cannonTwoGo.GetComponent<Cannon>();
        RandomizeCannonAngles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
