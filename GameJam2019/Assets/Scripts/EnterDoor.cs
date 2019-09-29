using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{
    int doorId = 0;
    bool inRange = false;
    void Start()
    {
        if(this.gameObject.name == "door")
        {
            doorId = 1;
        }
        if(this.gameObject.name == "door (1)")
        {
            doorId = 2;
        }
        if(this.gameObject.name == "door (2)")
        {
            doorId = 3;
        }
    }


    private void Update()
    {
        if(inRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(doorId == 1)
                {
                    // GAME LOSS
                    Debug.Log("GAME LOST");
                    SceneManager.LoadScene("GameOver");
                }
                else if(doorId == 2)
                {
                    // GAME LOSS
                    Debug.Log("GAME LOST");
                    SceneManager.LoadScene("GameOver");
                }
                else if(doorId == 3)
                {
                    // GAME WIN
                    Debug.Log("GAME WON");
                    SceneManager.LoadScene("YouWin");
                }
            }
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }
}
