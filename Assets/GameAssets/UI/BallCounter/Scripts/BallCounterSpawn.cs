using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCounterSpawn : MonoBehaviour
{
    public static event Action BallSpawned;
    public static event Action GameIsOver;

    [SerializeField] private List<GameObject> _list;

    public void BallSpawn(){
        if (GameManagerSingleton.Instance.livesCounter > 0){
            GameManagerSingleton.Instance.livesCounter -= 1;
            _list[GameManagerSingleton.Instance.livesCounter].SetActive(false);
            BallSpawned?.Invoke();
        }
        else{
            // here be gameover code
            GameIsOver?.Invoke();
        }
    }
}
