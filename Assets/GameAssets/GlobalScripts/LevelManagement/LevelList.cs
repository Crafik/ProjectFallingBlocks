using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelList", menuName = "Level list", order = 51)]
public class LevelList : ScriptableObject
{
    public List<LevelObject> Levels;
}
