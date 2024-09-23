using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;

    [SerializeField]
    float maxDistance = 10;

    //Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }


    void movePlayer()
    {

        // Get the input from the arrow keys (or WASD keys)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float  moveVertical = Input.GetAxis("Vertical");


        // Create a Vector3 representing the direction to move in
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Move the player by applying movement multiplied by speed and deltaTime (to make it frame-rate independent)
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        preventOutOfBounds();

    }

    void preventOutOfBounds()
    {

        //if somehow the player glitches through the platform or floats into the sky or something, reset their y postion
        if (transform.position.y != 1)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.y);
        }

        //if the player tries to exceed max horizontal distance stop them
        if (transform.position.x >= maxDistance)
        {
            transform.position = new Vector3(maxDistance, transform.position.y, transform.position.z);
        }

        //if the player tries to exceed min horizontal distance stop them
        if (transform.position.x <= -maxDistance)
        {
            transform.position = new Vector3(-maxDistance, transform.position.y, transform.position.z);
        }

        //if the player tries to exceed max vertical distance stop them
        if (transform.position.z >= maxDistance)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, maxDistance);
        }

        //if the player tries to exceed min vertical distance stop them
        if (transform.position.z <= -maxDistance)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -maxDistance);
        }


        
    }
}
