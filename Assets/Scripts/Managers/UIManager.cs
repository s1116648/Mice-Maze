using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    GameObject 
        startScreen, 
        gameOverScreen, 
        gameStats;
    [SerializeField]
    TextMeshProUGUI 
        scoreField, 
        foodScoreField,
        gameOverReason,
        gameOverScoreField, 
        gameOverHighScoreField;

    readonly string 
        scoreText = "Score: ", 
        highScoreText = "HighScore: ",
        youWonText = "You escaped!",
        youGotEatenText = "You got eaten!",
        youStarvedText = "You starved!";

    readonly Color
        diedColor = Color.red,
        wonColor = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadGame()
    {
        startScreen.SetActive(true);
    }

    public void StartGamePressed()
    {
        GameManager.instance.StartGame();
    }

    public void MainMenuPressed()
    {
        GameManager.instance.MainMenu();
    }

    public void StartLevel()
    {
        startScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        GenerateGameStats();
    }

    void GenerateGameStats()
    {
        gameStats.SetActive(true);
        UpdateScore();
        UpdateFoodScore();
    }

    public void GameOver()
    {
        gameStats.SetActive(false);
        gameOverScreen.SetActive(true);
        UpdateGameOverScore();
    }

    public void UpdateScore()
    {
        scoreField.text = PlayerPrefs.GetInt(PlayerPrefsKeys.score).ToString();
    }

    public void UpdateFoodScore()
    {
        foodScoreField.text = PlayerPrefs.GetInt(PlayerPrefsKeys.foodScore).ToString();
    }

    public void UpdateGameOverScore()
    {
        int score = PlayerPrefs.GetInt(PlayerPrefsKeys.score);
        gameOverScoreField.text = scoreText + score.ToString();
        int highScore = PlayerPrefs.GetInt(PlayerPrefsKeys.highScore);
        gameOverHighScoreField.text = highScoreText + highScore.ToString();
    }

    public void DisplayWon()
    {
        DisplayReason(youWonText, Color.green);
    }

    public void DisplayStarved()
    {
        DisplayReason(youStarvedText, Color.red);
    }

    public void DisplayGotEaten()
    {
        DisplayReason(youGotEatenText, Color.red);
    }

    void DisplayReason(string reason, Color textColor)
    {
        gameOverReason.text = reason;
        gameOverReason.color = textColor;
    }
}
