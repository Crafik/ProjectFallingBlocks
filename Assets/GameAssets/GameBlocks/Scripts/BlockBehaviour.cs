using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] private OutlineBehaviour _outline; // here be links to outline and such

    [Range (0, 3)]
    public int armorState;


    [ContextMenu("Set state")]
    private void SetState(){
        _outline.SetSprite(armorState);
    }

    public void GetDamage(){
        if (armorState > 0){
            armorState -= 1;
            SetState();
        }
        else{
            Destroy(gameObject);
            // later will be added block dropping
        }
    }
}
