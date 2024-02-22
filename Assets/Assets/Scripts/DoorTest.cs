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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.DrawRay(startObj.transform.position, startObj.transform.up * 20, Color.red);

        if (laserOn)
        {
            Debug.DrawRay(startObj.transform.position, startObj.transform.up * 20f);

            RaycastHit hit;
            if(Physics.Raycast(startObj.transform.position, startObj.transform.up, out hit, 20f))
            {
                if (hit.collider.gameObject.CompareTag("Target") && !doorOpen)
                {
                    Debug.Log("ray shooting");

                    open = open.GetComponent<Animator>();
                    open.enabled = true;
                    open.Play("DoorOpen", 0, 0);
                    doorOpen = true;
                    StartCoroutine(WaitForAnimation());
                }
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
