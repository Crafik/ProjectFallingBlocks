using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[SelectionBase]
public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] private OutlineBehaviour _outline; // here be links to outline and such

    [Range (0, 3)]
    public int armorState;

    private GameObject _blockSprite;
    private BoxCollider2D _collider;

    void Awake(){
        _blockSprite = transform.GetChild(1).gameObject;
        _collider = GetComponent<BoxCollider2D>();
    }

    [ContextMenu("Set state")]
    private void SetState(){
        _outline.SetSprite(armorState);
    }

    public void GetDamage(){
        if (armorState > 0){
            armorState -= 1;
            SetState();
        }
        else{
            _blockSprite.SetActive(false);
            _collider.enabled = false;
            GameObject falblock = Instantiate(GameManagerSingleton.Instance.FallingBlockPrefab, transform.position, Quaternion.identity);
            falblock.GetComponent<FallingBlockBehaviour>().Init(_blockSprite.GetComponent<SpriteRenderer>().color, this);
        }
    }

    public void DestroyBlock(){
        Destroy(gameObject);
    }

    public void RestoreBlock(){
        _blockSprite.SetActive(true);
        _collider.enabled = true;
    }
}
