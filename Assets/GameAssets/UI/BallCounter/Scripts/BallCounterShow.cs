using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCounterShow : MonoBehaviour
{
    public static event Action AnimEnded;

    [SerializeField] private Animator _animator;
    [SerializeField] private BallCounterSpawn _spawner;

    private bool _animationState; // false = at start || true = at end

    void OnEnable(){
        BallDeath.BallDestroyed += BallDestroyed;
    }

    void OnDisable(){
        BallDeath.BallDestroyed -= BallDestroyed;
    }

    void Start(){
        _animationState = false;
        BallDestroyed();
    }

    private void BallDestroyed(){
        _animator.Play("FadeIn");
    }

    public void AnimationStart(){
        if(_animationState){
            _animationState = false;
            _animator.Play("hiddenState");
        }
    }

    public void AnimationEnd(){
        if(!_animationState){
            _animationState = true;
            StartCoroutine(WaitToSpawnCoroutine());
        }
    }

    private IEnumerator WaitToSpawnCoroutine(){
        float counter = 0.15f;
        while (counter > 0f){
            counter -= Time.deltaTime;
            yield return null;
        }
        _spawner.BallSpawn();
        _animator.Play("FadeOut");
    }
}
