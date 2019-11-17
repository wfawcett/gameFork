
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    GameObject tedPlayer;
    private Animator anim;

    public float restartDelay = 1f;

    public void Start()
    {
        tedPlayer = GameObject.FindGameObjectsWithTag("Player")[0];
        anim = tedPlayer.GetComponent<Animator>();
    }

    public void EndGame() {
        this.EndGame(restartDelay);
    }

    public void EndGame(float delay)
    {
        if(gameHasEnded == false)
        {
            anim.SetTrigger("die");
            gameHasEnded = true;
            print("Game Over");
            Invoke("Restart", delay);
        }
    }

    private void Restart()
    {
        //Uncheck auto lighting when we have lighting in order for the restart to not look wierd. Refer Brackeys "Game Over" video 9:43

        //SceneManager.LoadScene("SampleScene"); //This is how we change to different scenes
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //SceneManager.GetActiveScene().name returns string name of scene
    }
}
