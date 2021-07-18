using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Desert: 0 - .25
Forest: .25 - .5
Tundra: .5 - .75
Volcano: .75 ->
*/


[CreateAssetMenu(fileName = "Enviroment Preset", menuName = "New Enviroment Preset")]
public class ScritableEnv : ScriptableObject
{
    public float minHeightRange;
    public float maxHeightRange;
    public int countToGenerate;
    public float chanceToGen;
    public GameObject sprite;
}
