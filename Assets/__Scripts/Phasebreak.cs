using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Phasebreak : MonoBehaviour
{
    [Header("Inscribed")]
    public Text uitLevel;
    public Vector3 spawnPos;
    public GameObject[] enemies;

    [Header("Dynamic")]
    public int level;
    public int levelMax;
    public GameObject castle;

    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        levelMax = enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        
    }
}
