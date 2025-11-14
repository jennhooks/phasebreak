using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Inscribed")]
    public float normalSpeed = 20f;
    public float focusedSpeed = 10f;

    [Header("Dynamic")]
    public float speed = 20f;

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
    }

    void Start()
    {
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
        clampPos.x = Mathf.Clamp01(clampPos.x);
        clampPos.y = Mathf.Clamp01(clampPos.y);
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
