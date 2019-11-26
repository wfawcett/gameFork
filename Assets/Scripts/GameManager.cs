
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public bool tedIsInvincible = false;
    GameObject tedPlayer;
    private Animator anim;

    public static int Lives { get; set; }
    public static int Hearts { get; set; }

    public Text livesText { get; set; }

    public float restartDelay = 1f;
    public float invincibleTime = 2f;

    public void takeDamage(int damage)//decreaseHearts
    {
        if (!tedIsInvincible)
        {
            //print("Ted is Invincible");
            tedIsInvincible = true;
            Hearts -= damage;
            //print("Hearts: " + Hearts);//replace with hud call
            Invoke("resetInvolnerability", invincibleTime);
        }

        if (Hearts <= 0)
        {
            LoseSingleLife();
        }
    }

    public void LoseSingleLife()
    {
        LoseSingleLife(restartDelay);
    }

    public void LoseSingleLife(float restartDelay)
    {
        if (!gameHasEnded)
        {
            Lives--;
            livesText.text = "Lives: " + Lives;
            anim.SetTrigger("die");
            gameHasEnded = true;
            Invoke("RestartLevel", restartDelay);
        }
    }

    private void resetInvolnerability()
    {
        tedIsInvincible = false;
    }

    public void Awake()
    {
        ResetGame();
    }

    private void ResetGame()
    {
        print("Lives: " + Lives);
        if (Lives <=0)
        {
            Lives = 3;
            Hearts = 3;
            SceneManager.LoadScene("Menu");
            //print("Hearts: " + Hearts);
        }
    }

    public void Start()
    {        
        livesText = GameObject.Find("LivesText").GetComponent<Text>();//found by the name of the object
        livesText.text = "Lives: " + Lives;
        tedPlayer = GameObject.FindGameObjectsWithTag("Player")[0];
        anim = tedPlayer.GetComponent<Animator>();
    }



    private void RestartLevel()
    {
        Hearts = 3;
        //Uncheck auto lighting when we have lighting in order for the restart to not look wierd. Refer Brackeys "Game Over" video 9:43
        //SceneManager.LoadScene("SampleScene"); //This is how we change to different scenes
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //SceneManager.GetActiveScene().name returns string name of scene
    }
}




















//all the garbage code I am too sad to throw away

//Text[] elements = GameObject.FindObjectsOfType<Text>();
//foreach (var textElement in elements)
//{
//    if (textElement.tag.Equals("LivesText"))
//    {
//        livesText = textElement;
//    }
//}