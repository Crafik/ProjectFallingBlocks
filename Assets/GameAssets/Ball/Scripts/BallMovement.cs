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

    private bool isActive;

    void OnEnable(){
        PlayerSpawnBall.BallLaunched += LaunchBall;
    }

    void OnDisable(){
        PlayerSpawnBall.BallLaunched -= LaunchBall;
    }

    void Start(){
        moveSpeedFactor = 1f;
        _rigidBody.velocity = Vector2.zero;
        isActive = false;
    }

    private void LaunchBall(){
        if(!isActive){
            isActive = true;
            _rigidBody.velocity = new Vector2(0f, 1f).normalized * moveSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        // seems to work
        if (collision.gameObject.CompareTag("Player")){
            float contactX = collision.GetContact(0).collider.bounds.center.x - _collider.bounds.center.x;
            if (contactX >= 0.05f || contactX <= -0.05f){
                float bounceAngle = Mathf.Lerp(10f, 70f, (Mathf.Abs(contactX) - 0.05f) / 0.9f);
                if (bounceAngle > 45f){
                    float speedFactorVar = (bounceAngle - 45f) / 25f;
                    moveSpeedFactor = Mathf.Lerp(1f, 2f, speedFactorVar);
                }
                else{
                    moveSpeedFactor = 1f;
                }
                Vector2 bounceVector = Vector2.up;
                if (contactX < 0f){
                    bounceAngle *= -1f;
                }
                _rigidBody.velocity = moveSpeed * moveSpeedFactor * rotateVector2(bounceVector, bounceAngle);
            }
            else{
                _rigidBody.velocity = moveSpeed * moveSpeedFactor * Vector2.up;
            }
        }
        else{
            if (Mathf.Abs(_rigidBody.velocity.y) < 0.105f){
                _rigidBody.AddForce(Vector2.up * (_rigidBody.position.y > 0f ? -1 : 1));
                // should fix issue when ball stucks in horizontal movement
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
        if (!isActive){
            _rigidBody.MovePosition(transform.parent.position);
        }
    }
}
