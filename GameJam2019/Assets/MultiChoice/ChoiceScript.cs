using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChoiceScript : MonoBehaviour
{
    public GameTimer gameTimer;
    public PlayerController playerController;

    public GameObject interactableCanvas;
    public GameObject TextBox;
    public GameObject choicePanel1;
    private int eventResult1; // 1 = paid for parking , 2 = didnt pay
    private int eventResult2; // 1 = Got map, 2 = didnt get map

    public void ChoiceOption1 ()
    {
        TextBox.SetActive(true);
        TextBox.GetComponent<Text>().text = "Time is money. You lose 20 seconds.";
        eventResult1 = 1;
    }
    public void ChoiceOption2()
    {
        TextBox.SetActive(true);
        TextBox.GetComponent<Text>().text = "Ok, then cheap ass";
        eventResult1 = 2;
    }
    public void ChoiceOption3()
    {
        TextBox.SetActive(true);
        TextBox.GetComponent<Text>().text = "A map will help a lot on such a big campus. +30 seconds.";
        eventResult2 = 1;
    }
    public void ChoiceOption4()
    {
        TextBox.SetActive(true);
        TextBox.GetComponent<Text>().text = "Yikers! You're definitely going to get lost. -30 seconds.";
        eventResult2 = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (eventResult1 >= 1)
        {
            choicePanel1.SetActive(false);
            playerController.enabled = true;
        }
        if(eventResult1 == 1)
        {
            gameTimer.removeTime(20f);
            eventResult1 = 0;
        }
        if(eventResult1 == 2)
        {
            // SPAWN COP AND MAKE HIM MAKE U PAY

            eventResult1 = 0;
        }



        if(eventResult2 >= 1)
        {
            choicePanel1.SetActive(false);
            playerController.enabled = true;
        }
        if(eventResult2 == 1)
        {
            gameTimer.addTime(30f);
            eventResult2 = 0;
        }
        if(eventResult2 == 2)
        {
            gameTimer.removeTime(30f);
            eventResult2 = 0;
        }
    }


}
