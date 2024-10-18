using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour
{
    GameplayManager gameManager;

    void Start()
    {
        //pull the GameplayManager class from the Gameplay Manager game object
        //this is used for determining the arena size for prevent out of Bounds
        gameManager = GameObject.Find("Gameplay Manager").GetComponent<GameplayManager>(); 
    }

    public void KnockBack(Vector3 enemyPosition, float force)
    {
        // Calculate the direction of knockback (away from the enemy)
        Vector3 knockbackDirection = (transform.position - enemyPosition).normalized;

        // Apply the knockback force to the player
        transform.Translate(knockbackDirection * force, Space.World);

    }

    public void PreventOutOfBounds()
    {
        
        //Get the arena size from the GameplayManager Class
        float maxDistance = gameManager.ArenaSize - 1;

        //if somehow the player glitches through the platform or floats into the air, reset their y postion
        if (transform.position.y != 1)
        {
            //transform.position = new Vector3(transform.position.x, 1, transform.position.y);
        }

        //if the player tries to exceed max horizontal distance stop them
        if (transform.position.x >= maxDistance)
        {
            transform.position = new Vector3(maxDistance, transform.position.y, transform.position.z);
        }

        //if the player tries to exceed min horizontal distance stop them
        if (transform.position.x <= -maxDistance)
        {
            transform.position = new Vector3(-maxDistance, transform.position.y, transform.position.z);
        }

        //if the player tries to exceed max vertical distance stop them
        if (transform.position.z >= maxDistance)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, maxDistance);
        }

        //if the player tries to exceed min vertical distance stop them
        if (transform.position.z <= -maxDistance)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -maxDistance);
        }

    }
}
