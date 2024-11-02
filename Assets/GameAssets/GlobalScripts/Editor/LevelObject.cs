using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelObj", menuName = "Level object")]
public class LevelObject : ScriptableObject
{
    public GameObject LevelPrefab;
    public Color LevelBackgroundColor;
}
