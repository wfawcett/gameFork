
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            print("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    private void Restart()
    {
        //Uncheck auto lighting when we have lighting in order for the restart to not look wierd. Refer Brackeys "Game Over" video 9:43

        //SceneManager.LoadScene("SampleScene"); //This is how we change to different scenes
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //SceneManager.GetActiveScene().name returns string name of scene
    }
}
