using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    //[SerializeField]
    

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
        LevelBuilder.instance.BuildLevel();
    }

    public void EnemyTouched(GameObject player)
    {
        LevelBuilder.instance.PauzeAllEnemiesUpdates();
        KillPlayer(player);
        GameManager.instance.GameOver();
    }

    public void FoodTouched(GameObject food)
    {
        Destroy(food);
        ScoreManager.instance.FoodEaten();
    }

    void KillPlayer(GameObject player)
    {
        Destroy(player, 0.1f);
    }

    public void EnemySurrounded(GameObject enemy)
    {
        Destroy(enemy);
        ScoreManager.instance.EnemyKilled();
    }
}
