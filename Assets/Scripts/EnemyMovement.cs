using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // speed and rotation speed of enemies that are configuarable
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;


    private Rigidbody2D _RBD2;
    private PlayerAwarenessContoller playerAwarenessContoller;
    private Vector2 _targetDirection;
    private float _changeDirectionCooldown;

    private void Awake()
    {
        
        _RBD2 = GetComponent<Rigidbody2D>();
        playerAwarenessContoller = GetComponent<PlayerAwarenessContoller>();
        _targetDirection = transform.up;
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
        // calls both functions to allow for changing of directions both at player and randomly
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
    }

    private void HandleRandomDirectionChange()
    {
        // if the direction cooldown is up the enemies will move either left or right randomly
        _changeDirectionCooldown -= Time.deltaTime;
        
        // the 5 stops them from hugging walls for the most part
        if(_changeDirectionCooldown <= 5)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection;

            _changeDirectionCooldown = Random.Range(1f, 5f);
        }
    }

    private void HandlePlayerTargeting()
    {
        if (playerAwarenessContoller.AwareOfPlayer)
        {
            _targetDirection = playerAwarenessContoller.DirectionToPlayer;
        }
    }

    private void RotateTowardsTarget()
    {
        // allows enemies to rotate to move towards the target
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _RBD2.SetRotation(rotation);
    }
    private void SetVelocity()
    {
        
            _RBD2.velocity = transform.up * _speed;
     }
    
}
