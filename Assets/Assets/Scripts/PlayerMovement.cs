using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _input;
    private Vector3 _direction;
    private CharacterController _cc;
    Rigidbody myRB;

    private float gravity = -9.81f;
    private float velocity;
    private float curVelocity;
    [SerializeField] private float gravityMult = 3.0f;
    [SerializeField] float smoothTime = 0.2f;
    [SerializeField] private float speed = 10;
    [SerializeField] private float jumpPow = 120f;

    private void Update() 
    {
        ApplyGrav();
        rotation();
        ApplyMove();
    }
    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
        _cc = GetComponent<CharacterController>();
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0, _input.y);
    }
    public void ApplyMove()
    {
        _cc.Move(_direction * speed * Time.deltaTime);
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded()) return;
        velocity += jumpPow;
    }
    public void rotation()
    {
        if (_input.sqrMagnitude == 0) return;
        var targetAngle = Mathf.Atan2(_direction.x,_direction.z) * Mathf.Rad2Deg; //returns the value in degrees
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref curVelocity, smoothTime); //smoothens out the angle for it to turn overtime
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f); // in Euler, Y axis rotates the objects x axis. idk why
    }
    public void ApplyGrav()
    {
        if (_cc.isGrounded && velocity < 0)
        {
            velocity = -1f;
        }
        else
        {
            velocity+= gravity * gravityMult * Time.deltaTime;
        }
        velocity+= gravity * gravityMult * Time.deltaTime;
        _direction.y = velocity;
    }
    private bool IsGrounded() => _cc.isGrounded;

}

