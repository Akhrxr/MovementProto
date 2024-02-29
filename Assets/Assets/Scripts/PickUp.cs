using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickUp: MonoBehaviour
{
    
    public float speed = 5f; // Movement speed
    Rigidbody rb; // Reference to the Rigidbody component
    public GameObject carry;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the reference to the Rigidbody component attached to this GameObject
    }

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && carry == null)
        {
            PickUp();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && carry != null)
        {
            Drop();
        }
    }

    void PickUp()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 3f))
        {
            if (hit.collider.CompareTag("Pickup"))
            {
                carry = hit.collider.gameObject;
                carry.GetComponent<Rigidbody>().isKinematic = true;
                carry.transform.parent = transform;
            }
        }
    }

    void Drop()
    {   
            
        carry.GetComponent<Rigidbody>().isKinematic = false;
        carry.transform.parent = null;
        carry = null;
             
    }
}

