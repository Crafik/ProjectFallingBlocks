using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementObsolete : MonoBehaviour
{
    // After considerate amount of time, i found out that i could have just used in-built solution for collision physics
    // ffs
    // this now declared obsolete
    // left just in case anything exploding
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private CircleCollider2D _collider;

    [Space (10)]
    public float moveSpeed;

    private float moveSpeedFactor;
    private Vector2 currentVector;

    private bool isActive;

    void OnEnable(){
        PlayerSpawnBall.BallLaunched += LaunchBall;
    }

    void OnDisable(){
        PlayerSpawnBall.BallLaunched -= LaunchBall;
    }

    void Start(){
        currentVector = new Vector2(0f, 1f).normalized;
        moveSpeedFactor = 1f;
        isActive = false;
    }

    private void LaunchBall(){
        isActive = true;
    }

    void OnCollisionEnter2D(Collision2D collision){
        // seems to work
        if (collision.gameObject.CompareTag("Player")){
            float contactX = collision.GetContact(0).collider.bounds.center.x - _collider.bounds.center.x;
            if (contactX >= 0.1f || contactX <= -0.1f){
                float bounceAngle = Mathf.Lerp(10f, 70f, (Mathf.Abs(contactX) - 0.1f) / 0.9f);
                if (bounceAngle > 45f){
                    // float speedFactorVar = (bounceAngle - 45f) / 25f;
                    // moveSpeedFactor = Mathf.Lerp(1f, 2f, speedFactorVar);
                }
                else{
                    moveSpeedFactor = 1f;
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
            // int contactCount = collision.contactCount;
            // ContactPoint2D[] contactPoints = new ContactPoint2D[contactCount];
            // collision.GetContacts(contactPoints);
            // foreach(ContactPoint2D point in contactPoints){
            //     Vector2 collisionVector = point.point - (Vector2)_collider.bounds.center;
            //     if (Mathf.Abs(collisionVector.x) < Mathf.Abs(collisionVector.y)){
            //         currentVector *= new Vector2(1f, -1f);
            //     }
            //     else{
            //         currentVector *= new Vector2(-1f, 1f);
            //     }
            // }

            // i'll stick with this, leaving other just in case
            // Vector2 collisionVector = collision.GetContact(0).point - (Vector2)_collider.bounds.center;
            // if (Mathf.Abs(collisionVector.x) < Mathf.Abs(collisionVector.y)){
            //     currentVector *= new Vector2(1f, -1f);
            // }
            // else{
            //     currentVector *= new Vector2(-1f, 1f);
            // }


            // seems to work, need further testing
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 vectorToPoint = contactPoint - (Vector2)_collider.bounds.center;
            // if (Mathf.Abs(vectorToPoint.x) < Mathf.Abs(vectorToPoint.y)){
            //     currentVector *= new Vector2(1f, -1f);
            // }
            // else if (Mathf.Abs(vectorToPoint.x) > Mathf.Abs(vectorToPoint.y)){
            //     if (currentVector.x != 0f){
            //         currentVector *= new Vector2(-1f, 1f);
            //     }
            //     else{
            //         // this should fix hitting corners when traveling vertical
            //         if (contactPoint.x > _collider.bounds.center.x){
            //             currentVector += Vector2.left;
            //         }
            //         else{
            //             currentVector += Vector2.right;
            //         }
            //         currentVector.Normalize();
            //     }
            // }
            // else{
            //     currentVector *= new Vector2(-1f, -1f);
            // }

            Vector2 ricochetFactor = Vector2.zero;
            if (currentVector.x != 0f){
                if ((currentVector.x > 0f && vectorToPoint.x > 0f) || (currentVector.x < 0f && vectorToPoint.x < 0f)){
                    ricochetFactor.x = -1f;
                }
                else{
                    ricochetFactor.x = 1f;
                }
            }
            else{
                if (vectorToPoint.x > 0f){
                    currentVector.x = -1f;
                }
                else{
                    currentVector.x = 1f;
                }
                ricochetFactor.x = 1f;
                currentVector.Normalize();
            }
            if ((currentVector.y > 0f && vectorToPoint.y > 0f) || (currentVector.y < 0f && vectorToPoint.y < 0f)){
                ricochetFactor.y = -1f;
            }
            else{
                ricochetFactor.y = 1f;
            }
            currentVector *= ricochetFactor;

            // should probably move collision detection here from BallDamage
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
        if (isActive){
            _rigidBody.MovePosition(_rigidBody.position + moveSpeed * moveSpeedFactor * Time.fixedDeltaTime * currentVector);
        }
        else{
            _rigidBody.MovePosition(transform.parent.position);
        }
    }
}
