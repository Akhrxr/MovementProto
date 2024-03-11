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
    [SerializeField] private GameObject neonBody;
    [SerializeField] private GameObject neonDeathParticleEmitter;
    private ParticleSystem deathParticles;    
    public GameObject PauseMenuObj;
    private PauseMenu PMScript;


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
        PMScript = PauseMenuObj.GetComponent<PauseMenu>();
        deathParticles = neonDeathParticleEmitter.GetComponent<ParticleSystem>();
    }

    void Update()
    {   
        if (!PMScript.isPaused) 
        {
            MovementScript.playerMovement(RB);
        }
    }

    public void neonDeath(){
        neonDeathParticleEmitter.transform.position = Player.transform.position; //Changing position of particle emitter to Neon's location
        deathParticles.Play(); //Playing particle burst
        neonBody.SetActive(false); //Deactivating Neon
    }
}
