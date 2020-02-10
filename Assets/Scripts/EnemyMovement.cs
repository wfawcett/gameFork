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
    private Animator anim;
    private bool isDying = false;

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
       
        // if he is blocked he will aways turn, he will turn on an edge if avoidFalling is true
        if (EnemyMovementLogic.shouldTurnHappen(GroundInFrontOfMe, avoidFalling, isBlocked)){
            Vector3 currentRotation = myTransform.eulerAngles;
            currentRotation.y += 180;
            myTransform.eulerAngles = currentRotation;            
        }     
        
        Vector2 myVel = myBody.velocity;
        myVel.x = -myTransform.right.x * speed;
        myBody.velocity = myVel;
    }

    /// <summary>
    /// TriggerEnter is used to determine if Ted is stomping the enemy.
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other){
        if(EnemyMovementLogic.shouldStompHappen(this.tag, other.tag)){
            isDying = true;
            anim.SetTrigger("die");
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 2000f)); 
            other.GetComponent<Animator>().SetTrigger("jump");           
            soundManager.PlaySound("stomp");          
            Destroy(this.gameObject, .3f);
            ScoreScript.scoreValue += 5;
        }       
    }

    /// <summary>
    /// CollisionEnter is used to determine if the Enemy is Hurting Ted
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other){
        if(EnemyMovementLogic.shouldDamageHappen(this.tag, other.gameObject.tag, isDying)){
             FindObjectOfType<GameManager>().takeDamage(1);
            soundManager.PlaySound("ouch");
            other.gameObject.GetComponent<Animator>().SetTrigger("ouch");
        }        
    }

    public void ShotWithLaser() //can pass player, if needed
    {
        
        isDying = true;  
        anim.SetTrigger("die");
        soundManager.PlaySound("stomp");
        Destroy(this.gameObject, .3f);
        ScoreScript.scoreValue += 5;
    }
}
