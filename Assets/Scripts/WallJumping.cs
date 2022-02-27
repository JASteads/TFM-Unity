using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumping : MonoBehaviour {

    MouseControlScript main;

	// Use this for initialization
	void Start () {
        main = GetComponent<MouseControlScript>();
	}

    // Update is called once per frame
    

    void FixedUpdate () {

        Vector2 vel = main.rb2.velocity;

        if (main.onWall && !main.grounded && Input.GetButtonDown("Jump"))
        {
            main.lastWJumpTime = Time.time;
            main.wJump = true;
            main.falling = true;
            vel.x = main.facingRight ? -15f : 15f;
            vel.y = 10.2f;
            main.rb2.velocity = vel;
            main.Flip();
        }

	}
}
