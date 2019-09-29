using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{

    public Text timerText;
    private float startTime = 132f;
    private float currentTime;

    private void Start()
    {
        currentTime = startTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        string minutes = ((int)currentTime / 60).ToString();
        string seconds;
        if((currentTime % 60 < 9.5))
        {
            seconds = "0" + (currentTime % 60).ToString("f0");
        }
        else
        {
            seconds = (currentTime % 60).ToString("f0");
        }

        timerText.text = minutes + ":" + seconds;

        if (currentTime <= 0)
        {
            currentTime = 0;

            // Load game over UI
        }
    }

    // Instantiate game over UI
    public void GameOver()
    {
    }

    // Allow other classes to remove time from the timer
    public void removeTime(float timeRemoved)
    {
        currentTime -= timeRemoved;
    }

    public void addTime(float timeAdded)
    {
        currentTime += timeAdded;
    }


    // ADD METHOD THAT CHANGES COLOR OF TIMER TEXT WHEN LOW ON TIME


}
