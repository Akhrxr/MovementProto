using System.Collections;
using UnityEngine;

public class RaycastLight : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float laserDuration = 0.05f;

    LineRenderer laserLine;
    bool isFiring;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.enabled = false; // Initially disable the laser line
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartFiring();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopFiring();
        }

        if (isFiring)
        {
            FireLaser();
        }
    }

    void StartFiring()
    {
        isFiring = true;
        laserLine.enabled = true;
    }

    void StopFiring()
    {
        isFiring = false;
        laserLine.enabled = false;
    }

    void FireLaser()
    {
        laserLine.SetPosition(0, laserOrigin.position);
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
        {
            laserLine.SetPosition(1, hit.point);
            Debug.Log("Light ray hit: " + hit.transform.name);
            //Destroy(hit.transform.gameObject);
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
        }
    }
}
