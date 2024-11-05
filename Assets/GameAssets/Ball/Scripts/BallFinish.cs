using System;
using UnityEngine;

public class BallFinish : MonoBehaviour
{
    public static event Action BallFinished;

    [SerializeField] private Rigidbody2D _rigidBody;

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Finish")){
            GameManagerSingleton.Instance.NextLevel();
            _rigidBody.position = new Vector3(_rigidBody.position.x, -5.25f, 0);
            BallFinished?.Invoke();
        }
    }
}