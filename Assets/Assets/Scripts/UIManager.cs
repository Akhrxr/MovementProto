using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private GameObject playUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI youWinText;
    [SerializeField] private TextMeshProUGUI youLoseText;
    [SerializeField] private TextMeshProUGUI equippedObjectText;
    [SerializeField] private GameObject leftArrow, upArrow, rightArrow, downArrow, glassObjectImage;

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
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
        downArrow.SetActive(false);
        upArrow.SetActive(false);
        glassObjectImage.SetActive(false);
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

    public void displayEquipped(string direction){
        displayUnequipped();
        glassObjectImage.SetActive(true);
        if(direction == "left"){
            leftArrow.SetActive(true);
        } else if(direction == "right"){
            rightArrow.SetActive(true);
        } else if(direction == "down"){
            downArrow.SetActive(true);
        } else{ //direction == "up"
            upArrow.SetActive(true);
        }
    }

    public void displayUnequipped(){
        glassObjectImage.SetActive(false);
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
        downArrow.SetActive(false);
        upArrow.SetActive(false);
    }

    public void updateEquippedText(string direction){
        if(direction == "left"){
            equippedObjectText.text = "Currently Equipped Object: Glass (Left)";
        } else if(direction == "right"){
            equippedObjectText.text = "Currently Equipped Object: Glass (Right)";
        } else if(direction == "down"){
            equippedObjectText.text = "Currently Equipped Object: Glass (Back)";
        } else if(direction == "up"){
            equippedObjectText.text = "Currently Equipped Object: Glass (Forward)";
        } else{ //direction == "none"
            equippedObjectText.text = "Currently Equipped Object: None";
        }
    }
}
