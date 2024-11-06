using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCounterSpawn : MonoBehaviour
{
    public static event Action BallSpawned;
    public static event Action GameIsOver;

    [SerializeField] private List<GameObject> _list;

    [SerializeField] private GameObject _gameOverPanelPrefab;

    public void BallSpawn(){
        if (GameManagerSingleton.Instance.livesCounter > 0){
            GameManagerSingleton.Instance.livesCounter -= 1;
            _list[GameManagerSingleton.Instance.livesCounter].SetActive(false);
            BallSpawned?.Invoke();
        }
        else{
            Instantiate(_gameOverPanelPrefab, GameManagerSingleton.Instance.Canvas.transform);
            GameIsOver?.Invoke();
        }
    }
}
