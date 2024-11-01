using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlockBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private float _moveSpeed;

    private BlockBehaviour _owner;

    public void Init(Color color, BlockBehaviour owner){
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = color;
        _owner = owner;
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            _owner.DestroyBlock();
            Destroy(gameObject);
        }
        if (collision.CompareTag("Hazard")){
            _owner.RestoreBlock();
        }
    }

    void FixedUpdate(){
        _rigidBody.MovePosition(_rigidBody.position + _moveSpeed * Time.fixedDeltaTime * Vector2.down);
    }
}
