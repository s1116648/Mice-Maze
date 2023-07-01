using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    GameObject startScreen, gameOverScreen;

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

    public void StartGame()
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
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

}
