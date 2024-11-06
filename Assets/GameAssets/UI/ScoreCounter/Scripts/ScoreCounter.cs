using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _text;

    [HideInInspector] public int currentScore;

    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }

    void OnEnable(){
        BlockBehaviour.BlockDestroyed += BlockDestroyed;
    }

    void OnDisable(){
        BlockBehaviour.BlockDestroyed += BlockDestroyed;
    }

    void Start(){
        currentScore = 0;
        SetScore();
    }

    private void BlockDestroyed(){
        currentScore += 1;
        SetScore();
    }

    private void SetScore(){
        SetScore(currentScore);
    }

    public void SetScore(int score){
        _text.text = score.ToString("00000");
    }

    public void SetTextColor(Color color){
        _text.color = color;
    }
}
