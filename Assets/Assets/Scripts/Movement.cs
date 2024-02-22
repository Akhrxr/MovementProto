using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    Rigidbody myRB;
    private float curVelocity;
    private float mySpeed = 20f;
    bool IsGrounded = false;
    float rot = 0f;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.transform.tag == "Floor")
        {
            IsGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.transform.tag == "Floor")
        {
            IsGrounded = false;
        }
    }
    public void playerMovement()
    {
        myRB = GetComponent<Rigidbody>();
    //Rotation
        rotation();
    //Movement
        if (Input.GetAxis("Vertical") > 0) {
            myRB.AddRelativeForce(Vector3.forward * mySpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else if (Input.GetAxis("Vertical") < 0) {
            myRB.AddRelativeForce(Vector3.back * mySpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else
        {
            if (IsGrounded)
            {
                myRB.velocity = new Vector3(0, myRB.velocity.y, 0);
            }
        }
        if (IsGrounded)
        {
                if (Input.GetAxis("Jump") > 0) 
                {
                    myRB.AddForce(Vector3.up * 6 * mySpeed);
                }
        }
        else 
        {
            if (Input.GetAxis("Jump") > 0) 
                {
                    myRB.AddForce(Vector3.up * 5 * mySpeed);
                }
            else if (Input.GetKeyDown(KeyCode.Tab)) 
            {
                myRB.AddRelativeForce(Vector3.down *10 * mySpeed * Time.deltaTime, ForceMode.VelocityChange);
            }
        }
    }
    
    public void rotation()
    {
        if (Input.GetAxis("Horizontal") == 0) return;

        if (Input.GetAxis("Horizontal") > 0) {
            rot += 0.7f;
        }
        else if (Input.GetAxis("Horizontal") < 0) {
            rot += -0.7f;
        }
        transform.rotation = Quaternion.Euler(0.0f, rot, 0.0f);
    }
}
