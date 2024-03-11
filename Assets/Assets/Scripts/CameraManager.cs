using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    [SerializeField] private GameObject cameraMain;
    [SerializeField] private GameObject cameraEnd;

    void Awake(){
        if(instance == null){
            instance = this; //If this is the first instance of the game manager, create it
        } else{
            Destroy(this); //Else, destroy it and keep original instance
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraMain.SetActive(true);
        cameraEnd.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchToEndCamera(){ //Switching camera at the end of the game
        cameraMain.SetActive(false);
        cameraEnd.SetActive(true);
    }
}
