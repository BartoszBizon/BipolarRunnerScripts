using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PatrolLeftRight : MonoBehaviour
{
    [SerializeField] private EnemyCore enemyCore;
    [SerializeField] private float moveXSpeed;
    public float MoveXSpeed => moveXSpeed;
    
    [SerializeField] private float raycastLength;
    [SerializeField] private Transform groundCheckPosition;
    [SerializeField] private UnityEvent onMoveLeft;
    [SerializeField] private UnityEvent onMoveRight;

    private bool stopMove;
    public bool StopMove
    {
        get => stopMove;
        set => stopMove = value;
    }

    private enum directions
    {
        left,
        right
    }

    private Vector2 directionVector;
    private directions currentDirection;
    private RaycastHit2D checkGround;


    private void OnEnable()
    {
        directionVector = Vector2.right;
        SetMoveDirection();
    }


    private void Update()
    {
        if (stopMove)
            return;
        
        enemyCore.transform.Translate(directionVector * moveXSpeed * Time.deltaTime);
        
        checkGround = Physics2D.Raycast(groundCheckPosition.position, Vector2.down, raycastLength);
        
        if (!checkGround.collider)
        {
            CheckDirection();
        }
    }

    private void SetMoveDirection()
    {
        int randomNumber = Random.Range(0, 1);

        if (randomNumber == 0)
        {
            currentDirection = directions.left;
            enemyCore.transform.eulerAngles = new Vector3(0,-180,0);
        }
        else
        {
            currentDirection = directions.right;
            enemyCore.transform.eulerAngles = new Vector3(0,0,0);
        }
    }

    private void CheckDirection()
    {
        if (currentDirection == directions.right)
        {
            onMoveLeft.Invoke();
            currentDirection = directions.left;
            enemyCore.transform.eulerAngles = new Vector3(0,-180,0);
        }
        else
        {
            onMoveRight.Invoke();
            currentDirection = directions.right;
            enemyCore.transform.eulerAngles = new Vector3(0,0,0);
        }

    }
    
    
}
