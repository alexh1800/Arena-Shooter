using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private string playerGameObjectName = "Player";
    private GameObject player;  // Reference to the player object, we'll get this in start()

    [SerializeField]
    float speed = 3f;
    //private EnemyStats stats; //contains variables like movement speed


    void Start()
    {
        player = GameObject.Find(playerGameObjectName);

        if (player == null)
        {
            print("Couldn't Find a Player object to chase in EnemyController");
        }

    }

    void Update()
    {
        if (player != null)
        {

            // Calculate the direction from the enemy to the player
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Move the enemy toward the player
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            transform.LookAt(player.transform.position);
            //transform.rotation = Quaternion.Euler(0, direction.y, 0);
        }
        else
        {
            print("Couldn't find player object in EnemyController, trying to find an object named: Player");
            player = GameObject.Find(playerGameObjectName);
        }
    }
}
