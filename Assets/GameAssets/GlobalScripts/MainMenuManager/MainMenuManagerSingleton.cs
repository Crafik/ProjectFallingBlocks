using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagerSingleton : MonoBehaviour, IConfirmable
{
    [SerializeField] private GameObject _fallingBlockPrefab;
    [SerializeField] private List<Color> _blockColors;

    [Space(10)]
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _confirmMenuPrefab;

    [Space(10)]
    [SerializeField] private GameObject _exitButton;

    private bool _inFocus;

    void Awake(){
        #if UNITY_WEBGL
        _exitButton.SetActive(false);
        #endif
    }

    void Start(){
        _inFocus = true;
    }

    float blockSpawnerCounter = 0.4f;
    void Update(){
        blockSpawnerCounter -= Time.deltaTime;
        if (blockSpawnerCounter < 0f){
            var block = Instantiate(_fallingBlockPrefab, new Vector3(Random.Range(-12.5f, 12.5f), 7f, 0f), Quaternion.identity);
            block.GetComponent<FallingBlockBehaviour>().Init(_blockColors[Random.Range(0, 8)]);
            blockSpawnerCounter = 0.4f;
        }
    }

    public void PlayButtonPress(){
        if (_inFocus){
            SceneManager.LoadScene(1);
        }
    }

    public void ExitButtonPress(){
        if (_inFocus){
            Instantiate(_confirmMenuPrefab, _canvas.transform).GetComponent<ConfirmMenu>().Init(this);
            _inFocus = false;
        }
    }

    public void ConfirmPositive(){
        Application.Quit();
    }

    public void ConfirmNegative(){
        _inFocus = true;
    }
}
