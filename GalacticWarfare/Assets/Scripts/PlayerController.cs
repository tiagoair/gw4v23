using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform shootLocation;
    [SerializeField] private GameObject simpleBulletPrefab;
    [SerializeField] private float fireRate;
    
    
    private GameControls _controls;
    private Vector2 _moveInput;
    private Rigidbody2D _rigidbody;
    private Camera _camera;
    private bool _isShooting;
    private float _fireTimer;

    private void OnEnable()
    {
        playerInput.onActionTriggered += OnPlayerInput;
    }

    private void OnDisable()
    {
        playerInput.onActionTriggered -= OnPlayerInput;
    }


    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _controls = new GameControls();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void FixedUpdate()
    {
        MoveShip();
        LimitMovementToCamera();
    }

    private void OnPlayerInput(InputAction.CallbackContext obj)
    {
        if (obj.action.name == _controls.Gameplay.Move.name)
        {
            _moveInput = obj.ReadValue<Vector2>();
        }

        if (obj.action.name == _controls.Gameplay.Shoot.name)
        {
            if (obj.started)
            {
                _isShooting = true;
            }

            if (obj.canceled)
            {
                _isShooting = false;
            }
        }
    }

    private void MoveShip()
    {
        _rigidbody.velocity = _moveInput.normalized * moveSpeed;
    }

    private void LimitMovementToCamera()
    {
        Vector3 checkPosition = transform.position;
        checkPosition.x = Mathf.Clamp(checkPosition.x, _camera.transform.position.x -_camera.orthographicSize * _camera.aspect, 
            _camera.transform.position.x + _camera.orthographicSize * _camera.aspect);
        checkPosition.y = Mathf.Clamp(checkPosition.y, _camera.transform.position.y -_camera.orthographicSize, _camera.transform.position.y + _camera.orthographicSize);
        transform.position = checkPosition;
    }
    
    private void Shoot()
    {
        if(Time.time > _fireTimer + fireRate && _isShooting)
        {
            Instantiate(simpleBulletPrefab, shootLocation.position, Quaternion.identity);
            _fireTimer = Time.time;
        }
        
    }
}
