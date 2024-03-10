using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorTarget : MonoBehaviour
{
    public GameObject Door;
    public Animator Animator;
    private GameObject[] targetObjects;

    private bool door1Open = false;
    private bool door2Open = false;
    private bool door3Open = false;
    private bool door4Open = false;
    private bool door5Open = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Animator = Door.GetComponent<Animator>();
        targetObjects = GameObject.FindGameObjectsWithTag("Glass");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor1()
    {
        if (!door1Open)
        {
            Animator.enabled = true;
            Animator.Play("Door1", 0, 0);
            door1Open = true;
            StartCoroutine(WaitForAnimation());
        }
    }
    public void OpenDoor2()
    {
        if (!door2Open)
        {
            Animator.enabled = true;
            Animator.Play("Door2", 0, 0);
            door2Open = true;
            StartCoroutine(WaitForAnimation());
        }
    }
    public void OpenDoor3()
    {
        if (!door3Open)
        {
            Animator.enabled = true;
            Animator.Play("Door3", 0, 0);
            door3Open = true;
            StartCoroutine(WaitForAnimation());
        }
    }
    public void OpenDoor4()
    {
        if (!door4Open)
        {
            Animator.enabled = true;
            Animator.Play("Door4", 0, 0);
            door4Open = true;
            StartCoroutine(WaitForAnimation());
        }
    }
    public void OpenDoor5()
    {
        if (!door5Open)
        {
            Animator.enabled = true;
            Animator.Play("FinalDoorOpen", 0, 0);
            door5Open = true;
            StartCoroutine(WaitForAnimation());
        }
    }
    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(1.3f);
        Animator.enabled = false;
    }
}
