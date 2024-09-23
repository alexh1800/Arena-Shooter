using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;  // Reference to the player's transform

    private Vector3 initialOffset;     // Offset to maintain the camera's relative position to the player
    public Vector3 lockedRotation = new Vector3(90f, 0f, 0f);  // The locked camera rotation

    void Start()
    {
        // Calculate the initial offset at the start to maintain camera's relative position
        initialOffset = transform.position - playerTransform.position;

        // Optionally, set the initial locked rotation of the camera
        transform.rotation = Quaternion.Euler(lockedRotation);
    }

    void LateUpdate()
    {
        // Update the camera's position to follow the player
        transform.position = playerTransform.position + initialOffset;

        // Keep the camera's rotation locked
        transform.rotation = Quaternion.Euler(lockedRotation);
    }
}

