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
    public float MaxHealth { get; private set; } = 30f;
    public float Speed { get; private set; } = 4f;
    public float InvincibilityDuration { get; private set; } = 1f;
    public float Rotation { get; private set; } = 2f;


    /////////// Levelup variables////////////////

    //levels will need to be accessed by level up menu
    public int HealthLevel { get; private set; } = 1;
    public int SpeedLevel { get; private set; } = 1;
    //public int InvincibilityLevel = 1;
    //public int RotationLevel = 1;



    //cost will need to be accessed by level up menu
    public int MaxHealthCost { get; private set; } = 10;
    public int SpeedCost { get; private set; } = 10;
    //public int InvincibilityCost = 100;
    //public int RotationCost = 50;

    

    int baseMaxHealthCost = 10;
    int baseSpeedCost = 10;
    //int baseInvincibilityCost = 100;
    //int baseRotationCost = 50;

    float baseMaxHealth = 10f;
    float baseSpeed = 2f;
    float baseRotation = 0.5f;
    //float baseInvincibilityDuration = 0.5f;


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

            //also improve rotation speed
            Rotation += baseRotation;

            //Set Cost for Next Level
            SpeedCost = baseSpeedCost * SpeedLevel;
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

            //also heal the players health the amount added to max health
            gameObject.GetComponent<PlayerHealth>().HealAmount(baseMaxHealth);

            //Set Cost for next level up
            MaxHealthCost = baseMaxHealthCost * HealthLevel;
        }
    }


}
