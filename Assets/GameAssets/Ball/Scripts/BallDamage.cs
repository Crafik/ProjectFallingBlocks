using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BallDamage : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _collider;

    void OnCollisionEnter2D(Collision2D collision){
        // seems to work
        if (collision.gameObject.CompareTag("Blocks")){
            collision.gameObject.GetComponent<BlockBehaviour>().GetDamage();
        }
    }

    // BUG?: Sometimes collision seem to fire more times than needed. Dunno what to do with that for now
}
