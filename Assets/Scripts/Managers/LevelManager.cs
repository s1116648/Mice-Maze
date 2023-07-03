using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField]
    GameObject 
        level1Builder,
        level2Builder,
        cameraLevel1,
        cameraLevel2,
        level1,
        level2;

    readonly Vector3
        entrenceLevel1 = new Vector3(0, 0f, 0.5f),
        entrenceLevel2 = new Vector3(0, 0.5f, -0.5f);

    GameObject player;

    enum Level { level1, level2 }
    Level level = Level.level1;

    bool level2IsBuild = false;

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
        player = level1Builder.GetComponent<LevelBuilder>().BuildLevel();
        BuildLevel2();
        DeactivateLevel2();
    }

    public void EnemyTouched()
    {
        Dead();
    }

    void Dead()
    {
        level1Builder.GetComponent<LevelBuilder>().PauzeAllEnemiesUpdates();
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

    public void BottomPassage()
    {
        Debug.Log("Hey");
        switch(level) // Later better logic, now kind of hardcoded
        {
            case Level.level1:
                GoToLevel2();
                level = Level.level2;
                break;
            case Level.level2:
                GoToLevel1();
                level = Level.level1;
                break;
        }
    }

    void GoToLevel1()
    {
        SwitchLevel();
        SwitchCamera();
        player.GetComponent<PlayerController>().SetPlayerPosition(entrenceLevel1);
    }

    void GoToLevel2()
    {
        SwitchLevel();
        SwitchCamera();
        player.GetComponent<PlayerController>().SetPlayerPosition(entrenceLevel2);
    }

    void BuildLevel2()
    {
        level2Builder.GetComponent<LevelBuilder>().BuildLevel(player, 0, -6);
    }

    void SwitchLevel()
    {
        level1.SetActive(!level1.activeSelf);
        level2.SetActive(!level2.activeSelf);
    }

    void SwitchCamera()
    {
        cameraLevel1.SetActive(!cameraLevel1.activeSelf);
        cameraLevel2.SetActive(!cameraLevel2.activeSelf);
    }

    void DeactivateLevel2()
    {
        level2.SetActive(false);
    }
}
