using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

// PLAY GAME
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");

    }
// QUIT GAME
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
// LEVELS
    public void GoToLevel(int level)
    {
        SceneManager.LoadScene("Level " + level);
    }
}
