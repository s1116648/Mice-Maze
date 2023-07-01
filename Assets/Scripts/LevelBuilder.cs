using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public static LevelBuilder instance;

    [SerializeField]
    GameObject
        playerPrefab, enemyPrefab, cratePrefab, foodPrefab,
        playersParent, enemiesParent, cratesParent, foodsParent;

    readonly string
        level1 = "Assets/LevelData/Level1.txt";

    Pointer pointer;

    class Pointer
    {
        readonly float
            y = 0.5f,
            startXModifier = -5,
            startZModifier = 5;
        float 
            x, z,
            startX, startZ;

        public Pointer(float middleX, float middleZ)
        {
            startX = middleX + startXModifier;
            startZ = middleZ + startZModifier;
            x = startX + middleX;
            z = startZ + middleZ;
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
            z--;
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
        pointer = new Pointer(0, 0); // Later middle of the level.
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
            case '#': // empty
                break;
            case 'p':
                SpawnPlayer(pointer.Position());
                break;
            case 'e':
                SpawnEnemy(pointer.Position());
                break;
            case 'c':
                SpawnCrate(pointer.Position());
                break;
            case 'f':
                SpawnFood(pointer.Position());
                break;
            default:
                return levelData.Substring(1);
        }
        pointer.NextPos();
        return levelData.Substring(1);
    }

    string GetLevelData(string levelFileName)
    {
        return File.ReadAllText(levelFileName);
    }

    void SpawnPlayer(Vector3 position)
    {
        Instantiate(playerPrefab, position, Quaternion.identity, playersParent.transform);
    }

    void SpawnEnemy(Vector3 position)
    {
        Instantiate(enemyPrefab, position, Quaternion.identity, enemiesParent.transform);
    }

    void SpawnCrate(Vector3 position)
    {
        Instantiate(cratePrefab, position, Quaternion.identity, cratesParent.transform);
    }

    void SpawnFood(Vector3 position)
    {
        Instantiate(foodPrefab, position, Quaternion.identity, foodsParent.transform);
    }
}
