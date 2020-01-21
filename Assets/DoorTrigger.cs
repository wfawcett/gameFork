using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetBool("Door", true);
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Door", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Door", false);
        }
    }
}
