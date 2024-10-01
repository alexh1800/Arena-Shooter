using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    /// <summary>
    /// Note: While stats appear to be a good candidate for 
    /// { get; private set; } properties, this removes the ability to
    /// modify them in the inspector, which I don't want while testing
    /// I may switch them back to properties after completion
    /// </summary>
    /// 
    public float MaxHealth = 100f;
    public float Speed = 10f;
    public float InvincibilityDuration = 1f;
    public float Rotation = 2f;


    /////////// Levelup variables////////////////

    //levels will need to be accessed by level up menu
    public int HealthLevel = 1;
    public int SpeedLevel = 1;
    //public int InvincibilityLevel = 1;
    //public int RotationLevel = 1;

    //public int MaxLevel = 10;

    //cost will need to be accessed by level up menu
    public int MaxHealthCost = 100;
    public int SpeedCost = 100;
    //public int InvincibilityCost = 100;
    //public int RotationCost = 50;

    

    //cost will need to be accessed by level up menu
    int baseMaxHealthCost = 100;
    int baseSpeedCost = 100;
    //int baseInvincibilityCost = 100;
    //int baseRotationCost = 50;

    float baseMaxHealth = 10f;
    float baseSpeed = 5f;
    //float baseInvincibilityDuration = 0.5f;
    //float baseRotation = .5f;

    [SerializeField] CurrencyManager CurrencyManager;

    //current health is managed in PlayerHealth


 

    public void UpgradeSpeed()
    {
        //if we can afford the upgrade, buy it
        if (CurrencyManager.SpendCurrency(SpeedCost))
        {         
            //Increment level
            SpeedLevel++;

            //improve stat
            Speed += baseSpeed;

            //Set Cost for Next Level
            SpeedCost = baseSpeedCost * (SpeedLevel + 1);
        }
    }

    public void UpgradeMaxHealth()
    {
        //if we can afford the upgrade, buy it
        if (CurrencyManager.SpendCurrency(MaxHealthCost))
        {
            //Increment level
            HealthLevel++;
            //Improve stat
            MaxHealth += baseMaxHealth;
            //Set Cost for next level up
            MaxHealthCost = baseMaxHealthCost * (HealthLevel + 1);
        }
    }


}
