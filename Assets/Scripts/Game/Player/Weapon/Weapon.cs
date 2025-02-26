using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;

    WeaponStats weaponStats;


    bool automatic = true;

    float fireRate = 1f; //this will be pulled from weaponStats
    float nextFireTime = 0f;

    //the physical in game weapon game object
    GameObject weapon;

    //note damage and range are implemented in Projectile.cs


    private void Awake()
    {
        weaponStats = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponStats>();
        weapon = GameObject.FindWithTag("PlayerWeapon");
    }


    // Update is called once per frame
    void Update()
    {
        ShootProjectile();
    }

    void ShootProjectile()
    {
        //if statement to prevent player from shooting too quickly
        if (Time.time >= nextFireTime)
        {
            //if automatic is set to true, we'll check if button is held
            //else if false will check if the button was pressed
            if (automatic)
            {
                if (Input.GetButton("Fire1"))
                {
                    InstantiateProjectile();
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    InstantiateProjectile();
                }
            }

            fireRate = weaponStats.FireRate;
            nextFireTime = Time.time + fireRate;
        }
    }

    void InstantiateProjectile()
    {
         
        //Vector3 weaponPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject projectile = Instantiate(projectilePrefab, weapon.transform.position, transform.rotation);


        //Destroy(projectile, projectileLife);
    }
}
