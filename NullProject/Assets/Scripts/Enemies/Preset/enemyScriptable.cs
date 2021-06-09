using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Preset", menuName = "New Enemy Preset")]
public class enemyScriptable : ScriptableObject
{
    public string enemyName;
    public int health;
    public float minHeightRange;
    public float maxHeightRange;
    public int countToGenerate;
    public float chanceToGen;
    public GameObject prefab;

}
