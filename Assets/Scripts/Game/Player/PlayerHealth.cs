using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] PlayerState playerState;


    [SerializeField] private float currentHealth;

    //UI
    public Slider healthSlider;  // Assign via Inspector
    public TMP_Text healthText;

    GameplayManager gameplayManager;


    void Start()
    {
        currentHealth = playerStats.MaxHealth;
        healthSlider.maxValue = playerStats.MaxHealth;
        healthSlider.value = currentHealth;

        gameplayManager = FindObjectOfType<GameplayManager>();
    }

    private void Update()
    {
        //note could probobly update this only when taking damage or getting health for
        //better performance, but this works well enough
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            //health being negative looks odd, so set it to 0
            currentHealth = 0;
            UpdateHealthUI();
            Die();
        }
    }

    private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth;
        healthSlider.maxValue = playerStats.MaxHealth;
        healthText.text = $"{currentHealth} / {playerStats.MaxHealth}";
    }



    public void TakeDamage(float damage)
    {
        if (!playerState.isInvincible)
        {
            print("I took a hit!");
            currentHealth -= damage;

            //healthSlider.value = currentHealth;

            playerState.triggerInvincible();
        } 
    }

    //POLYMORPHISM
    //Implement an Overload for taking damage with knockback
    public void TakeDamage(float damage, Vector3 enemyPosition, float knockbackForce)
    {

        if (!playerState.isInvincible)
        {
            print("I took a hit with knockback!");
            currentHealth -= damage;

            //healthSlider.value = currentHealth;

            //implement knockback
            Physics physics = GetComponent<Physics>();
            physics.KnockBack(enemyPosition, knockbackForce);

            playerState.triggerInvincible();

        }

    }

    public void Heal(float amountPercent)
    {
        //convert percentage amount to a decimal
        //so if 10 (percent) was input, we'll get .10
        float decimalAmount = amountPercent / 100;

        //multiply our decimal amount by player's total health to get the amount to heal
        float healAmount = playerStats.MaxHealth * decimalAmount;

        //add our heal amount to our current health
        currentHealth += healAmount;

        //if we exceed the player's max health, set the player's health to their max
        if(currentHealth > playerStats.MaxHealth)
        {
            currentHealth = playerStats.MaxHealth;
        }

    }

    public void HealAmount(float amount)
    {
        //add our heal amount to our current health
        currentHealth += amount;

        //if we exceed the player's max health, set the player's health to their max
        if (currentHealth > playerStats.MaxHealth)
        {
            currentHealth = playerStats.MaxHealth;
        }
    }



    void Die()
    {
        // Destroy the player
        Destroy(gameObject);
        //Let gameplayManaget know it's game over
        gameplayManager.GameOver();



    }
}
