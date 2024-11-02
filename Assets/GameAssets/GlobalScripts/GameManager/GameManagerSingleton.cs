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
    [SerializeField] private List<GameObject> _levelList;

    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }
}
