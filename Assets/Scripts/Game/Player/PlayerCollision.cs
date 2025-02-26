using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //functionality is a little glitchy, may revisit later, just using prevent out of bounds in physics for now

    public float pushForce = 0.1f;  // Strength of the pushback toward the origin



    void OnTriggerStay(Collider other)
    {
        /*
        if (other.CompareTag("Wall"))
        {
            Vector3 wallPosition = other.transform.position;

            print("Wall Position");
            print(wallPosition);

            print("Player Position");
            print(transform.position);

            // Calculate the direction of knockback (away from the wall)
            Vector3 knockbackDirection = transform.position - wallPosition;
            knockbackDirection = new Vector3(knockbackDirection.x, 0, knockbackDirection.z).normalized;

            print("knockback Direction");
            print(knockbackDirection);

            transform.position = transform.position + knockbackDirection;

            //transform.position = knockbackDirection;

            // Apply the knockback force to the player
            //transform.Translate(knockbackDirection * pushForce, Space.World);
        }
        */
        
    }
}
