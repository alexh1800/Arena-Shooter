using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] PlayerState playerState;


    [SerializeField] private float currentHealth;

    


    void Start()
    {
        currentHealth = playerStats.MaxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }



    public void TakeDamage(float damage)
    {
        if (!playerState.isInvincible)
        {
            print("I took a hit!");
            currentHealth -= damage;

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

            //implement knockback
            Physics physics = GetComponent<Physics>();
            physics.knockBack(enemyPosition, knockbackForce);

            playerState.triggerInvincible();

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        print("PlayerHEalth Detected a collision");
    }





    void Die()
    {
        // Notify other systems or controllers that this enemy is dead
        Destroy(gameObject);
    }
}
