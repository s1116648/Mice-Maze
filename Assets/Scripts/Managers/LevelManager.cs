using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField]
    GameObject player, enemy, crate;

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
        Instantiate(player);
    }

    void SpawnEnemies() {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        Instantiate(enemy);
    }

    void SpawnCrates()
    {
        SpawnCrate();
    }

    void SpawnCrate()
    {
        Instantiate(crate);
    }
}
