using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComplete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider){
        Debug.Log("Object Detected!!");
        if(collider.tag == "Player"){
            Debug.Log("Game Clear!");
        }
    }
}
