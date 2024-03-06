using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    private float mySpeed = 12f;
    //bool IsGrounded = true;
    float rot = 0f;
    float r;

    public void playerMovement(Rigidbody myRB)
    {
        //Debug.Log(IsGrounded());
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
            myRB.velocity = new Vector3(0, 0, 0);
        }
        if (transform.position.y < 1.2f) {
            transform.position = new Vector3(transform.position.x, 1.2f, transform.position.z);
        }
        myRB.angularVelocity = Vector3.zero;
    }
    
    public void rotation()
    {   
        if (Input.GetAxis("Horizontal") > 0) {
            rot += 0.5f; //I've reduced rotation speed to not be so fast as it was when it was originally += 2f - Sean
        }
        else if (Input.GetAxis("Horizontal") < 0) {
            rot += -0.5f;
        }
        float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rot, ref r, 0.1f);
        transform.rotation = Quaternion.Euler(0, Angle, 0);
    }

    /*public bool IsGrounded() //Might need later on possibly maybe hopefully maybe
    {
        if (Physics.Raycast(transform.position, -Vector3.up, out RaycastHit hitinfo, 2f)) {
            if (hitinfo.collider.gameObject.transform.tag == "Floor") {
                return true;
            }
        }
        return false;
    }*/
}
