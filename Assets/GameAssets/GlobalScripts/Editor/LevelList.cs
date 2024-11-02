using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelList", menuName = "Level list")]
public class LevelList : ScriptableObject
{
    public List<LevelObject> Levels;
}
