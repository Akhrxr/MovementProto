using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private GameObject playUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI youWinText;
    [SerializeField] private TextMeshProUGUI youLoseText;

    void Awake(){
        if(instance == null){
            instance = this;
        } else{
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGameOverStatus() == true){ //Activate GameOver UI if time runs out
            gameOverUI.SetActive(true);
            if(GameManager.instance.playerWinStatus() == true){
                youWinText.enabled = true;
                youLoseText.enabled = false;
            } else{
                youWinText.enabled = false;
                youLoseText.enabled = true;
            }
            playUI.SetActive(false);
        }
    }
}
