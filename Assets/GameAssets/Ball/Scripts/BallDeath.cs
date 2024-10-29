using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallDeath : MonoBehaviour
{
    public static event Action BallDestroyed;

    void OnTriggerEnter2D(Collider2D collision){
        BallDestroyed?.Invoke();
        Destroy(gameObject);
    }
}
