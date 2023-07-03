using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;

    [SerializeField]
    GameObject sightRotation;

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
        if (collision.gameObject.tag == TagNames.Enemy)
        {
            EnemyTouched();
        }
    }

    void Move()
    {
        float moveX = MoveValue(GetAxisNames.Horizontal);
        float moveZ = MoveValue(GetAxisNames.Vertical);
        Vector3 direction = new Vector3(moveX, 0, moveZ);
        transform.Translate(direction);
        RotateEyes(direction);
    }

    void RotateEyes(Vector3 direction)
    {
        if (direction.x != 0 || direction.z != 0) // So if it stays still it doesn't reset rotation
        {
            sightRotation.GetComponent<SightRotationConroller>().UpdateRotation(direction);
        }
    }

    float MoveValue(string axisName)
    {
        return Input.GetAxis(axisName) * speed * Time.deltaTime;
    }

    public void EnemyTouched() // EnemyController calls this aswell
    {
        LevelManager.instance.EnemyTouched();
    }

    void FoodTouched(GameObject food)
    {
        LevelManager.instance.FoodTouched(food);
    }
}
