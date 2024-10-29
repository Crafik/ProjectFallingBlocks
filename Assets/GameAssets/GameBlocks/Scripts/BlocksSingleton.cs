using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksSingleton : MonoBehaviour
{
    public static BlocksSingleton Instance { get; private set; }

    [SerializeField] private BlocksDamage _damage;

    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }

    public void GetTileDamage(Vector3Int blockPos){
        _damage.GetTileDamage(blockPos);
    }
}
