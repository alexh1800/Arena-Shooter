using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 100;
    [SerializeField]
    private float currentHealth;

    


    void Start()
    {
        currentHealth = maxHealth;
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
        PlayerState playerState = GetComponent<PlayerState>();

        if (!playerState.isInvincible)
        {
            print("I took a hit!");
            currentHealth -= damage;

            playerState.triggerInvincible();

        }
  
    }

    //Implement an Overload for taking damage with knockback
    public void TakeDamage(float damage, Vector3 enemyPosition, float knockbackForce)
    {
        PlayerState playerState = GetComponent<PlayerState>();

        if (!playerState.isInvincible)
        {
            print("I took a hit with knockback!");
            currentHealth -= damage;

            //implement knockback
            PlayerPhysics physics = GetComponent<PlayerPhysics>();
            physics.knockBack(enemyPosition, knockbackForce);

            playerState.triggerInvincible();

        }

    }






    void Die()
    {
        // Notify other systems or controllers that this enemy is dead
        Destroy(gameObject);
    }
}
