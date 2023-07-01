using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    readonly int foodPoints = 10;

    int score, foodScore;

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

    public void IncreaseScore(int value)
    {
        score += value;
        UIManager.instance.UpdateScore(score);
    }

    public void IncreaseFoodScore()
    {
        foodScore++;
        UIManager.instance.UpdateFoodScore(foodScore);
    }

    public void FoodEaten()
    {
        IncreaseFoodScore();
        IncreaseScore(foodPoints);
    }
}
