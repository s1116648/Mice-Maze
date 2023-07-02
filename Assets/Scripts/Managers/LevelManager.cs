using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

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
        player = LevelBuilder.instance.BuildLevel();
    }

    public void EnemyTouched()
    {
        Dead();
    }

    void Dead()
    {
        LevelBuilder.instance.PauzeAllEnemiesUpdates();
        KillPlayer();
        GameManager.instance.GameOver();
    }

    public void FoodTouched(GameObject food)
    {
        Destroy(food);
        ScoreManager.instance.FoodEaten();
    }

    void KillPlayer()
    {
        Destroy(player, 0.1f);
    }

    public void EnemySurrounded(GameObject enemy)
    {
        Destroy(enemy);
        ScoreManager.instance.EnemyKilled();
    }

    public void NoEnergy()
    {
        Dead();
    }
}
