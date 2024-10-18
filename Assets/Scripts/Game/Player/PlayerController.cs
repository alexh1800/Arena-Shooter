using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    public Camera mainCamera;  // Reference to the main camera


    [SerializeField] PlayerStats playerStats;

    // Update is called once per frame
    void Update()
    {
        if (GameOptions.controlMode == 0)
        {
            //move player based on player input
            MovePlayerMouseControls();
            //ABSTRACTION
            //Make the player rotate following the mouse's location
            MouseRotation();
        }

       
        if (GameOptions.controlMode == 1)
        {
            MovePlayerTwinStick();
        }


        //doesn't work well with overhead mode and isn't completely necessary, removing this for now
        //may implement later
        /*
        if (GameOptions.controlMode == 2)
        {
            MovePlayerArrowKeys();
        }
        */

        Physics physics = GetComponent<Physics>();
        physics.PreventOutOfBounds();

    }








    //move player based on player input
    void MovePlayerMouseControls()
    {

        // Get the input from the arrow keys (or WASD keys)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        // Create a Vector3 representing the direction to move in
        Vector3 direction = new Vector3(moveHorizontal, 0f, moveVertical);

        MovePlayer(direction);

    }

    


    void MouseRotation()
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
            //3f is used for rotation speed
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3f * Time.deltaTime);

        }
    }

    



    void MovePlayerTwinStick() {


        //----- Handle Movement (Left Stick / WASD Keys) -----//
        float leftHorizontalInput = 0f;
        float leftVerticalInput = 0f;

        //Handle WASD Keys
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            leftHorizontalInput = Input.GetAxis("HorizontalWASDKeys");  // A/D 
            leftVerticalInput = Input.GetAxis("VerticalWASDKeys");    // W/S
        }

        //Handle Left Stick
        if (Input.GetAxis("LeftStickHorizontal") != 0 || Input.GetAxis("LeftStickVertical") != 0)
        {
            leftHorizontalInput = Input.GetAxis("LeftStickHorizontal");  // Left stick X Axis
            leftVerticalInput = Input.GetAxis("LeftStickVertical");    // Left Stick Y Axis
        }

        //Set the move direction based on control input
        Vector3 direction = new Vector3(leftHorizontalInput, 0f, leftVerticalInput);

        MovePlayer(direction);




        //----- Handle Rotation (Right Stick / Arrow Keys)-----//

        float rightHorizontalInput = 0f;

        // For mouse and keyboard
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            rightHorizontalInput = Input.GetAxis("HorizontalArrowKeys");  // Custom axis for arrow keys
        }

        // For controller
        if (Input.GetAxis("RightStickHorizontal") != 0)
        {
            rightHorizontalInput = Input.GetAxis("RightStickHorizontal");
        }

        //100 is used for rotation speed
        transform.Rotate(0f, rightHorizontalInput * 100 * Time.deltaTime, 0f);


    }


    void MovePlayer(Vector3 direction)
    {

        //Display mode zero uses a locked overhead view, with a locked camera rotation we want the player 
        //to move based on the world space
        if (GameOptions.displayMode == 0)
        {
            //Move the player 
            transform.Translate(direction * playerStats.Speed * Time.deltaTime, Space.World);
        }
        else // else if the camera angle is based on the player, move based on player's rotation (space.Self)
        {
            //Move the player 
            transform.Translate(direction * playerStats.Speed * Time.deltaTime, Space.Self);
        }
    }




    void MovePlayerArrowKeys()
    {

        // Get the input from the arrow keys (or WASD keys)
        float movementDirection = Input.GetAxis("Vertical");
        // Create a Vector3 representing the direction to move in
        Vector3 direction = new Vector3(0f, 0f, movementDirection);

        MovePlayer(direction);


        float rotationDirection = Input.GetAxis("Horizontal");

        //rotate the player, 100 represents rotation speed
        transform.Rotate(0f, rotationDirection * 100 * Time.deltaTime, 0f);

    }


}
