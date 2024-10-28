using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private CircleCollider2D _collider;

    [Space (10)]
    public float moveSpeed;

    private float moveSpeedFactor;
    private Vector2 currentVector;

    void Start(){
        currentVector = new Vector2(1f, 1f).normalized;
        moveSpeedFactor = 1f;
    }

    void OnCollisionEnter2D(Collision2D collision){
        // seems to work
        if (collision.gameObject.CompareTag("Player")){
            float contactX = collision.GetContact(0).collider.bounds.center.x - _collider.bounds.center.x;
            if (contactX >= 0.1f || contactX <= -0.1f){
                float bounceAngle = Mathf.Lerp(10f, 70f, (Mathf.Abs(contactX) - 0.1f) / 0.9f);
                if (bounceAngle > 45f){
                    float speedFactorVar = (bounceAngle - 45f) / 25f;
                    moveSpeedFactor = Mathf.Lerp(1f, 3f, speedFactorVar);
                }
                Vector2 bounceVector = Vector2.up;
                if (contactX < 0f){
                    bounceAngle *= -1f;
                }
                currentVector = rotateVector2(bounceVector, bounceAngle);
            }
            else{
                currentVector = Vector2.up;
            }
        }
        else{
            // dont know if it's better this way, we'll see
            int contactCount = collision.contactCount;
            ContactPoint2D[] contactPoints = new ContactPoint2D[contactCount];
            collision.GetContacts(contactPoints);
            foreach(ContactPoint2D point in contactPoints){
                Vector2 collisionVector = point.point - (Vector2)_collider.bounds.center;
                if (Mathf.Abs(collisionVector.x) < Mathf.Abs(collisionVector.y)){
                    currentVector *= new Vector2(1f, -1f);
                }
                else{
                    currentVector *= new Vector2(-1f, 1f);
                }
            }
        }
    }

    Vector2 rotateVector2(Vector2 vec, float angle){
        // not mine
        // stolen here: https://discussions.unity.com/t/whats-the-best-way-to-rotate-a-vector2-in-unity/754872/14
        const float PI = 3.141592f;
        float dirAngle = Mathf.Atan2(vec.y, vec.x);
        dirAngle *= 180 / PI;
        float newAngle = (dirAngle + angle) * PI / 180;
        Vector2 newDir = new Vector2(Mathf.Cos(newAngle), Mathf.Sin(newAngle) );
        return newDir.normalized;
    }

    void FixedUpdate(){
        _rigidBody.MovePosition(_rigidBody.position + moveSpeed * moveSpeedFactor * Time.fixedDeltaTime * currentVector);
    }
}
