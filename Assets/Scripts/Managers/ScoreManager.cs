using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    readonly int 
        foodPoints = 10,
        enemyKillPoints = 100;

    int score, foodScore;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        CheckIfHighScoreExists();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckIfHighScoreExists()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsKeys.highScore))
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.highScore, 0);
        }
    }

    void IncreaseScore(int value)
    {
        score += value;
        SendScore();
    }

    void SendScore()
    {
        ScoreToPlayerPrefs();
        UIManager.instance.UpdateScore();
    }

    void SendFoodScore()
    {
        FoodScoreToPlayerPrefs();
        UIManager.instance.UpdateFoodScore();
    }

    void IncreaseFoodScore()
    {
        foodScore++;
        SendFoodScore();
    }

    public void EnemyKilled()
    {
        IncreaseScore(enemyKillPoints);
    }

    public void FoodEaten()
    {
        IncreaseFoodScore();
        IncreaseScore(foodPoints);
    }

    void FoodScoreToPlayerPrefs()
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.foodScore, foodScore);
    }

    void ScoreToPlayerPrefs()
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.score, score);
        IfHighScoreUpdateIt();
    }

    void IfHighScoreUpdateIt()
    {
        if (PlayerPrefs.GetInt(PlayerPrefsKeys.highScore) < score)
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.highScore, score);
        }
    }

    public void ResetAllScores()
    {
        score = 0;
        SendScore();
        foodScore = 0;
        SendFoodScore();
    }
}
