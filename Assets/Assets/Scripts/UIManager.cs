using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Xml.XPath;
using UnityEditor.Profiling.Memory.Experimental;
using Assets.SimpleLocalization.Scripts;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private GameObject playUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Text youWinText;
    [SerializeField] private Text youLoseText;
    [SerializeField] private Text equippedObjectText, equippedObjectTextRight, equippedObjectTextLeft, equippedObjectTextUp, equippedObjectTextDown;
    [SerializeField] private GameObject leftArrow, upArrow, rightArrow, downArrow, glassObjectImage;
    //LocalizedText spinal;
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
                youWinText.gameObject.SetActive(true);
                youLoseText.gameObject.SetActive(false);
            } else{
                youWinText.gameObject.SetActive(false);
                youLoseText.gameObject.SetActive(true);
            }
            playUI.SetActive(false);
        }
    }

    public void displayEquipped(string direction){
        displayUnequipped();
        glassObjectImage.SetActive(true);
        if(direction == "left"){
            leftArrow.SetActive(true);
            updateEquippedText("left");
        } else if(direction == "right"){
            rightArrow.SetActive(true);
            updateEquippedText("right");
        } else if(direction == "down"){
            downArrow.SetActive(true);
            updateEquippedText("down");
        } else{ //direction == "up"
            upArrow.SetActive(true);
            updateEquippedText("up");
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
        if(direction == "left")
        {
            
            equippedObjectTextLeft.gameObject.SetActive(true);
            equippedObjectTextRight.gameObject.SetActive(false);
            equippedObjectTextUp.gameObject.SetActive(false);
            equippedObjectTextDown.gameObject.SetActive(false);
            equippedObjectText.gameObject.SetActive(false);
        } else if(direction == "right"){
            equippedObjectTextLeft.gameObject.SetActive(false);
            equippedObjectTextRight.gameObject.SetActive(true);
            equippedObjectTextUp.gameObject.SetActive(false);
            equippedObjectTextDown.gameObject.SetActive(false);
            equippedObjectText.gameObject.SetActive(false);
        } else if(direction == "down"){
            equippedObjectTextLeft.gameObject.SetActive(false);
            equippedObjectTextRight.gameObject.SetActive(false);
            equippedObjectTextUp.gameObject.SetActive(false);
            equippedObjectTextDown.gameObject.SetActive(true);
            equippedObjectText.gameObject.SetActive(false);
        } else if(direction == "up"){
            equippedObjectTextLeft.gameObject.SetActive(false);
            equippedObjectTextRight.gameObject.SetActive(false);
            equippedObjectTextUp.gameObject.SetActive(true);
            equippedObjectTextDown.gameObject.SetActive(false);
            equippedObjectText.gameObject.SetActive(false);

        } else{ //direction == "none"
            equippedObjectTextLeft.gameObject.SetActive(false);
            equippedObjectTextRight.gameObject.SetActive(false);
            equippedObjectTextUp.gameObject.SetActive(false);
            equippedObjectTextDown.gameObject.SetActive(false);
            equippedObjectText.gameObject.SetActive(true);
        }
    }
}
