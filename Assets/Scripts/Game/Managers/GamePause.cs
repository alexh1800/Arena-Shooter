using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenuUI;  // Reference to the Pause Menu UI Panel

    private bool isPaused = false;


    void Update()
    {

        // Check if the player presses the pause button as it's set in GameOptions
        if (Input.GetKeyDown(GameOptions.PauseMenuKey))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();       
            }
        }

        if (isPaused)
        {
           // unscaledDeltaTime can be used to animate the UI while the game is paused
           // float smoothTransition = Mathf.Lerp(0, 1, Time.unscaledDeltaTime);
        }
    }

    public void Pause()
    {
        // Set the game to paused
        pauseMenuUI.SetActive(true);  // Show the pause menu
        Time.timeScale = 0f;          // Freeze game time
        isPaused = true;
        

        // Optional: Lock the cursor or change cursor behavior when paused
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
    }

    public void Resume()
    {
        // Resume the game
        pauseMenuUI.SetActive(false);  // Hide the pause menu
        Time.timeScale = 1f;           // Resume game time
        isPaused = false;

        // Optional: Re-lock the cursor when resuming the game
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    public void QuitGame()
    {
        // Think about adding functionality to quit the game from the pause menu
        Application.Quit();
    }
}
