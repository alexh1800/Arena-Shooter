using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    float invincibilityDuration = 2f;  // Time the player is invincible after collision
    public bool isInvincible = false;  // Tracks whether the player is invincible


    public void triggerInvincible()
    {
        StartCoroutine(invincibility());
    }

    IEnumerator invincibility()
    {
        // Set the player to be invincible
        isInvincible = true;

        //add some kind of visual indicator that player is invincible
        //maybe make player a bit transparent or something

        // keep isInvincible true for invincible duration
        yield return new WaitForSeconds(invincibilityDuration);

        //set is invincible to false again
        isInvincible = false;

        //if visual indication is used return player to normal here

    }


}
