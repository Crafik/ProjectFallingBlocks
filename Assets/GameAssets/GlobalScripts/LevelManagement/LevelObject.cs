using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelObj", menuName = "Level object", order = 52)]
public class LevelObject : ScriptableObject
{
    public GameObject LevelPrefab;
    public Color LevelBackgroundColor;
}
