using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20;
    float damage = 10;
    float lifespan = 1;

    [SerializeField] WeaponStats weaponStats;

    // Start is called before the first frame update
    void Start()
    {
        //print("shot fired");
        weaponStats = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponStats>();
        damage = weaponStats.Damage;
        lifespan = weaponStats.Range;

        Destroy(gameObject, lifespan);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        
        
    }

    void OnTriggerEnter(Collider other)
    {
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
