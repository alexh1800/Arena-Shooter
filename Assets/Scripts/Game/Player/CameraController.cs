using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform; 


    void LateUpdate()
    {
        if (GameOptions.displayMode == 0)
        {
            OverheadCamera();
        }

        //setup 3rd person camera
        if (GameOptions.displayMode == 1)
        {
            FirstPersonCamera();
        }


        //setup 3rd person camera
        if (GameOptions.displayMode == 2)
        {
            ThirdPersonCamera();
        }

    }

    void OverheadCamera()
    {
        //lock to overhead view and prevent camera from rotating with the player
        Vector3 lockedRotation = new Vector3(90f, 0f, 0f);

        //how far to keep the camera from the player
        Vector3 positionOffset = new Vector3(0f, 15f, 0f);

        // Update the camera's position to follow the player
        transform.position = playerTransform.position + positionOffset;

        // Keep the camera's rotation locked
        transform.rotation = Quaternion.Euler(lockedRotation);
    }

    void FirstPersonCamera()
    {
        //figure out where we want the camera in relation to the player
        Vector3 offset = new Vector3(0f, 0.5f, 0.4f);

        // Set the camera's position based on the player's position 
        // playerTransform.TransformDirection(offset) makes it so that the camera's offset is always relative to the player's rotation
        //making it so the camera orbits around the player when the player rotates instead of just staying in 1 spot
        transform.position = playerTransform.position + playerTransform.TransformDirection(offset);

        transform.rotation = Quaternion.Euler(0f, playerTransform.rotation.eulerAngles.y, 0f);


    }

    void ThirdPersonCamera()
    {

        //figure out how far up and back we want the camera in relation to the player
        Vector3 offset = new Vector3(0f, 5f, -10f);

        // Set the camera's position based on the player's position 
        // playerTransform.TransformDirection(offset) makes it so that the camera's offset is always relative to the player's rotation
        //making it so the camera orbits around the player when the player rotates instead of just staying in 1 spot
        transform.position = playerTransform.position + playerTransform.TransformDirection(offset);



        //set the player's camera rotation ()
        transform.rotation = Quaternion.Euler(15, playerTransform.rotation.eulerAngles.y, 0f);
        
    }

}


