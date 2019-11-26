using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour{
    public LayerMask enemyMask;
    public LayerMask playerMask;
    public float speed = 1;
    public float lookAhead = 0.5f;
    public bool avoidFalling = true;
    Rigidbody2D myBody;
    Transform myTransform;
    float myWidth, myHeight; 
    bool wasFalling = true; // assume I am falling as I am put on the board above the ground most of the time. 
    private Animator anim;
    private bool isDieing = false;

    // Start is called before the first frame update
    void Start()    {
        anim = this.GetComponentInChildren<Animator>();
        myTransform = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponentInChildren<SpriteRenderer>().bounds.extents.x;
        myHeight = this.GetComponentInChildren<SpriteRenderer>().bounds.extents.y;        
    }

    private void FixedUpdate(){        
        // set a position relative to me where my line casts should start
        Vector2 myVec2Position = myTransform.position.toVector2();
        Vector2 lineCastPos = myVec2Position - myTransform.right.toVector2() * myWidth + Vector2.up * myHeight;
        
        // determine if something is in front of me
        Debug.DrawLine(lineCastPos, lineCastPos - myTransform.right.toVector2() * lookAhead);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTransform.right.toVector2() * lookAhead, enemyMask);
        
        // determine if I am about to fall off an edge. 
        bool GroundInFrontOfMe = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down *2, enemyMask);   
        
        
        
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        
        
        
        
                
        // determine if I am touching the player
        Collider2D[] colliders = Physics2D.OverlapCircleAll(myVec2Position, 0.75f, playerMask);
        bool touchingPlayer = colliders.Length > 0;

        // If touching the player, end the game (we can update this later with decrement health if we want.)
        if (touchingPlayer && !isDieing) {
           
            FindObjectOfType<GameManager>().takeDamage(1);
        }

        // if he is blocked he will aways turn, he will turn on an edge if avoidFalling is true
        if ((!GroundInFrontOfMe && avoidFalling ) || isBlocked)
        {
            Vector3 currentRotation = myTransform.eulerAngles;
            currentRotation.y += 180;
            myTransform.eulerAngles = currentRotation;            
        }     
        
        Vector2 myVel = myBody.velocity;
        myVel.x = -myTransform.right.x * speed;
        myBody.velocity = myVel;
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other){
       if(other.tag == "Player"){
           isDieing = true;
           anim.SetTrigger("die");
           other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 2000f));           
           Destroy(this.gameObject, .3f);
        }  
    }

   
    // Update is called once per frame
    void Update()    {
        
    }
}
