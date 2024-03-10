using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.InputSystem;

public class Glass_Ray : MonoBehaviour
{
    private float raycastRange = 15;
    [SerializeField] private bool isActive = false; //If active, fire light source
    [SerializeField] private bool isOnGround = true; //If isOnGround, it can be set to Active
    [SerializeField] public string direction; //For the UI
    private LineRenderer reflectedLine;
    [SerializeField] private Transform laserOrigin;
    [SerializeField] private Transform laserEnd; //Dynamic endpoint of laser
    [SerializeField] private Transform laserEnd_OG; //Original endpoint of laser
    [SerializeField] private GameObject particleEmitter;

    public DoorTarget target1;
    private bool door1Open;
    public DoorTarget target2;
    private bool door2Open;
    public DoorTarget target3;
    private bool door3Open;
    public DoorTarget target4;
    private bool door4Open;
    public DoorTarget target5;
    private bool door5Open;

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
        particleEmitter.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 raycastDirection = Vector3.forward; //Generating RayCast
        Ray lightBeam = new Ray(transform.position, transform.TransformDirection(raycastDirection * raycastRange));
        reflectedLine.SetPosition(0, laserOrigin.position);

        if (Physics.Raycast(lightBeam, out RaycastHit hitObject, raycastRange)) { //Raycast hits something
            //laserEnd.position = new Vector3(hitObject.collider.gameObject.transform.position.x, laserEnd.position.y, hitObject.collider.gameObject.transform.position.z);
            if(direction == "up" || direction == "down"){ //Changing position of laserEnd to draw line until hitObject position
                laserEnd.position = new Vector3(laserEnd_OG.position.x, laserEnd.position.y, hitObject.collider.gameObject.transform.position.z);
            } else{ // direction == "right" || direction == "left"
                laserEnd.position = new Vector3(hitObject.collider.gameObject.transform.position.x, laserEnd.position.y, laserEnd_OG.position.z);
            }

            if (hitObject.collider.gameObject.CompareTag("Target1") && !door1Open && isActive == true){
                door1Open = true;
                hitObject.transform.SendMessage("OpenDoor1");
            } else if (hitObject.collider.gameObject.CompareTag("Target2") && !door2Open && isActive == true){
                door2Open = true;
                hitObject.transform.SendMessage("OpenDoor2");
            } else if (hitObject.collider.gameObject.CompareTag("Target3") && !door3Open && isActive == true){
                door3Open = true;
                hitObject.transform.SendMessage("OpenDoor3");
            } else if (hitObject.collider.gameObject.CompareTag("Target4") && !door4Open && isActive == true){
                door4Open = true;
                hitObject.transform.SendMessage("OpenDoor4");
            } else if (hitObject.collider.gameObject.CompareTag("Target5") && !door5Open && isActive == true){
                door5Open = true;
                hitObject.transform.SendMessage("OpenDoor5");
            } else if (hitObject.collider.tag == "Glass") { //If this Glass Object's RayCast hits another, switchToActive()
                var hitObjectScript = hitObject.collider.gameObject.GetComponent<Glass_Ray>(); //Accessing Script of RayCastHit Object
                if (isActive == true) {
                    hitObjectScript.switchToActive();
                } else {
                    hitObjectScript.switchToInactive();
                }
            } 
        } else { //Raycast hits nothing
            laserEnd.position = laserEnd_OG.position; //Ressetting end point of laser to base range of glass object
        }

        if (isActive == true) { //For debugging, make RayCast visible
            //Debug.DrawRay(transform.position, transform.TransformDirection(raycastDirection * raycastRange), Color.red); //Make RayCast RED if is hit by light
            reflectedLine.SetPosition(1, laserEnd.position); //Setting end position of reflected laser
            reflectedLine.enabled = true;
            particleEmitter.SetActive(true);
        } else {
            //Debug.DrawRay(transform.position, transform.TransformDirection(raycastDirection * raycastRange)); //RayCast WHITE if not active
            reflectedLine.SetPosition(1, laserEnd.position);
            reflectedLine.enabled = false;
            particleEmitter.SetActive(false);
        }
    }

    public void switchToActive() {
        if (isOnGround == true) { //Can only become active if on the ground
            isActive = true;
        }
    }

    public void switchToInactive() {
        Vector3 raycastDirection = Vector3.forward; //Generating RayCast to send a signal to other glass objects hit to switch to inactive
        Ray lightBeam = new Ray(transform.position, transform.TransformDirection(raycastDirection * raycastRange));
        if (Physics.Raycast(lightBeam, out RaycastHit hitObject, raycastRange)) {
            if (hitObject.collider.tag == "Glass") { //If this Glass Object's RayCast hits another, switchToActive()
                var hitObjectScript = hitObject.collider.gameObject.GetComponent<Glass_Ray>(); //Accessing Script of RayCastHit Object
                hitObjectScript.switchToInactive();
            }
        }
        isActive = false;
        particleEmitter.SetActive(false);
    }

    public void switchToOnGround() {
        isOnGround = true;
    }

    public void switchToOffGround() {
        isOnGround = false;
    }

    public string getDirection(){
        return direction;
    }

}
