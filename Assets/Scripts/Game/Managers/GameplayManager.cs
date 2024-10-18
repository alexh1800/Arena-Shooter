using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    // ENCAPSULATION
    //make properties that can only be set privately, but read publicly



    public int GameplayMode = 1; //determine if we'll be playing overhead or 3rd person
    public float ArenaSize { get; private set; }
    public int Level { get; private set; }
    public float TotalGameTime { get; private set; }

    public bool GameIsPaused { get; private set; } = false;


    //UI
    [SerializeField] TMP_Text levelText;

    //pauseMenuUI will be used to detect if the game is currenly paused
    //(if it's active/visible we'll assume the game is paused)
    [SerializeField] GameObject pauseMenuUI; 

    private void Start()
    {
        //Level = 1;
        ArenaSize = 51;
        TotalGameTime = 0;
    }

    void Update()
    {
        CheckIfPaused();
        UpdateGameTime();
        UpdateLevel();

        //UI I feel like Maybe this should be done elsewhere
        levelText.text = $"Level: {Level}";

    }

    void CheckIfPaused()
    {
        //if the pause menu ui is active then set the game to paused
        if (pauseMenuUI.activeSelf)
        {
            GameIsPaused = true;
        } else
        {
            GameIsPaused = false;
        }
    }


    void UpdateGameTime()
    {
        // Only update the timer if the pause menu isn't active
        if (!GameIsPaused)
        {
            // Use unscaledDeltaTime to ensure the timer doesn't depend on Time.timeScale
            TotalGameTime += Time.unscaledDeltaTime;
            //print(TotalGameTime);
        }
    }

    void UpdateLevel()
    {
        //increase gameplay level every 30 seconds
        Level = Mathf.FloorToInt(TotalGameTime / 30) + 1;
        //print(Level);
    }


}
