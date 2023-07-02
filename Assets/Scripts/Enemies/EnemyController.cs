using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    readonly float 
        raySurroundedLenght = 0.5f,
        moveCheckerLength = 0.45f,
        sightDistance = 3f;

    enum MoveState { Chasing, Patrolling }
    MoveState moveState;

    NavMeshAgent agent;

    public GameObject target;

    bool hasPatrolDestination;

    // Start is called before the first frame update
    void Start()
    {
        moveState = MoveState.Patrolling;
        agent = transform.GetComponent<NavMeshAgent>();
        hasPatrolDestination = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfSurrounded();
        Move();
    }

    void Move()
    {
        UpdateMoveState();
        switch (moveState)
        {
            case MoveState.Chasing:
                ChasePlayer();
                break;
            case MoveState.Patrolling:
                Patrolling();
                break;
        }
    }

    void UpdateMoveState()
    {
        if (SeesPlayer())
            moveState = MoveState.Chasing;
        else
            moveState = MoveState.Patrolling;
    }

    void ChasePlayer()
    {
        agent.SetDestination(target.transform.position);
    }

    void Patrolling()
    {
        Debug.Log("Patrolling");
    }

    void CheckIfSurrounded()
    {
        if (!DirectionBlocked(Vector3.left)) return;
        if (!DirectionBlocked(Vector3.right)) return;
        if (!DirectionBlocked(Vector3.forward)) return;
        if (!DirectionBlocked(Vector3.back)) return;
        LevelManager.instance.EnemySurrounded(transform.gameObject);
    }

    bool DirectionBlocked(Vector3 direction)
    {
        return DirectionBlocked(transform.position, direction, raySurroundedLenght);
    }
    
    bool DirectionBlocked(Vector3 position, Vector3 direction, float rayLenght)
    {
        if (Physics.Raycast(position, transform.TransformDirection(direction), out RaycastHit hit, rayLenght))
        {
            Debug.DrawRay(position, transform.TransformDirection(direction) * hit.distance, Color.yellow);
            return !IsPlayer(hit.transform.gameObject);
        }
        else
        {
            Debug.DrawRay(position, transform.TransformDirection(direction) * rayLenght, Color.white);
            return false;
        }
    }

    bool IsPlayer(GameObject obj)
    {
        return (obj.tag == TagNames.Player);
    }

    bool SeesPlayer()
    {
        Vector3 direction = FindDirection(target.transform.position);
        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out RaycastHit hit, sightDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.yellow);
            return IsPlayer(hit.transform.gameObject);
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.red);
        return false;
    }

    Vector3 FindDirection(Vector3 destination)
    {
        Vector3 heading = destination - transform.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;
        return Quaternion.Euler(0, -transform.eulerAngles.y, 0) * direction;
    }
}