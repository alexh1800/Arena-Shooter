using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

// INHERITANCE
public class SkeletonMinion : Enemy
{


    void Start()
    {
        int enemyLevel = GameplayManager.Instance.Level;

        speed = 1f + (enemyLevel * .2f);
        damage = 3f + Mathf.Floor(enemyLevel * .5f);
        knockbackForce = 1f;

        //Health Variables
        maxHealth = 5 + (enemyLevel * 3); ;

        //change the drop odds for health, ex. 10 would make a health drop 1/10
        healthDropRng = 10;

        //setup health regeneration
        regenAmount = 0 + (enemyLevel * 1); // Amount of health restored per interval
        regenInterval = 5f;    // Time in seconds between regenerations


        //set current health to max health at start (doesn't work when done in parent enemy class)
        currentHealth = maxHealth;

        StartHealthRegeneration();  // Start health regeneration process based on variables above
    }

    //POLYMORPHISM
    //modify chase behavior to make Skeleton Minions a little more skittish and will run away when less than half health
    protected override void ChasePlayer()
    {
        if (player != null)
        {
            float healthPercentage = 100 / (maxHealth / currentHealth);

            Vector3 direction;

            //if health is 50% or greater, move towards the player, else move away
            if (healthPercentage >= 50f)
            {
                // Calculate the direction from the enemy towards the player
                direction = (player.transform.position - transform.position).normalized;
            }
            else
            {
                // Calculate the direction from the enemy away from the player
                direction = (transform.position - player.transform.position).normalized;
            }

            

            // Move the enemy toward or away from the player
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            // Keep the enemey looking at the player
            transform.LookAt(player.transform.position);

            // Make sure the enemy stays in the game bounds
            Physics physics = GetComponent<Physics>();
            physics.PreventOutOfBounds();
        }
        else
        {
            print($"Couldn't find player object in Enemy Script, trying to find an object named: {playerGameObjectName}");
            player = GameObject.Find(playerGameObjectName);
        }
    }
}
