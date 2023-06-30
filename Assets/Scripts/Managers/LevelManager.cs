using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField]
    GameObject playerPrefab, enemyPrefab, cratePrefab;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        SpawnPlayer();
        SpawnEnemies();
        SpawnCrates();
    }

    void SpawnPlayer()
    {
        player = Instantiate(playerPrefab);
    }

    void SpawnEnemies() {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab);
    }

    void SpawnCrates()
    {
        SpawnCrate();
    }

    void SpawnCrate()
    {
        Instantiate(cratePrefab);
    }

    public void EnemyTouched()
    {
        KillPlayer();
        GameManager.instance.GameOver();
    }

    void KillPlayer()
    {
        Destroy(player, 0.1f);
    }
}
