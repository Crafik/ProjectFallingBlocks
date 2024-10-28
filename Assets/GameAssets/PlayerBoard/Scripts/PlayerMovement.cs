using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Controls _controls;

    [SerializeField] private Rigidbody2D _rigidBody;

    void Awake(){
        _controls = new Controls();
    }

    void OnEnable(){
        _controls.Enable();

        _controls.Touch.Position.performed += OnMovePerformed;
        _controls.Desktop.Position.performed += OnMovePerformed;
    }

    void OnDisable(){
        _controls.Disable();

        _controls.Touch.Position.performed -= OnMovePerformed;
        _controls.Desktop.Position.performed -= OnMovePerformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext ctx){
        // seems to work just fine
        Vector2 newPos = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
        _rigidBody.MovePosition(new Vector2(Mathf.Clamp(newPos.x, -4.05f, 4.05f), _rigidBody.position.y));
    }
}
