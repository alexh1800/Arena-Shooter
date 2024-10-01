using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    // ENCAPSULATION
    //adding a currency backing field so that I can modify currency in
    //the unity inspector
    [SerializeField]private int currency = 0;
    public int Currency { get; private set; } = 0;

    private void Awake()
    {
        Currency = currency;
    }


    // Method to add currency
    public void AddCurrency(int amount)
    {
        Currency += amount;
    }

    // Method to spend currency on upgrades
    public bool SpendCurrency(int amount)
    {
        if (Currency >= amount)
        {
            Currency -= amount;
            return true;  // Purchase successful
        }
        else
        {
            //maybe play a sound effect or something
            return false;  // Not enough money
        }
    }
}
