using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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

    public void StartGamePressed()
    {
        StartGame();
    }

    public void StartGame()
    {
        UIManager.instance.StartLevel();
        LevelManager.instance.LoadLevel();
    }

    public void GameOver()
    {
        UIManager.instance.GameOver();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
