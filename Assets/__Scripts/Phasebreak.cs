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
    public GameObject healthUIGo;

    [Header("Dynamic")]
    public int level;
    public int levelMax;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        levelMax = enemies.Length;
        StartLevel();
    }

    void StartLevel()
    {
        if (enemy != null)
        {
            Destroy(enemy);
        }

        enemy = Instantiate<GameObject>(enemies[level]);

        Enemy e = enemy.GetComponent<Enemy>();
        e.healthUIGo = healthUIGo;

        enemy.transform.position = spawnPos;
        //UpdateGUI();
    }

    /*
    void UpdateGUI() 
    {
        uitLevel.text = "Level: "+(level + 1)+" of "+levelMax;
    }
    */

    public void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            SceneManager.LoadScene("_GameOverWin");
        }
        else
        {
            Invoke("StartLevel", 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
