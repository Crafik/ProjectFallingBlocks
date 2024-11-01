using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineBehaviour : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;

    [Space (10)]
    [Header ("Sprite references")]
    [SerializeField] private Sprite _simpleOutline;
    [SerializeField] private Sprite _hardenedOutline;
    [SerializeField] private Sprite _armoredOutline;

    public void SetSprite(int state){
        switch (state){
            case 0:
                _sprite.sprite = null;
                break;
            case 1:
                _sprite.sprite = _simpleOutline;
                break;
            case 2:
                _sprite.sprite = _hardenedOutline;
                break;
            case 3:
                _sprite.sprite = _armoredOutline;
                break;
            default:
                break;
        }
    }
}
