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
}
