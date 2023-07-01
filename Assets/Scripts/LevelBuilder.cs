using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public static LevelBuilder instance;

    [SerializeField]
    GameObject playerPrefab, enemyPrefab, cratePrefab, foodPrefab;

    readonly string
        level1 = "Assets/LevelData/Level1.txt";

    Pointer pointer;

    class Pointer
    {
        readonly float
            y = 0.5f,
            startX = -5,
            startZ = -5;
        float x, z;

        public Pointer()
        {
            x = startX;
            z = startZ;
        }

        public void NextPos()
        {
            if (x >= (startX * -1))
            {
                NewLine();
            } else
            {
                x++;
            }
        }

        void NewLine()
        {
            x = startX;
            z++;
        }

        public Vector3 Position()
        {
            return new Vector3(x, y, z);
        }
    }

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
        pointer = new Pointer();
        string levelData = GetLevelData(level1);
        while (levelData.Length > 0)
        {
            levelData = SpawnNextThing(levelData);
        }
    }

    string SpawnNextThing(string levelData)
    {
        char currentThing = levelData[0];
        switch(currentThing)
        {
            case '#':
                pointer.NextPos();
                break;
            case 'p':
                SpawnPlayer(pointer.Position());
                pointer.NextPos();
                break;
            case 'e':
                SpawnEnemy(pointer.Position());
                pointer.NextPos();
                break;
            case 'c':
                SpawnCrate(pointer.Position());
                pointer.NextPos();
                break;
            case 'f':
                SpawnFood(pointer.Position());
                pointer.NextPos();
                break;
            default:
                break;
        }
        return levelData.Substring(1);
    }

    string GetLevelData(string levelFileName)
    {
        return File.ReadAllText(levelFileName);
    }

    void SpawnPlayer(Vector3 position)
    {
        Instantiate(playerPrefab, position, Quaternion.identity);
    }

    void SpawnEnemy(Vector3 position)
    {
        Instantiate(enemyPrefab, position, Quaternion.identity);
    }

    void SpawnCrate(Vector3 position)
    {
        Instantiate(cratePrefab, position, Quaternion.identity);
    }

    void SpawnFood(Vector3 position)
    {
        Instantiate(foodPrefab, position, Quaternion.identity);
    }
}
