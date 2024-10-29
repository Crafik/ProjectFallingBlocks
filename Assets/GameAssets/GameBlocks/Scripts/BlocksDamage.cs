using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlocksDamage : MonoBehaviour
{
    [SerializeField] private Tilemap _blocks;
    [SerializeField] private Tilemap _armors;

    [SerializeField] private TileBase _simpleOutline;
    [SerializeField] private TileBase _hardenedOutline;
    [SerializeField] private TileBase _armoredOutline;

    public void GetTileDamage(Vector3Int blockPos){
        // seems to work
        if (_armors.GetTile(blockPos) != null){
            TileBase armour = _armors.GetTile(blockPos);
            if (armour == _simpleOutline){
                _armors.SetTile(blockPos, null);
                return;
            }
            if (armour == _hardenedOutline){
                _armors.SetTile(blockPos, _simpleOutline);
                return;
            }
            if (armour == _armoredOutline){
                _armors.SetTile(blockPos, _hardenedOutline);
                return;
            }
        }
        else{
            _blocks.SetTile(blockPos, null);
        }
    }
}
