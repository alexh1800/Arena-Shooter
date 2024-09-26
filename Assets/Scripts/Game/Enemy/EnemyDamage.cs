using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    float damage = 10f;
    [SerializeField]
    float knockbackForce = 2f;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {

            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage, transform.position, knockbackForce);
            }

        }

    }
}
