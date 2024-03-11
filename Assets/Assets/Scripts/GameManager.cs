using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Game Manager Variable
    public static GameManager instance; //Static enables it to be called anywhere
    private static bool isGameOver = false;
    private static bool gameIsPaused = false;
    private static bool playerWin = false;

    public GameObject PauseMenuObj;
    private PauseMenu PMScript;

    // Awake is called upon creation, before everything else 
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
        PMScript = PauseMenuObj.GetComponent<PauseMenu>();
        isGameOver = false;
        gameIsPaused = false;
        playerWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameIsPaused = PMScript.isPaused;
    }

    public bool isGameOverStatus(){
        return isGameOver;
    }

    public bool playerWinStatus(){
        return playerWin;
    }

    public void GameOver_Win(){
        isGameOver = true;
        playerWin = true;
    }

    public void GameOver_Lose(){
        PlayerManager.Instance.neonDeath();
        isGameOver = true;
    }
}
