using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    // ENCAPSULATION
    //make properties that can only be set privately, but read publicly
    public float ArenaSize { get; private set; }
    public int Level { get; private set; }
    public float TotalGameTime { get; private set; }



    //pauseMenuUI will be used to detect if the game is currenly paused
    //(if it's active/visible we'll assume the game is paused)
    [SerializeField] GameObject pauseMenuUI; 

    private void Start()
    {
        //Level = 1;
        ArenaSize = 50;
        TotalGameTime = 0;
    }

    void Update()
    {
        UpdateGameTime();
        UpdateLevel();
    }


    void UpdateGameTime()
    {
        // Only update the timer if the pause menu isn't active
        if (!pauseMenuUI.activeSelf)
        {
            // Use unscaledDeltaTime to ensure the timer doesn't depend on Time.timeScale
            TotalGameTime += Time.unscaledDeltaTime;
            print(TotalGameTime);
        }
    }

    void UpdateLevel()
    {
        //increase gameplay level every 30 seconds
        Level = Mathf.FloorToInt(TotalGameTime / 30) + 1;
        //print(Level);
    }


}
