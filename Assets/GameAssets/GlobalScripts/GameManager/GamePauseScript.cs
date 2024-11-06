using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePauseScript : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuPrefab;

    private Controls _controls;

    private GameObject _pauseMenuObject;

    private bool _isGameActive;

    void Awake(){
        _controls = new Controls();
    }

    void OnEnable(){
        _controls.Enable();

        _controls.Desktop.Pause.performed += PausePressed;

        BallCounterSpawn.GameIsOver += GameIsOver;
    }

    void OnDisable(){
        _controls.Desktop.Pause.performed -= PausePressed;

        _controls.Disable();

        BallCounterSpawn.GameIsOver -= GameIsOver;
    }

    void Start(){
        _isGameActive = true;
    }

    private void PausePressed(InputAction.CallbackContext ctx){
        PauseButtonPress();
    }

    public void PauseButtonPress(){
        if (_isGameActive){
            if (_pauseMenuObject == null){
                Time.timeScale = 0f;
                _pauseMenuObject = Instantiate(_pauseMenuPrefab, GameManagerSingleton.Instance.Canvas.transform);
            }
        }
    }

    private void GameIsOver(){
        _isGameActive = false;
    }
}
