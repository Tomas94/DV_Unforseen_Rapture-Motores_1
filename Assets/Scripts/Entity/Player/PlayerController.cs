using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : Entity
{
    public Vector2 lastCheckPoint;
    
    //Referencias
    PlayerMovement playerMovement;
    PlayerCollisions playerCollisions;

    [Header("Variables Vida")]
    [SerializeField] int _maxHP;
    [SerializeField] int _currentHP;

    [Header("Variables de Movimiento")]
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;

    [Header("Booleanos")]
    [SerializeField] bool _isGrounded;



    public event EventHandler Muerte_Player;
    
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCollisions = GetComponent<PlayerCollisions>();
    }

    void Start()
    {
        lastCheckPoint = transform.position;  
        MaxLifes = _maxHP;
        currentLifes = MaxLifes;
    }

    private void Update()
    {
        UpdateVariables();
        MovementController();
    }

    void MovementController()
    {
        if (playerMovement != null)
        {
            if (playerMovement.horizontalMove != Vector2.zero) playerMovement.StartMovement();
            else playerMovement?.StopMovement();

            if (Input.GetKeyDown(KeyCode.W) && _isGrounded) playerMovement.Jump(_jumpForce);           
        }
    }

    public void Death()
    {
        Muerte_Player?.Invoke(this, EventArgs.Empty);
    }

    void UpdateVariables()
    {
        _isGrounded = playerCollisions._isGrounded;
        _currentHP = currentLifes;
        playerMovement?.SetSpeed(_speed);
    }
}
