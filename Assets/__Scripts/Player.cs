using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Inscribed")]
    public float speed = 40f;

    Controls actions;
    Transform trans;

    void Awake()
    {
        actions = new Controls();
        trans = this.transform;
    }

    void OnEnable()
    {
        actions.Player.Enable();
    }

    void OnDisable()
    {
        actions.Player.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = actions.Player.move.ReadValue<Vector2>();
        Vector3 t = new Vector3(moveVector.x, moveVector.y, 0);
        this.transform.position += t * speed * Time.deltaTime;
    }
}
