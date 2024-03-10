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

    [SerializeField] private GameObject doorParticleEmitter;
    private ParticleSystem doorParticles;
    
    private AudioSource doorAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        Animator = Door.GetComponent<Animator>();
        targetObjects = GameObject.FindGameObjectsWithTag("Glass");
        doorParticles = doorParticleEmitter.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor1()
    {
        if (!door1Open)
        {
            doorParticles.Play(); //Playing particle burst
            Animator.enabled = true;
            Animator.Play("Door1", 0, 0);
            door1Open = true;
            doorAudioSource = Door.GetComponent<AudioSource>();
            doorAudioSource.Play();
            StartCoroutine(WaitForAnimation());
        }
    }
    public void OpenDoor2()
    {
        if (!door2Open)
        {
            doorParticles.Play(); //Playing particle burst
            Animator.enabled = true;
            Animator.Play("Door2", 0, 0);
            door2Open = true;
            doorAudioSource = Door.GetComponent<AudioSource>();
            doorAudioSource.Play();
            StartCoroutine(WaitForAnimation());
        }
    }
    public void OpenDoor3()
    {
        if (!door3Open)
        {
            doorParticles.Play(); //Playing particle burst
            Animator.enabled = true;
            Animator.Play("Door3", 0, 0);
            door3Open = true;
            doorAudioSource = Door.GetComponent<AudioSource>();
            doorAudioSource.Play();
            StartCoroutine(WaitForAnimation());
        }
    }
    public void OpenDoor4()
    {
        if (!door4Open)
        {
            doorParticles.Play(); //Playing particle burst
            Animator.enabled = true;
            Animator.Play("Door4", 0, 0);
            door4Open = true;
            doorAudioSource = Door.GetComponent<AudioSource>();
            doorAudioSource.Play();
            StartCoroutine(WaitForAnimation());
        }
    }
    public void OpenDoor5()
    {
        if (!door5Open)
        {
            doorParticles.Play(); //Playing particle burst
            Animator.enabled = true;
            Animator.Play("FinalDoorOpen", 0, 0);
            door5Open = true;
            doorAudioSource = Door.GetComponent<AudioSource>();
            doorAudioSource.Play();
            StartCoroutine(WaitForAnimation());
        }
    }
    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(1.3f);
        Animator.enabled = false;
    }
}
