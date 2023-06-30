using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckIfSurrounded();
    }

    void CheckIfSurrounded()
    {
        bool surrounded = true;
        if (!DirectionBlocked(Vector3.left)) {
            surrounded = false;
        }
        if (!DirectionBlocked(Vector3.right))
        {
           surrounded = false;
        }
        if (!DirectionBlocked(Vector3.forward))
        {
            surrounded = false;
        }
        if (!DirectionBlocked(Vector3.back))
        {
            surrounded = false;
        }
        if (surrounded)
        {
            Destroy(transform.gameObject);
        }
    }

    bool DirectionBlocked(Vector3 direction)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out RaycastHit hit, 0.75f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.yellow);
            return IsNotPlayer(hit.transform.gameObject);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * 0.75f, Color.white);
            return false;
        }
    }

    bool IsNotPlayer(GameObject obj)
    {
        if (obj.tag == TagNames.Player)
        {
            return false;
        }
        return true;
    }
}