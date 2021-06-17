using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inv/Item")]
public class itemScriptable : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;
    public bool isDefault = false;
}
