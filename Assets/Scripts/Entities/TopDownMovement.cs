using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;
    private CharacterStats _stats;
    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;
    
    private Animator _animator;

    private CharacterStatsHandler _stats;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _stats = GetComponent<CharacterStats>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _stats = GetComponent<CharacterStatsHandler>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * _stats.CurrentStates.speed;

        if (direction != Vector2.zero) 
        {
            _animator.SetBool("IsRun", true);
        }
        else
        {
            _animator.SetBool("IsRun", false);
        }

        _rigidbody.velocity = direction;
    }
}
