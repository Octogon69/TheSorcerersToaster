using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;


    private Rigidbody2D _RBD2;
    private PlayerAwarenessContoller playerAwarenessContoller;
    private Vector2 _targetDirection;

    private void Awake()
    {
        _RBD2 = GetComponent<Rigidbody2D>();
        playerAwarenessContoller = GetComponent<PlayerAwarenessContoller>();
    }



    // Update is called once per frame
    private void FixedUpdate()
    {
        updateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void updateTargetDirection()
    {
        if (playerAwarenessContoller.AwareOfPlayer)
        {
            _targetDirection = playerAwarenessContoller.DirectionToPlayer;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }
    }
    private void RotateTowardsTarget()
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _RBD2.SetRotation(rotation);
    }
    private void SetVelocity()
    {
        if (_targetDirection == Vector2.zero)
        {
            _RBD2.velocity = Vector2.zero;

        }
        else
        {
            _RBD2.velocity = transform.up * _speed;
        }
    }
}
