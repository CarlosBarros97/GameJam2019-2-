using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{

    // Name of scene to load for beginning of game
    private string sceneToLoad = "GameScene1";

    // Start the game on button press
    public void startGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}