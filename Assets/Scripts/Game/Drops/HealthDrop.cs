using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{

    // the percentage of health this HealthDrop will cure
    public int value = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth playerHealthScript = other.GetComponent<PlayerHealth>();
            print("Player Collided with Health");
            playerHealthScript.Heal(value);
            Destroy(gameObject);
        }
    }
}
