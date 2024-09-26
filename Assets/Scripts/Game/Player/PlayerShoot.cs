using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;

    //[SerializeField] float projectileLife = 2f;

    [SerializeField] bool automatic = true;

    [SerializeField] float fireRate = 0.5f;
    
    float nextFireTime = 0f;
    

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

            nextFireTime = Time.time + fireRate;
        }
    }

    void InstantiateProjectile()
    {

        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        

        //Destroy(projectile, projectileLife);
    }
}
