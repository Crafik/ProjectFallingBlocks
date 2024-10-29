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
            Tilemap tilemap = collision.gameObject.GetComponent<Tilemap>();

            // int contactCount = collision.contactCount;
            // ContactPoint2D[] contactPoints = new ContactPoint2D[contactCount];
            // collision.GetContacts(contactPoints);
            // foreach(ContactPoint2D cPoint in contactPoints){
            //     BlocksSingleton.Instance.GetTileDamage(tilemap.WorldToCell((Vector3)cPoint.point + ((Vector3)cPoint.point - _collider.bounds.center)));
            // }

            // trying same thing as ball bounce, leaving other implement just in case
            collision.GetContact(0);
            BlocksSingleton.Instance.GetTileDamage(tilemap.WorldToCell((Vector3)collision.GetContact(0).point + ((Vector3)collision.GetContact(0).point - _collider.bounds.center)));
        }
    }

    // BUG?: Sometimes collision seem to fire more times than needed. Dunno what to do with that for now
}
