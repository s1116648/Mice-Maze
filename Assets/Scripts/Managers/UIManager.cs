using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    GameObject startScreen;

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
        GameManager.instance.StartGame();
    }

    public void startLevel()
    {
        startScreen.SetActive(false);
    }
}
