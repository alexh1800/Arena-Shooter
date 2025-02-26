using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed = 20;  // this will be pulled from weaponStats
    float damage = 10; // this will be pulled from weaponStats
    float lifespan = 1; // this will be pulled from weaponStats

    WeaponStats weaponStats;

    // Start is called before the first frame update
    void Start()
    {
        weaponStats = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponStats>();
        damage = weaponStats.Damage;
        lifespan = weaponStats.Range;
        speed = weaponStats.ProjectileSpeed;

        Destroy(gameObject, lifespan);
        
    }

    // Update is called once per frame
    void Update()
    {

        //have the projectile move forward at the specified projectile speed
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        
        
    }

    void OnTriggerEnter(Collider other)
    {
        //if the projectile hits the enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);  // Destroy projectile on impact

        }
        
    }
}
