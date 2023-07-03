using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject
        playerPrefab, enemyPrefab, cratePrefab, foodPrefab, keyPrefab,
        playersParent, enemiesParent, cratesParent, foodsParent;

    [SerializeField]
    string
        levelPath = "Assets/LevelData/Level1.txt";

    Pointer pointer;

    GameObject player;
    List<GameObject> enemies;

    class Pointer
    {
        readonly float
            y = 0.5f,
            startXModifier = -5,
            startZModifier = 5;
        float
            x, z;
        public float
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
        enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject BuildLevel()
    {
        return BuildLevel(0, 0);
    }

    public void BuildLevel(GameObject player)
    {
        this.player = player;
        BuildLevel();
    }

    public GameObject BuildLevel(float centerX, float centerZ)
    {
        pointer = new Pointer(centerX, centerZ);
        string levelData = GetLevelData(levelPath);
        while (levelData.Length > 0)
        {
            levelData = SpawnNextThing(levelData);
        }
        EnemiesTargetPlayer();
        return player;
    }

    public void BuildLevel(GameObject player, float centerX, float centerZ)
    {
        this.player = player;
        BuildLevel(centerX, centerZ);
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
            case 'k':
                SpawnKey(pointer.Position());
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
        player = Instantiate(playerPrefab, position, Quaternion.identity, playersParent.transform);
    }

    void SpawnEnemy(Vector3 position)
    {
        enemies.Add(Instantiate(enemyPrefab, position, Quaternion.identity, enemiesParent.transform));
    }

    void SpawnCrate(Vector3 position)
    {
        Instantiate(cratePrefab, position, Quaternion.identity, cratesParent.transform);
    }

    void SpawnFood(Vector3 position)
    {
        Instantiate(foodPrefab, position, Quaternion.identity, foodsParent.transform);
    }

    void SpawnKey(Vector3 position)
    {
        Instantiate(keyPrefab, position, Quaternion.identity);
    }

    void EnemiesTargetPlayer()
    {
        foreach (GameObject enemy in enemies) {
            EnemyTargetPlayer(enemy);
        }
    }

    void EnemyTargetPlayer(GameObject enemy)
    {
        enemy.GetComponent<EnemyController>().target = player;
    }

    public void PauzeAllEnemiesUpdates()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
                PauzeEnemyEnemiesUpdate(enemy);
        }
    }

    void PauzeEnemyEnemiesUpdate(GameObject enemy)
    {
        enemy.GetComponent<EnemyController>().PauzeUpdates();
    }
}
