using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour{
     public static AudioClip coinSound;    
     public static AudioSource audioSrc;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
         coinSound = Resources.Load<AudioClip>("Find_Money");
         audioSrc = FindObjectOfType<AudioSource>();
    }
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"){
            FindObjectOfType<GameManager>().AddCoin();
            audioSrc.PlayOneShot(coinSound);
            Destroy(this.gameObject);
        }
    }
}
