using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseControlScript : MonoBehaviour {

    public float maxSpeed = 8f;
    public float lastWJumpTime = 0;
    public float maxFallSpeed = 50f;
    public bool facingRight = true;
    public Rigidbody2D rb2;
    public bool grounded = false;
    public bool ducking = false;
    public bool onWall = false;
    public bool falling = false;
    public bool hasCheese = false;
    public bool running = false;
    public bool wJump = false;
    public float airMax;
    public Transform groundTrans;
    public Transform wallTrans;
    Vector2 colSize;
    Vector2 colOffset;
    public GroundChecking groundCheck;
    public WallChecking wallCheck;
    float jVelocity = 9f;
    public LayerMask isWall;
    GameObject spawn;

    Animator anim;
    // Use this for initialization
    void Start() {

        groundCheck = groundTrans.GetComponent<GroundChecking>();
        wallCheck = wallTrans.GetComponent<WallChecking>();
        anim = GetComponent<Animator>();
        rb2 = GetComponent<Rigidbody2D>();
        colSize = GetComponent<CapsuleCollider2D>().size;
        colOffset = GetComponent<CapsuleCollider2D>().offset;

        rb2.position = GameObject.Find("Spawn Area").transform.position;

    }

    // Update is called once per frame
    void FixedUpdate() {
        
        bool wasGrounded = grounded;
        grounded = groundCheck.touching;
        if (grounded && !wasGrounded)
        {
            falling = false;
            wJump = false;
        }

        onWall = wallCheck.touching;

        anim.SetBool("On Wall", onWall);
        anim.SetBool("Ground", grounded);
        anim.SetBool("Falling", falling);
        anim.SetBool("Ducking", ducking);
        anim.SetBool("Has Cheese", hasCheese);
        anim.SetFloat("vSpeed", rb2.velocity﻿.y);
        anim.SetBool("Running", running);


        float move = Input.GetAxis("Horizontal");
        float speed = 1.0f;
        Vector2 vel = rb2.velocity;

        if (hasCheese)
        {
            rb2.mass = 1.2f;
        }
        else
        {
            rb2.mass = 1f;
        }

        // Ducking and Air Mechanics
        if (ducking)
        {
            vel.x *= 0.96f;
            speed = 0f;
        }
        else
        {
            speed = 1.0f;
            vel.x *= 0.85f;
            if (!grounded)
            {
                move = wJump? 0 : move;
                vel.x += wJump? (facingRight ? 2f : -2f) : 0;
                maxSpeed = 6.0f;
                vel.x *= wJump? 1f : 0.99f;
                if (hasCheese)
                {
                    speed = 0.35f;
                }
                else
                {
                    speed = 0.45f;
                }
            }
            else
            {
                vel.x *= 0.85f;
                speed = 1.0f;
                maxSpeed = 8.0f;
            }
        }
        if (Time.time - lastWJumpTime > 0.5f)
        {
            wJump = false;
        }

        if (vel.y < -maxFallSpeed)
        {
            vel.y = -maxFallSpeed;
        }
        // Horizontal Movement
        if (Input.GetButton("Horizontal"))
        {
            running = true;
        }
        else
        {
            running = false;
            vel.x *= 0.7f;
        }

       
        // Positive
        if (vel.x + speed * move > maxSpeed)
        {
            vel.x = maxSpeed;
        }
        else
        {
            vel.x += speed * move;
        }
        // Negative
        if (vel.x + speed * move < -maxSpeed)
        {
            vel.x = -maxSpeed;
        }
        else
        {
            vel.x += speed * move;
        }

        rb2.velocity = vel;

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {

            Flip();
        }


    }

    public void Update()
    {
        anim.SetFloat("Max Air Speed", airMax);
        Vector2 vel = rb2.velocity;
        if (airMax > rb2.velocity.y)
        {
            airMax = rb2.velocity.y;
        }

        if (!falling && Input.GetButtonDown("Jump"))
        {
            falling = true;
            if (ducking)
            {
                rb2.velocity = new Vector2(vel.x, jVelocity * 1.3f);
            }
            else
            {
                rb2.velocity = new Vector2(vel.x, jVelocity);
            }
            
            airMax = 0;
        }

        // Ducking
        if (grounded && Input.GetButton("Duck"))
        {
            ducking = true;
            GetComponent<CapsuleCollider2D>().size = new Vector2(colSize.x, colSize.y * 0.8f);
            GetComponent<CapsuleCollider2D>().offset = new Vector2(colOffset.x, colOffset.y * 0.96f);
        }
        else
        {
            ducking = false;
            GetComponent<CapsuleCollider2D>().size = colSize;
            GetComponent<CapsuleCollider2D>().offset = colOffset;
        }
        // Quit Game
        if (Input.GetButtonDown("Quit"))
        {
            Application.Quit();
        }
    }
    
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
