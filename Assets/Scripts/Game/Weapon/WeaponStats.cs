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

    public bool Automatic  = false;

    public int KnockbackLevel = 1;
    public float Knockback = 0f;

    public int DamageLevel = 1;
    public float Damage = 10;

    public int FireRateLevel = 1;
    public float FireRate = 0.5f;  // Shots per second

    public int LifeSpanLevel = 1;
    public float LifeSpan = 1;


    // Method to upgrade weapon damage
    public void UpgradeDamage(float amount)
    {
        Damage += amount;
    }

    // Method to upgrade fire rate
    public void UpgradeFireRate(float amount)
    {
        FireRate -= amount;  // Lower fire rate means faster firing (but don't go below a certain value)
        if (FireRate < 0.1f)
        {
            FireRate = 0.1f;  // Set a minimum fire rate
        }
    }
}
