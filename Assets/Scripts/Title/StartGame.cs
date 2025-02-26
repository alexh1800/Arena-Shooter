using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    void Update()
    {
        //check for if the enter/ return key is hit, if it is, start the game.
        if (Input.GetKey(KeyCode.Return))
        {
            LoadGame();
        }
    }

    /// <summary>
    /// Load the Game Scene
    /// </summary>
    public void LoadGame()
    {
        

      SceneManager.LoadScene("Game");

    }
}
