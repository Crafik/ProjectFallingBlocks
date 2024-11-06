using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManagerSingleton : MonoBehaviour
{
    public static GameManagerSingleton Instance { get; private set; }

    [Header ("Public prefab references")]
    public GameObject FallingBlockPrefab;


    [Space(20)]
    [Header("-= GameManager =-")]
    [SerializeField] private LevelList _levelList;
    [SerializeField] private GameObject _backgroundImage;

    [Space(5)]
    [SerializeField] private GameObject _blocksGrid;

    [Space(5)]
    [SerializeField] private Tilemap _barrierMap;
    [SerializeField] private Transform _leftBarrier;
    [SerializeField] private Transform _rightBarrier;
    [SerializeField] private TileBase _barrierBlockPrefab;

    private int _levelNum;
    private GameObject _levelInstance;
    private int _levelBlockCount;

    private Coroutine _barrierCoroutine;

    public int livesCounter;

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
        BlockBehaviour.BlockDestroyed -= BlockDestroyed;
    }

    void Start(){
        SetLevel(0);
        livesCounter = 5;
    }

    public void NextLevel(){
        _levelNum += 1;
        SetLevel(_levelNum);
    }

    public void SetLevel(int num){
        if (num > -1 && num < _levelList.Levels.Count){
            _levelNum = num;
        }
        else{
            _levelNum = 0;
        }
        LoadLevel(_levelNum);
    }

    private void LoadLevel(int num){
        if (_levelInstance != null){
            Destroy(_levelInstance);
        }
        if (_levelList.Levels[num] != null){
            _levelInstance = Instantiate(_levelList.Levels[num].LevelPrefab, _blocksGrid.transform);
            _backgroundImage.GetComponent<SpriteRenderer>().color = _levelList.Levels[num].LevelBackgroundColor;
            _levelBlockCount = _levelInstance.transform.childCount;

            ScoreCounter.Instance.SetTextColor(_levelList.Levels[num].LevelBackgroundColor);

            if (_barrierCoroutine != null){
                StopCoroutine(_barrierCoroutine);
            }
            Vector3Int startPos = _barrierMap.WorldToCell(_leftBarrier.position);
            for (int i = startPos.x - 10; i < startPos.x + 11; ++i){
                _barrierMap.SetTile(new Vector3Int(i, startPos.y, startPos.z), _barrierBlockPrefab);
                // should work
            }
        }
        else{
            Debug.LogError("Out of range exception");
        }
    }

    private void BlockDestroyed(){
        _levelBlockCount -= 1;
        if (_levelBlockCount < 1){
            _barrierCoroutine = StartCoroutine(BarrierOpenCoroutine());
        }
    }

    private IEnumerator BarrierOpenCoroutine(){
        Vector3Int leftStartPos = _barrierMap.WorldToCell(_leftBarrier.position);
        Vector3Int rightStartPos = _barrierMap.WorldToCell(_rightBarrier.position);
        float counter = 0.1f;
        int blockCounter = 0;
        while (blockCounter < 10){
            if (counter < 0f){
                _barrierMap.SetTile(new Vector3Int(leftStartPos.x - blockCounter, leftStartPos.y, leftStartPos.z), null);
                _barrierMap.SetTile(new Vector3Int(rightStartPos.x + blockCounter, rightStartPos.y, rightStartPos.z), null);
                counter = 0.1f;
                blockCounter += 1;
            }
            counter -= Time.deltaTime;
            yield return null;
        }
    }
}
