using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnBall : MonoBehaviour
{
    public static event Action BallLaunched;

    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private Transform _ballSpawnPos;

    private Controls _controls;

    private GameObject _ballChild;

    void Awake(){
        _controls = new Controls();
    }

    void OnEnable(){
        _controls.Enable();

        _controls.Touch.Launch.canceled += LaunchBall;
        _controls.Desktop.Launch.performed += LaunchBall;

        BallCounterSpawn.BallSpawned += SpawnBall;
    }

    void OnDisable(){
        _controls.Disable();

        _controls.Touch.Launch.canceled -= LaunchBall;
        _controls.Desktop.Launch.performed -= LaunchBall;

        BallCounterSpawn.BallSpawned -= SpawnBall;
    }

    private void SpawnBall(){
        _ballChild = Instantiate(_ballPrefab, _ballSpawnPos);
    }

    private void LaunchBall(InputAction.CallbackContext ctx){
        if (_ballChild != null){
            _ballChild.transform.parent = null;
            BallLaunched?.Invoke();
        }
    }
}
