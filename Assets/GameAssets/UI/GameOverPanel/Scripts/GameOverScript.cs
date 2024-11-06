using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameOverScript : MonoBehaviour
{
    private Controls _controls;

    private bool _isActive;

    void Awake(){
        _controls = new Controls();
    }

    void OnEnable(){
        _controls.Enable();

        _controls.Touch.Launch.performed += ExitPerformed;
        _controls.Desktop.Launch.performed += ExitPerformed;
    }

    void OnDisable(){
        _controls.Touch.Launch.performed -= ExitPerformed;
        _controls.Desktop.Launch.performed -= ExitPerformed;
    }

    void Start(){
        _isActive = false;
    }

    private void ExitPerformed(InputAction.CallbackContext ctx){
        if (_isActive){
            // here be scene change
            Debug.Log("exit performed");
        }
    }

    public void AnimEnded(){
        _isActive = true;
    }
}
