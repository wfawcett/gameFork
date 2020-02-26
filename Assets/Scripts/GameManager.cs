
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
    public Text heartsText { get; set; }

    public Text coinsText { get; set; }

    public float restartDelay = 1f;
    public float invincibleTime = 2f;

    private string heartCharacter;

    public static int coins = 0;
    public static int coinsLevel1 = 0;

    public void takeDamage(int damage)//decreaseHearts
    {
        if (!tedIsInvincible)
        {
            tedIsInvincible = true;
            Hearts -= damage;
            printHearts();
            Invoke("resetInvolnerability", invincibleTime);
        }

        if (Hearts <= 0)
        {
            LoseSingleLife();
        }
    }

    public void AddCoin(){
        coins++;
        coinsText.text = "coins: " + coins;
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
            livesText.text = "lives: " + Lives;            
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
        if (Lives <= 0)
        {
            Lives = 3;
            Hearts = 3;
            SceneManager.LoadScene("Menu");
        }
    }

    public void Start()
    {   
        //all the text objects are in the canvas in unity
        livesText = GameObject.Find("LivesText").GetComponent<Text>();//found by the name of the object
        heartsText = GameObject.Find("HeartsText").GetComponent<Text>();//find the hearts text
        coinsText = GameObject.Find("CoinsText").GetComponent<Text>();//find the hearts text
        //u2665
        heartCharacter = "♥";//thats a heart in unicode

        printHearts();        
        
        livesText.text = "Lives: " + Lives;
        coinsText.text = "Coins: " + coins;
        tedPlayer = GameObject.FindGameObjectsWithTag("Player")[0];
        anim = tedPlayer.GetComponent<Animator>();
    }

    private void printHearts()
    {
        heartsText.text = "";
        for (int i = 0; i < Hearts; i++)
        {            
            heartsText.text += heartCharacter;
        }
    }

    private void RestartLevel()
    {
        Hearts = 3;
        //Uncheck auto lighting when we have lighting in order for the restart to not look wierd. Refer Brackeys "Game Over" video 9:43
        //SceneManager.LoadScene("SampleScene"); //This is how we change to different scenes
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //SceneManager.GetActiveScene().name returns string name of scene
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            coins = 0;
            ScoreScript.scoreValue = 0;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            coins = GameManager.coinsLevel1;
            ScoreScript.scoreValue = ScoreScript.scoreValueLevel1;
        }
    }
}
