using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inv/Item")]
public class itemScriptable : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;
    public bool isDefault = false;
    public float Strength = 0f;
    public float Intellect = 0f;
    public float Agility = 0f;
    public float Stamina = 0f;
    public float ArmorValue = 0f;
    public float AttackValue = 0f;
    public bool head = false;
    public bool chest = false;
    public bool melee = false;
    public bool ranged = false;
    public bool bracers = false;
    public bool foot = false;
    public bool sheild = false;
    public bool staff = false;
    public bool oneHanded = false;
    public bool twoHanded = false;
    public bool offHand = false;
    public int teir = 0; 
}
