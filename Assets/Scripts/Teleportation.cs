using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour
{
    public GameObject Portal;
    public GameObject Player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Moves player to level 2 scene
        if (other.gameObject.tag == "Player" && Portal.gameObject.tag == "Level1_Door")
        {
            StartCoroutine(Teleport_Level());
        }

        //Moves player to level 3 scene
        if (other.gameObject.tag == "Player" && Portal.gameObject.tag == "Level2_Door")
        {
            StartCoroutine(Teleport_Level());
        }

        //Moves player to GameOver scene
        if (other.gameObject.tag == "Player" && Portal.gameObject.tag == "ShadowTed")
        {
            StartCoroutine(Teleport_Level());
        }

        //Teleports the player to the door within the level.
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Teleport());
        }

    }

    private IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);
        Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
    }

    private IEnumerator Teleport_Level()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.coinsLevel1 = GameManager.coins;
        ScoreScript.scoreValueLevel1 = ScoreScript.scoreValue;
    }
}
