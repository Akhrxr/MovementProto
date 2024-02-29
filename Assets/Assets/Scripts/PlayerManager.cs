using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject Player;

    Rigidbody RB;
    private Movement MovementScript;

    private static PlayerManager _instance;
    public static PlayerManager Instance { get { return _instance;}}


    private void Awake() {
        if (_instance != null && _instance != this) 
        {
            Destroy(this.gameObject);
        }
        else {
            _instance = this;
        }
        MovementScript = Player.GetComponent<Movement>();
    }

    private void Start() 
    {
        RB = Player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovementScript.playerMovement(RB);
    }
}
