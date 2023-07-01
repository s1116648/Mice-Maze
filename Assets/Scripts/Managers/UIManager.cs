using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    GameObject startScreen, gameOverScreen, gameStats;
    [SerializeField]
    TextMeshProUGUI scoreField, foodScoreField;

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
        gameStats.SetActive(true);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }


    public void UpdateScore(int score)
    {
        scoreField.text = score.ToString();
    }

    public void UpdateFoodScore(int score)
    {
        foodScoreField.text = score.ToString();
    }
}
