using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComplete : MonoBehaviour
{
    [SerializeField] private GameObject completeParticleEmitter;
    private ParticleSystem completeParticles;   

    // Start is called before the first frame update
    void Start()
    {
        completeParticles = completeParticleEmitter.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            GameManager.instance.GameOver_Win();
            completeParticles.Play();
            PlayerManager.Instance.neonDeath();
        }
    }
}
