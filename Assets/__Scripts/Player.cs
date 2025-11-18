using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Inscribed")]
    public float normalSpeed = 20f;
    public float focusedSpeed = 10f;
    public int maxHealth = 3;
    public GameObject healthUIGo;
    Text healthUI;
    
    [Header("Dynamic")]
    public float speed = 20f;
    private int health;
    public int playerHealth {
        get { return health; }
        set {
            if (value <= 0)
            {
                // Die
                SceneManager.LoadScene("_GameOverLoss");
                Destroy(this.gameObject);
            }
            health = Mathf.Clamp(value, 0, maxHealth);
            // Update interface
            if (healthUI != null)
                healthUI.text = $"Player Health:\n{health}";
        }
    }

    Controls actions;

    void OnEnable()
    {
        actions.Player.Enable();
    }

    void OnDisable()
    {
        actions.Player.Disable();
    }

    private void OnPower(InputAction.CallbackContext context)
    {
        Debug.Log("Attempted to use power-up");
    }

    void Awake()
    {
        actions = new Controls();
        actions.Player.power.performed += OnPower;
        healthUI = healthUIGo.GetComponent<Text>();
    }

    void Start()
    {
        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Read input and convert to Vector3
        Vector2 moveVector = actions.Player.move.ReadValue<Vector2>();
        Vector3 t = new Vector3(moveVector.x, moveVector.y, 0);
        // Multiply by speed and time
        Vector3 newPos = this.transform.position += t * speed * Time.deltaTime;
        // Clamp to avoid escaping camera.
        Vector3 clampPos = Camera.main.WorldToViewportPoint(newPos);
        clampPos.x = Mathf.Clamp(clampPos.x, 0.35f, 0.65f);
        clampPos.y = Mathf.Clamp(clampPos.y, 0.0f, 1.0f);
        // Update position.
        newPos = Camera.main.ViewportToWorldPoint(clampPos);
        this.transform.position = newPos;
        // Change speed if focus is active
        if (actions.Player.focus.activeControl != null)
            speed = focusedSpeed;
        else
            speed = normalSpeed;
    }
}
