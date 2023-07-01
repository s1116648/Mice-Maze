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
            LevelManager.instance.EnemySurrounded(transform.gameObject);
        }
    }

    bool DirectionBlocked(Vector3 direction)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out RaycastHit hit, 0.75f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.yellow);
            return !IsPlayer(hit.transform.gameObject);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * 0.75f, Color.white);
            return false;
        }
    }

    bool IsPlayer(GameObject obj)
    {
        return (obj.tag == TagNames.Player);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagNames.Player)
        {
            TryFollowPlayer(other.gameObject);
        }
    }

    void TryFollowPlayer(GameObject player)
    {
        if (SeesPlayer(player))
        {
            Debug.Log("Try to move to player");
        }
    }

    bool SeesPlayer(GameObject player)
    {
        Vector3 direction = FindDirection(player.transform.position);
        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out RaycastHit hit, 5f))
        {
            return IsPlayer(hit.transform.gameObject);
        }
        return false;
    }

    Vector3 FindDirection(Vector3 destination)
    {
        return destination - transform.position;
    }
}