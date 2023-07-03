using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool gameLoaded = false;

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
        if (!gameLoaded)
        {
            LoadGame();
            gameLoaded = true;
        }
    }

    void LoadGame()
    {
        UIManager.instance.LoadGame();
    }

    public void StartGamePressed()
    {
        StartGame();
    }

    public void StartGame()
    {
        UIManager.instance.StartLevel();
        LevelManager.instance.LoadLevel();
        ScoreManager.instance.ResetAllScores();
        ScoreManager.instance.StartDecreasingEnergy();
    }

    public void GotEaten()
    {
        GameOver();
        UIManager.instance.DisplayGotEaten();
    }

    public void Starved()
    {
        GameOver();
        UIManager.instance.DisplayStarved();
    }

    void GameOver()
    {
        ScoreManager.instance.StopDecreasingEnergy();
        UIManager.instance.GameOver();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win()
    {
        ScoreManager.instance.CalculateWinScore();
        GameOver();
        UIManager.instance.DisplayWon();
    }
}
