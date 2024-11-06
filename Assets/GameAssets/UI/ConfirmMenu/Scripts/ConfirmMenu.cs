using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmMenu : MonoBehaviour
{
    private IConfirmable _parent;

    public void Init(IConfirmable parent){
        _parent = parent;
    }

    public void YesButton(){
        _parent.ConfirmPositive();
        Destroy(gameObject);
    }

    public void NoButton(){
        _parent.ConfirmNegative();
        Destroy(gameObject);
    }
}
