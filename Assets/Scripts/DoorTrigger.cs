using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator anim;
    public GameObject Player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Moves player to level 2 scene
        if (other.gameObject.tag == "Player")
        {
            soundManager.PlaySound("doorOpen");
            anim.SetBool("Door", true);
        }
    }
        public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            soundManager.PlaySound("doorOpen");
            anim.SetBool("Door", false);
        }
    }
}
