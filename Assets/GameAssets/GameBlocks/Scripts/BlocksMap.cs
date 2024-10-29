using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlocksMap : MonoBehaviour
{
    // this is probably gonna be save/load script or smth
    [SerializeField] private BlocksDamage _damage;

    public void GetTileDamage(Vector3Int blockPos){
        _damage.GetTileDamage(blockPos);
    }
}
