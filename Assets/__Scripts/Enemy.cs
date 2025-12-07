using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [Header("Inscribed")]
    public float cooldownTime = 6.0f;
    public int maxHealth = 3;
    public GameObject cannonOneGo;
    public GameObject cannonTwoGo;
    public GameObject healthUIGo;
    

    private Cannon cannonOne;
    private Cannon cannonTwo;
    private Text healthUI;
    private int health;

    public int enemyHealth {
        get { return health; }
        set {
            if (value <= 0)
            {
                // Die
                //SceneManager.LoadScene("_GameOverWin");
                Camera.main.GetComponent<Phasebreak>().NextLevel();
                Destroy(this.gameObject);
            }
            health = Mathf.Clamp(value, 0, maxHealth);
            // Update interface
            if (healthUI != null)
                healthUI.text = $"Enemy Health:\n{health}";
        }
    }

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

    void Awake()
    {
        healthUIGo = Camera.main.GetComponent<Phasebreak>().healthUIGo;
        healthUI = healthUIGo.GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cannonOne = cannonOneGo.GetComponent<Cannon>();
        cannonTwo = cannonTwoGo.GetComponent<Cannon>();
        RandomizeCannonAngles();
        enemyHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
