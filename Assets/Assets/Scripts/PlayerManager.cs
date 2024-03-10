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
        deathParticles = neonDeathParticleEmitter.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        MovementScript.playerMovement(RB);
    }

    public void neonDeath(){
        neonDeathParticleEmitter.transform.position = Player.transform.position; //Changing position of particle emitter to Neon's location
        deathParticles.Play(); //Playing particle burst
        neonBody.SetActive(false); //Deactivating Neon
    }
}
