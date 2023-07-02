using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    GameObject 
        frontSide,
        leftSide,
        rightSide;

    float speed = 3.5f;

    readonly float rayLenght = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckIfSurrounded();
        Move();
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
        return DirectionBlocked(transform.position, direction);
    }

    bool DirectionBlocked(Vector3 position, Vector3 direction)
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagNames.Player)
            TryFollowPlayer(other.gameObject);
    }

    void TryFollowPlayer(GameObject player)
    {
        if (SeesPlayer(player))
            Debug.Log("Try to move to player");
    }

    bool SeesPlayer(GameObject player)
    {
        Vector3 direction = FindDirection(player.transform.position);
        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out RaycastHit hit, 5f))
            return IsPlayer(hit.transform.gameObject);
        return false;
    }

    Vector3 FindDirection(Vector3 destination)
    {
        return destination - transform.position;
    }

    void Move()
    {
        Vector3 forwardDirection = transform.rotation * transform.forward;
        if (CanMoveForward(forwardDirection))
        {
            MoveForward(forwardDirection);
        }
    }

    void MoveForward(Vector3 forwardDirection)
    {
        float
            moveX = forwardDirection.x * speed * Time.deltaTime,
            moveZ = forwardDirection.z * speed * Time.deltaTime;
        transform.Translate(moveX, 0, moveZ);
    }

    bool CanMoveForward(Vector3 direction)
    {
        if (MiddleForwardBlocked(direction))
            return false;
        if (LeftForwardBlocked(direction))
            return false;
        if (RightForwardBlocked(direction))
            return false;
        return true;
    }

    bool MiddleForwardBlocked(Vector3 direction)
    {
        Vector3 position = frontSide.gameObject.transform.position;
        return DirectionBlocked(position, direction);
    }

    bool LeftForwardBlocked(Vector3 direction)
    {
        Vector3 position = leftSide.gameObject.transform.position;
        return DirectionBlocked(position, direction);
    }

    bool RightForwardBlocked(Vector3 direction)
    {
        Vector3 position = rightSide.gameObject.transform.position;
        return DirectionBlocked(position, direction);
    }
}