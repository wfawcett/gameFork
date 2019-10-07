using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{

    public Rigidbody2D Ted;
    
    public float walkSpeed = 5;
    public float runSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        Ted = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
        //This gets the keys assigned to the Horizontal axis in the editor(a or d or the arrow keys)
        //and uses it to calculate a force to be applied to the ted object
        //TODO: get Teds current speed and determine if the sprite needs to turn around
        //tweak the variables so it feels natural
        Ted.AddForce(new Vector2(Input.GetAxis("Horizontal") * walkSpeed, 0), ForceMode2D.Impulse);

        //jump mechanics...
        
        print(Ted.velocity);
        //need to check that Ted is on the ground...
        if (Input.GetKey("space") && Ted.velocity.y == 0)
        {
            Ted.AddForce(new Vector2(0, 50), ForceMode2D.Impulse);
        }
        

    }
}
