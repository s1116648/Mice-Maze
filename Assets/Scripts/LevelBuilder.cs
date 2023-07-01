using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public static LevelBuilder instance;

    readonly string
        level1 = "Assets/LevelData/Level1.txt";

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

    public void BuildLevel()
    {
        GetLevelData(level1);
    }

    void GetLevelData(string levelFileName)
    {
        string text = File.ReadAllText(levelFileName);
        Debug.Log(text);
    }
}
