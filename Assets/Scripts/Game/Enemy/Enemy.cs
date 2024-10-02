using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    /// <summary>
    /// In order to provide a better setup for implementing INHERITANCE
    /// I've converted enemy from a more modular setup containing multiple classes
    /// to a more monolithic enemy class to use as a base class for different enemies
    /// </summary>
 
    //Movement Variables
    protected string playerGameObjectName = "Player";
    protected GameObject player;  // Reference to the player object, we'll get this in start()

    [SerializeField] protected float speed = 3f;

    //Damage Variables
    [SerializeField] protected float damage = 10f;
    [SerializeField] protected float knockbackForce = 1f;

    //Health Variables
    [SerializeField] protected float maxHealth = 10;
    [SerializeField] protected float currentHealth;

    // The currency prefab to instantiate
    [SerializeField] protected GameObject currencyPrefab;
    // The health drop prefab to instantiate
    [SerializeField] protected GameObject healthPrefab;

    //floating health bar
    [SerializeField] protected FloatingHealthBar healthBar;

    //[SerializeField] protected float currencyDropValue = 10;

    void Start()
    {
        //get the player object
        player = GameObject.Find(playerGameObjectName);

        //set current health to max health at start
        currentHealth = maxHealth;
    }

    void Update()
    {
        ChasePlayer();
    }



    void OnTriggerStay(Collider other)
    {
        //Handle Dealing Damage
        CollideWithPlayer(other);
    }


    //Handle Dealing Damage
    protected virtual void CollideWithPlayer(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
        {

            PlayerHealth playerHealth = otherCollider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage, transform.position, knockbackForce);
            }

        }
    }

    //Handle Movement
    protected virtual void ChasePlayer()
    {
        if (player != null)
        {

            // Calculate the direction from the enemy to the player
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Move the enemy toward the player
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            transform.LookAt(player.transform.position);

            Physics physics = GetComponent<Physics>();
            physics.PreventOutOfBounds();
        }
        else
        {
            print($"Couldn't find player object in Enemy Script, trying to find an object named: {playerGameObjectName}");
            player = GameObject.Find(playerGameObjectName);
        }
    }

    //Used for Receiving Damage (called from player projectiles)
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.UpdateSlider(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    //what to do when the enemy dies
    protected virtual void Die()
    {
        RollDrop();

        Destroy(gameObject);
    }

    protected virtual void RollDrop()
    {
        //determine how often health will be dropped by this enemy
        int number = Random.Range(0, 5);

        if (number == 0)
        {
            DropHealth();
        }
        else
        {
            DropCurrency();
        }
    }

    protected virtual void DropCurrency()
    {
        GameObject currencyDrop = Instantiate(currencyPrefab, transform.position, Quaternion.identity);
        CurrencyDrop currencyDropScript = currencyDrop.GetComponent<CurrencyDrop>();

        //set the currency obtained to 1/10th of the units max health, maybe manually set this later
        currencyDropScript.value = Mathf.RoundToInt(maxHealth / 10);
    }


    protected virtual void DropHealth()
    {
        
        
            GameObject healthObject = Instantiate(healthPrefab, transform.position, Quaternion.identity);
            HealthDrop healthDropScript = healthObject.GetComponent<HealthDrop>();
            healthDropScript.value = 10;
        
    }




}
