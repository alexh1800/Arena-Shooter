using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
   // public float knockbackForce = 1f;  // The strength of the knockback



    public void knockBack(Vector3 enemyPosition, float force)
    {
        // Calculate the direction of knockback (away from the enemy)
        Vector3 knockbackDirection = (transform.position - enemyPosition).normalized;

        // Apply the knockback force to the player
        transform.Translate(knockbackDirection * force, Space.World);

    }

}
