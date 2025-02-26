using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    // ENCAPSULATION
    //make properties that can only be set privately, but read publicly



    public int GameplayMode = 1; //determine if we'll be playing overhead, 1st or 3rd person
    public float ArenaSize { get; private set; } = 51;
    public int Level { get; private set; } = 1;
    public float TotalGameTime { get; private set; } = 0;

    public bool GameIsPaused { get; private set; } = false;

    public bool GameIsOver { get; private set; } = false;


    //UI
    [SerializeField] TMP_Text levelText;

    //pauseMenuUI will be used to detect if the game is currenly paused
    //(if it's active/visible we'll assume the game is paused)
    [SerializeField] GameObject pauseMenuUI;

    [SerializeField] GameObject gameOverUI;
    [SerializeField] TMP_Text gameOverMessage;

    [SerializeField] GameObject instructionsText;


    //setup singleton for easier access
    public static GameplayManager Instance { get; private set; }

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); // Optional: keep it across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate managers
        }
    }


    private void Start()
    {
        // Hopefully keep the frame rate at or below 60fps
        Application.targetFrameRate = 60;

        // Ensure the Game Over panel is hidden at the start
        gameOverUI.SetActive(false);
        // Ensure the pause menu panel is hidden at the start
        pauseMenuUI.SetActive(false);


    }

    void Update()
    {
        CheckIfPaused();
        UpdateGameTime();
        UpdateLevel();

        //if the game is over, check to see if a user presses a key that should restart the game
        if (GameIsOver)
        {
            CheckForRestartKey();
        }
        

        //UI I feel like Maybe this should be done elsewhere
        levelText.text = $"Level: {Level}";

    }

    void CheckIfPaused()
    {
        //if the pause menu ui is active then set the game to paused
        if (pauseMenuUI.activeSelf || GameIsOver)
        {
            GameIsPaused = true;
            instructionsText.SetActive(false);

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


    public void GameOver()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
        gameOverMessage.text = $"You Survived Until Level {Level}";
    }

    public void RestartGame()
    {
       SceneManager.LoadScene("TitleScreen");
        
    }

    void CheckForRestartKey() 
    {
        if (Input.GetKey(KeyCode.Return))
        {
            RestartGame();
        }
    }


}
