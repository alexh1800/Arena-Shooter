using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    /// <summary>
    /// Note: While stats appear to be a good candidate for 
    /// { get; private set; } properties, this removes the ability to
    /// modify them in the inspector, which I don't want while testing
    /// I'm going to keep the names capitolized as I may decide
    /// to switch them back to properties after completion
    /// </summary>

    //public bool Automatic  = true;


    // -- Stats -- //
   
    public float Damage { get; private set; } = 10;
    public float FireRate { get; private set; } = 1f;  // Shots per second  
    public float Range { get; private set; } = 0.5f;

    //public float Knockback = 0f;


    // -- Levels -- //
    public int DamageLevel { get; private set; } = 1;
    public int FireRateLevel { get; private set; } = 1;
    public int RangeLevel { get; private set; } = 1;
    


    // -- Cost -- //
    //Holds how much the next upgrade will cost
    public int DamageCost { get; private set; } = 10;
    public int FireRateCost { get; private set; } = 10;
    public int RangeCost { get; private set; } = 10;



    // -- Increase Amounts -- //
    //Used to determine how much to increase stat per level
    int damageIncrease = 5;
    //int fireRateIncrease = 10; //this is divided by the current fire rate and then subtracted from the current fire rate
    float rangeIncrease = .25f;


    // -- Increase Cost -- //
    //Used to determine how much to increase stat cost per level
    int damageBaseCost = 10;
    int fireRateBaseCost = 10;
    int rangeBaseCost = 10;



    CurrencyManager CurrencyManager;



    private void Awake()
    {
        //get our currency manager
        GetCurrencyManager();
    }


    // Method to upgrade weapon damage
    public void UpgradeDamage()
    {
        //Just in case we couldn't get currency manager at startup
        GetCurrencyManager();

        //if we can afford the upgrade, buy it
        if (CurrencyManager.SpendCurrency(DamageCost))
        {
            

            //Increment level
            DamageLevel++;

            //improve stat
            Damage += damageIncrease;

            //Set Cost for Next Level
            DamageCost = damageBaseCost * DamageLevel;
        }
    }


    // Method to upgrade weapon's fire rate
    public void UpgradeFireRate()
    {
        //Just in case we couldn't get currency manager at startup
        GetCurrencyManager();

        //if we can afford the upgrade, buy it
        if (CurrencyManager.SpendCurrency(FireRateCost))
        {
            //Increment level
            FireRateLevel++;

            //improve stat (Note, the lower the fire rate, the faster you shoot, so rate increase means making the number lower)
            //float fireRateIncreasePercentage = (100 / fireRateIncrease);
            //Multiplying the current fire rate by our increase percentage, will give us how much to speed up our fire rate
            //ex. .1 (fire rate increase) * .7 (current fire rate) = .07  
            //float fireRateIncreaseAmount = FireRate * fireRateIncreasePercentage;


            //Make fire rate level = shots per second, levels will become increasingly less helpful, but should prevent
            //hittin 0 fire rate
            FireRate = 1f / FireRateLevel;


            //Set Cost for Next Level
            FireRateCost = fireRateBaseCost * FireRateLevel;
        }

    }

    // Method to upgrade weapon damage
    public void UpgradeRange()
    {
        //Just in case we couldn't get currency manager at startup
        GetCurrencyManager();

        //if we can afford the upgrade, buy it
        if (CurrencyManager.SpendCurrency(RangeCost))
        {
            //Increment level
            RangeLevel++;

            //improve stat
            Range += rangeIncrease;

            //Set Cost for Next Level
            RangeCost = rangeBaseCost * RangeLevel;
        }
    }




    void GetCurrencyManager()
    {
        if (CurrencyManager == null)
        {
            print("Get CurrencyManager");
            CurrencyManager = GameObject.Find("Gameplay Manager").GetComponent<CurrencyManager>();

            //if currency manager still == null (there may be a better way to do this)
            if (CurrencyManager == null)
            {
                print("In WeaponStats, Couldn't find CurrencyManager in Gameplay Manager game object");
            }
        }
    }

}
