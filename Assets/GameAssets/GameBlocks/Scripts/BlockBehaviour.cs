using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[SelectionBase]
public class BlockBehaviour : MonoBehaviour
{
    public static event Action BlockDestroyed;

    [SerializeField] private OutlineBehaviour _outline; // here be links to outline and such

    [Range (0, 3)]
    public int armorState;

    private GameObject _blockSprite;
    private BoxCollider2D _collider;

    private bool isInvincible;

    void Awake(){
        _blockSprite = transform.GetChild(1).gameObject;
        _collider = GetComponent<BoxCollider2D>();
        isInvincible = false;
    }

    [ContextMenu("Set state")]
    private void SetState(){
        _outline.SetSprite(armorState);
    }

    public void GetDamage(){
        if (!isInvincible){
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
    }

    public void DestroyBlock(){
        BlockDestroyed?.Invoke();
        Destroy(gameObject);
    }

    public void RestoreBlock(){
        _blockSprite.SetActive(true);
        _collider.enabled = true;
        isInvincible = true;
        StartCoroutine(RestorationCoroutine());
    }

    private IEnumerator RestorationCoroutine(){
        float timer = 1.5f;
        float blinkCounter = 0.125f;
        while (timer > 0f){
            if (blinkCounter < 0f){
                _blockSprite.SetActive(!_blockSprite.activeSelf);
                blinkCounter = 0.125f;
            }
            blinkCounter -= Time.deltaTime;
            timer -= Time.deltaTime;
            yield return null;
        }
        _blockSprite.SetActive(true);
        isInvincible = false;
    }
}
