using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    public float fallOffScreenHeight = -20f;

    float horizontalMove = 0f;

    bool jump = false;

    public static Rigidbody2D Ted; 
    
    private Animator anim;



    // Start is called before the first frame update
    private void Start(){
        anim = this.GetComponent<Animator>();
    }

    void Awake()
    {
        Ted = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        bool isMoving = horizontalMove != 0;
        anim.SetBool("isRunning", isMoving);
        if (Input.GetButtonDown("Jump")) {
            jump = true;
            anim.SetTrigger("jump");
        }
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

        IfTedFallsHeDies(FindObjectOfType<GameManager>());
    }

    public void IfTedFallsHeDies(GameManager gameManager)
    {
        if (Ted.position.y < fallOffScreenHeight)
        {
            gameManager.takeDamage(100);
        }
    }
}
