using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTest : MonoBehaviour
{
    private bool laserOn = false;
    public GameObject startObj;
    public GameObject endObj;
    public Animator open;
    private bool doorOpen = false;
    public LineRenderer laserline;
    public Transform laserOrigin;
    public Transform endObjOrigin;
    [SerializeField] private Transform endObjOrigin_Main; //The original ending area for the laser

    private void Awake()
    {
        laserline = GetComponent<LineRenderer>();
        laserline.enabled = true;
        laserline.SetPosition(0, laserOrigin.position);

    }

    // Start is called before the first frame update
    void Start()
    {
        laserline.positionCount = 2;
        laserline.SetPosition(0, laserOrigin.position);
        laserline.SetPosition(1, endObjOrigin.position);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.DrawRay(startObj.transform.position, startObj.transform.up * 20, Color.red);

        if (!laserOn)
        {
            Debug.DrawRay(startObj.transform.position, startObj.transform.up * 100f);

            RaycastHit hit;
            if(Physics.Raycast(startObj.transform.position, startObj.transform.up, out hit, 100f))
            {
                if (hit.collider.gameObject.CompareTag("Target") && !doorOpen)
                {
                    Debug.Log("ray shooting");

                    open = open.GetComponent<Animator>();
                    open.enabled = true;
                    open.Play("DoorOpen", 0, 0);
                    doorOpen = true;
                    StartCoroutine(WaitForAnimation());
                } else if(hit.collider.tag == "Glass"){ //If Light Source RayCast hits GlassObject, switchToActive()
                    endObjOrigin.position = new Vector3(hit.collider.gameObject.transform.position.x, endObjOrigin.position.y, hit.collider.gameObject.transform.position.z); //Changing position of laserEnd to draw line until hitObject position
                    var hitObjectScript = hit.collider.gameObject.GetComponent<Glass_Ray>(); //Accessing Script of RayCastHit Object
                    hitObjectScript.switchToActive();
                } else if(hit.collider.tag == "Player"){
                    endObjOrigin.position = new Vector3(hit.collider.gameObject.transform.position.x, endObjOrigin.position.y, hit.collider.gameObject.transform.position.z); //Changing position of laserEnd to draw line until hitObject position
                } else{
                    endObjOrigin.position = endObjOrigin_Main.position; //Resetting end position of laser to the original if no objects are hit
                }
                laserline.SetPosition(1, endObjOrigin.position); //Setting end position of laser
            }
        }
    }
    public void shootRay()
    {
        laserOn = true;
    }
    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(1.3f);
        open.enabled = false;
    }
}
