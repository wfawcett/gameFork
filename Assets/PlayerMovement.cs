﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;

    private Animator anim;



    // Start is called before the first frame update
    private void Start(){
        anim = GetComponent<Animator>();
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
    }
}
