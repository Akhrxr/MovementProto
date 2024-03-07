using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    private Vector3 MovementInput;
    private Vector2 MouseInput; //Inputs
    private float mySpeed = 10f; //Speed
    private float sense = 4f; //sensitivity
    private float xRotation;

    public void playerMovement(Rigidbody myRB)
    {
        MovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        //Rotation
        rotation();     
        //Movement
        Vector3 MoveVector = transform.TransformDirection(MovementInput) * mySpeed;
        myRB.velocity = new Vector3(MoveVector.x, myRB.velocity.y, MoveVector.z);
        
    }
    
    public void rotation()
    {   
        xRotation += MouseInput.x * sense;
        transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
    }
}
