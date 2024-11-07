using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour, IConfirmable
{
    [SerializeField] private Animator _animator;

    [SerializeField] private GameObject confirmMenuPrefab;

    private bool _animState; // false = at start :: true = at end

    private Controls _controls;

    private bool _inFocus;

    void Awake(){
        _controls = new Controls();
    }

    void OnEnable(){
        _controls.Enable();

        _controls.Desktop.Pause.performed += PausePerformed;
    }

    void OnDisable(){
        _controls.Desktop.Pause.performed -= PausePerformed;

        _controls.Disable();
    }

    void Start(){
        _animState = false;
        _inFocus = false;
    }

    public void ContinuePress(){
        if (_inFocus){
            _animator.Play("FadeOut");
            _inFocus = false;
        }
    }

    private void PausePerformed(InputAction.CallbackContext ctx){
        ContinuePress();
    }

    public void ExitPress(){
        if (_inFocus){
            _inFocus = false;
            Instantiate(confirmMenuPrefab, GameManagerSingleton.Instance.Canvas.transform).GetComponent<ConfirmMenu>().Init(this);
        }
    }

    public void ConfirmPositive(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void ConfirmNegative(){
        _inFocus = true;
    }

    public void AnimationStartEvent(){
        if (_animState){
            Time.timeScale = 1f;
            Destroy(gameObject);
        }
    }

    public void AnimationEndEvent(){
        if(!_animState){
            _inFocus = true;
            _animState = true;
        }
    }
}
