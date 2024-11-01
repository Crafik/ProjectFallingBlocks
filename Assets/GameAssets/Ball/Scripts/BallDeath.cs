using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallDeath : MonoBehaviour
{
    public static event Action BallDestroyed;

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Hazard")){
            BallDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
