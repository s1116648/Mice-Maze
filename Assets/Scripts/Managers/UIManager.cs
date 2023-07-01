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
        gameOverScoreField, 
        gameOverHighScoreField;

    readonly string scoreText = "Score: ", highScoreText = "HighScore: ";

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
}
