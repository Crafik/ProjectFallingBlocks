using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSingleton : MonoBehaviour
{
    public static GameManagerSingleton Instance { get; private set; }

    [Header ("Public prefab references")]
    public GameObject FallingBlockPrefab;


    [Space(20)]
    [Header("-= GameManager =-")]
    [SerializeField] private LevelList _levelList;
    [SerializeField] private GameObject _backgroundImage;

    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }
}
