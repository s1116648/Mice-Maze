using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagNames.Food)
        {
            FoodTouched(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == TagNames.Enemy)
        {
            EnemyTouched();
        }
    }

    void Move()
    {
        float moveX = MoveValue(GetAxisNames.Horizontal);
        float moveZ = MoveValue(GetAxisNames.Vertical);
        transform.Translate(moveX, 0, moveZ);
    }

    float MoveValue(string axisName)
    {
        return Input.GetAxis(axisName) * speed * Time.deltaTime;
    }

    void EnemyTouched()
    {
        LevelManager.instance.EnemyTouched();
    }

    void FoodTouched(GameObject food)
    {
        LevelManager.instance.FoodTouched(food);
    }
}
