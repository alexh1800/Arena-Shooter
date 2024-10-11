using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] GameplayManager gameplayManager;
    
    CurrencyManager currencyManager;

    GameObject player;

    PlayerStats playerStats;
    WeaponStats weaponStats;

    int availableCurrency;

    private void Awake()
    {
        currencyManager = gameplayManager.GetComponent<CurrencyManager>();

        player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        weaponStats = player.GetComponent<WeaponStats>();

    }

    // Update is called once per frame
    void Update()
    {
        ManageUpgradesPanel();
    }

    void ManageUpgradesPanel()
    {
        if (gameplayManager.GameIsPaused)
        {
            availableCurrency = currencyManager.Currency;

            UpdateMaxHealthUI();
            UpdateSpeedUI();
            UpdateDamageUI();
            UpdateFireRateUI();
            UpdateRangeUI();

        }
    }

    void UpdateMaxHealthUI()
    {
        UpdatePanel("Health Panel", playerStats.HealthLevel, playerStats.MaxHealthCost);
    }

    void UpdateSpeedUI()
    {
        UpdatePanel("Speed Panel", playerStats.SpeedLevel, playerStats.SpeedCost);
    }

    void UpdateDamageUI()
    {
        UpdatePanel("Damage Panel", weaponStats.DamageLevel, weaponStats.DamageCost);
    }

    void UpdateFireRateUI()
    {
        UpdatePanel("Fire Rate Panel", weaponStats.FireRateLevel, weaponStats.FireRateCost);
    }

    void UpdateRangeUI()
    {
        UpdatePanel("Range Panel", weaponStats.RangeLevel, weaponStats.RangeCost);
    }



    void UpdatePanel(string panelName, int level, int cost)
    {
        SetUpgradeCost(panelName, cost);
        SetButtonInteractable(panelName, cost);
        SetLevel(panelName, level);
    }

    void SetLevel(string panelName, int level)
    {
        TMP_Text levelText = GetUpgradePanelUIObject(panelName, "Level Text").GetComponent<TMP_Text>();
        levelText.text = level.ToString();
    }

    void SetButtonInteractable(string panelName, int cost)
    {
        Button UpgradeButton = GetUpgradePanelUIObject(panelName, "Buy Button").GetComponent<Button>();
        
        if(cost > availableCurrency)
        {
            UpgradeButton.interactable = false;
        }
        else
        {
            UpgradeButton.interactable = true;
        }
    }

    void SetUpgradeCost(string panelName, int cost)
    {
        TMP_Text UpgradeCostText = GetUpgradePanelUIObject(panelName, "Upgrade Cost").GetComponent<TMP_Text>();
        UpgradeCostText.text = cost.ToString();
    }

    GameObject GetUpgradePanelUIObject(string panelName, string objectName)
    {
        GameObject upgradePanel = transform.Find(panelName).gameObject;
        GameObject upgradeGameObject = upgradePanel.transform.Find(objectName).gameObject;

        return upgradeGameObject;
    }
}
