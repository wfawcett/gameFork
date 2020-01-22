using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
            Debug.Log(PlayerMovement.Ted.velocity.y);
        if(col.gameObject.tag.Equals("Ground") && PlayerMovement.Ted.velocity.y < -26)
        {
            FindObjectOfType<GameManager>().takeDamage(1);
            soundManager.PlaySound("ouch");
        }
    }
}
