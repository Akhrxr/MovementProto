using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    Quaternion storeRotation;
    public float speed = 5f; // Movement speed
    Rigidbody rb; // Reference to the Rigidbody component
    public GameObject carry;
    private float pickUpHeight = 1.5f;
    public GameObject glassObject;
    
    private bool created = false;
    public TextMeshProUGUI displayText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //There's only detection if space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && carry == null)
        {
            PickUpF();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && carry != null)
        {
            Drop();
        }
        if (carry != null)
        {
            carry.transform.rotation = storeRotation;
            glassObject.SetActive(true);
            glassObject.transform.position = new Vector3(carry.transform.position.x, 0.6f, carry.transform.position.z);
            displayText.enabled = false;

        }
        else
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 7f))
            {
                if (hit.collider.CompareTag("Glass"))
                {
                    displayText.enabled = true;
                    displayText.text = "Press Space to Pick Up";
                }
            }
            else
            {
                //displayText.text = "";
                displayText.enabled = false;
            }
            glassObject.SetActive(false);
        }

    }

    void PickUpF()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 7f))
        {

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

                UIManager.instance.displayEquipped(hitObjectScript.getDirection()); //Updating UI
                UIManager.instance.updateEquippedText(hitObjectScript.getDirection());
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
        
        UIManager.instance.displayUnequipped(); //Updating UI
        UIManager.instance.updateEquippedText("none");
    }
}
