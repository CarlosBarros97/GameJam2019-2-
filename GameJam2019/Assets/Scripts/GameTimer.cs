using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{

    public Text timerText;
    private float startTime = 150f;
    private float currentTime;

    private void Start()
    {
        currentTime = startTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        string minutes = ((int)currentTime / 60).ToString();
        string seconds = (currentTime % 60).ToString("f0");

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


    // ADD METHOD THAT CHANGES COLOR OF TIMER TEXT WHEN LOW ON TIME


}
