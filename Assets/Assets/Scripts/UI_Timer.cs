using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private float remainingTime = 300; //Base time limit = 3 minutes aka 300
    private int minutes;
    private int seconds;
    private string timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeText = timerText.text;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGameOverStatus() == false){ //If game is still in play
            //Code based on https://www.youtube.com/watch?v=POq1i8FyRyQ: Make a TIMER & COUNTDOWN in 5 Mins | Unity Tutorial for Beginners 
            if(remainingTime > 0){
                remainingTime -= Time.deltaTime;
                minutes = Mathf.FloorToInt(remainingTime / 60);
                seconds = Mathf.FloorToInt(remainingTime % 60);
                timerText.text = timeText + string.Format("{0:00}:{1:00}", minutes, seconds);
            } else{ //If time remaining <= 0, switch to game over
                GameManager.instance.GameOver_Lose();
            }

            if(remainingTime <= 61){ //Switch timer colour to red if less than 1 minute left
                    timerText.color = new Color(0.8f, 0f, 0f);
            }
        }
    }
}
