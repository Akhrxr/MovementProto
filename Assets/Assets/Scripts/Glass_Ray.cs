using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass_Ray : MonoBehaviour
{
    [SerializeField] private float raycastRange = 10;
    [SerializeField] private bool isActive = false; //If active, fire light source
    [SerializeField] private bool isOnGround = true; //If isOnGround, it can be set to Active
    private LineRenderer reflectedLine;
    [SerializeField] private Transform laserOrigin;
    [SerializeField] private Transform laserEnd; //Dynamic endpoint of laser
    [SerializeField] private Transform laserEnd_OG; //Original endpoint of laser

    private void Awake()
    {
        reflectedLine = GetComponent<LineRenderer>();
        reflectedLine.enabled = false; //Off at start
        reflectedLine.SetPosition(0, laserOrigin.position);
        reflectedLine.SetPosition(1, laserEnd.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        isActive = false; //Set isActive and isHitByLight to false upon start of level
        isOnGround = true; //Glass Object isn't picked up yet
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 raycastDirection = Vector3.forward; //Generating RayCast
        Ray lightBeam = new Ray(transform.position, transform.TransformDirection(raycastDirection * raycastRange));
        reflectedLine.SetPosition(0, laserOrigin.position);

        if(Physics.Raycast(lightBeam, out RaycastHit hitObject, raycastRange)){ //Raycast hits something
            laserEnd.position = new Vector3(hitObject.collider.gameObject.transform.position.x, laserEnd.position.y, hitObject.collider.gameObject.transform.position.z); //Changing position of laserEnd to draw line until hitObject position
            if(hitObject.collider.tag == "Glass"){ //If this Glass Object's RayCast hits another, switchToActive()
                var hitObjectScript = hitObject.collider.gameObject.GetComponent<Glass_Ray>(); //Accessing Script of RayCastHit Object
                if(isActive == true){
                    hitObjectScript.switchToActive();
                } else{
                    hitObjectScript.switchToInactive();
                }
            } 
        } else{ //Raycast hits nothing
            laserEnd.position = laserEnd_OG.position; //Ressetting end point of laser to base range of glass object
        }

        if(isActive == true){ //For debugging, make RayCast visible
            Debug.DrawRay(transform.position, transform.TransformDirection(raycastDirection * raycastRange), Color.red); //Make RayCast RED if is hit by light
            reflectedLine.SetPosition(1, laserEnd.position); //Setting end position of reflected laser
            reflectedLine.enabled = true;
        } else{
            Debug.DrawRay(transform.position, transform.TransformDirection(raycastDirection * raycastRange)); //RayCast WHITE if not active
            reflectedLine.SetPosition(1, laserEnd.position);
            reflectedLine.enabled = false;
        }
    }

    public void switchToActive(){
        if(isOnGround == true){ //Can only become active if on the ground
            isActive = true;
        }
    }

    public void switchToInactive(){
        Vector3 raycastDirection = Vector3.forward; //Generating RayCast to send a signal to other glass objects hit to switch to inactive
        Ray lightBeam = new Ray(transform.position, transform.TransformDirection(raycastDirection * raycastRange));
        if(Physics.Raycast(lightBeam, out RaycastHit hitObject, raycastRange)){
            if(hitObject.collider.tag == "Glass"){ //If this Glass Object's RayCast hits another, switchToActive()
                var hitObjectScript = hitObject.collider.gameObject.GetComponent<Glass_Ray>(); //Accessing Script of RayCastHit Object
                hitObjectScript.switchToInactive();
            }
        }
        isActive = false;
        //reflectedLine.enabled = false;
    }

    public void switchToOnGround(){
        isOnGround = true;
    }

    public void switchToOffGround(){
        isOnGround = false;
    }
}
