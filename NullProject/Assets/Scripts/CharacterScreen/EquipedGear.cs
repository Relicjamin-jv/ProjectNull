using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquipedGear : MonoBehaviour
{
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Defense;
    public TextMeshProUGUI Strength;
    public TextMeshProUGUI Agility;
    public TextMeshProUGUI Intellect;
    public TextMeshProUGUI Stamina;
    private float health = 100;
    private float defense = 0;
    private float strength = 0;
    private float agility = 0;
    private float intellect = 0;
    private float stamina = 0;


    public itemScriptable[] gearArray = new itemScriptable[7]; // 1. head, 2. cheast, 3. feet, 4. main weap. , 5. off weapon, 6. ranged, 7. bracer

    #region Singleton

    public static EquipedGear instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than one instance of the gear");
        }
        instance = this;
    }

    #endregion
    private void OnEnable()
    {
        GearSlot.updateUI += StatCalc;
    }

    private void OnDisable()
    {
        GearSlot.updateUI -= StatCalc;
    }

    private void StatCalc()
    {
        resetDefaultValues();
        for (int i = 0; i < gearArray.Length; i++)
        {
            Debug.Log(EquipedGear.instance.gearArray[i]);
            if (EquipedGear.instance.gearArray[i] != null)
            {
                health = health + EquipedGear.instance.gearArray[i].Stamina * 2;
                defense += EquipedGear.instance.gearArray[i].ArmorValue;
                strength += EquipedGear.instance.gearArray[i].Strength;
                agility += EquipedGear.instance.gearArray[i].Agility;
                intellect += EquipedGear.instance.gearArray[i].Intellect;
                stamina += EquipedGear.instance.gearArray[i].Stamina;
            }
        }
        Debug.Log("StartCalc");
        Debug.Log("Health:" + health);
        Health.text = health.ToString();
        Defense.text = (defense.ToString());
        Strength.text = (strength.ToString());
        Agility.text = (agility.ToString());
        Intellect.text = (intellect.ToString());
        Stamina.text = (stamina.ToString());
    }

    private void resetDefaultValues(){
        health = 100;
        defense = 0;
        strength = 0;
        agility = 0;
        intellect = 0;
        stamina = 0;
    }
}
