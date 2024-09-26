using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera mainCamera;  // Reference to the main camera

    [SerializeField]
    float speed = 1f;

    [SerializeField]
    float maxDistance = 10;

    [SerializeField]
    float rotationSpeed = 5f;  // Speed at which the player rotates

    //Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        //move player based on player input
        movePlayer();
        mouseRotation();
    }


    //move player based on player input
    void movePlayer()
    {

        // Get the input from the arrow keys (or WASD keys)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        // Create a Vector3 representing the direction to move in
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Move the player by applying movement multiplied by speed and deltaTime (to make it frame-rate independent)
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        preventOutOfBounds();

    }

    void preventOutOfBounds()
    {

        //if somehow the player glitches through the platform or floats into the air, reset their y postion
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


    void mouseRotation()
    {
        // Get the mouse position in the world
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);  // Define a plane at y = 0 (ground)

        // Raycast from the camera to the ground plane
        if (groundPlane.Raycast(ray, out float distanceToGround))
        {
            // Find the point on the ground where the ray intersects
            Vector3 mouseWorldPosition = ray.GetPoint(distanceToGround);

            // Calculate the direction from the player to the mouse position
            Vector3 directionToMouse = (mouseWorldPosition - transform.position).normalized;

            //Use Quaternion.LookRotation to create a rotation towards the direction
            Quaternion targetRotation = Quaternion.LookRotation(directionToMouse);

         
            //modify the Target Rotation so it only keeps track of the y rotation we want
            targetRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);

            //Smoothly rotate the player towards the mouse, rotation speed could be an upgrade mechanic
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        }
    }




    
}
