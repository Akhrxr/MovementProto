using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickUp: MonoBehaviour
{
    Quaternion storeRotation; 
    public float speed = 5f; // Movement speed
    Rigidbody rb; // Reference to the Rigidbody component
    public GameObject carry;
    private float pickUpHeight = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the reference to the Rigidbody component attached to this GameObject
    }
    /*
    void FixedUpdate()
    {
         // Input from arrow keys or WASD
         float moveHorizontal = Input.GetAxis("Horizontal");
         float moveVertical = Input.GetAxis("Vertical");

         // Calculate movement direction
         Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

         // Apply movement to the Rigidbody
         rb.AddForce(movement * speed);
    }
    */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && carry == null)
        {
            Debug.Log("Space Pressed"); //For Debugging
            PickUpF();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && carry != null)
        {
            Drop();
        }
        if(carry != null)
        {
            carry.transform.rotation = storeRotation;
        }
        
    }

    void PickUpF()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 7f))
        {
  
            //Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green, 10f);
            //Debug.Log(hit.transform.tag);
            if (hit.collider.CompareTag("Glass"))
            {
                var hitObjectScript = hit.collider.gameObject.GetComponent<Glass_Ray>(); //Accessing Script of PickedUp Object
                hitObjectScript.switchToInactive(); //Switching GlassObject and its subsequent hit objects to Inactive
                hitObjectScript.switchToOffGround(); //Switching isOnGround Variable of Glass Object to Off

                storeRotation = hit.collider.transform.rotation;
                
                carry = hit.collider.gameObject;
                carry.transform.position = new Vector3(carry.transform.position.x, carry.transform.position.y + pickUpHeight, carry.transform.position.z);
                //carry.GetComponent<Rigidbody>().isKinematic = true;
                carry.GetComponent<Rigidbody>().useGravity = false;
                carry.transform.parent = transform;
            }
        }

    }

    void Drop()
    {   
        var carriedObjectScript = carry.GetComponent<Glass_Ray>(); //Accessing Script of PickedUp Object
        carriedObjectScript.switchToOnGround(); //Switching isOnGround Variable of Glass Object to On
    
        //carry.GetComponent<Rigidbody>().isKinematic = false;
        carry.transform.position = new Vector3(carry.transform.position.x, carry.transform.position.y - pickUpHeight, carry.transform.position.z);
        carry.transform.rotation = storeRotation;
        carry.GetComponent<Rigidbody>().useGravity = true;
        carry.transform.parent = null;
        carry = null;
    }
}

