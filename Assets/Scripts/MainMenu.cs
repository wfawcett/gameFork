using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.Lives = 3;
        GameManager.Hearts = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame()
    {

        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        print("Game Closed");
        Application.Quit();
    }
}
