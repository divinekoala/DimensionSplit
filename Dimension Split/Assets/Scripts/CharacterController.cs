﻿using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public float maxSpeed = 10f;
	public bool facingRight = true;

	Animator anim;
	Rigidbody2D r;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public float jumpForce = 700f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		r = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("ground", grounded);

		float move = Input.GetAxis("Horizontal");

		anim.SetFloat("speed", Mathf.Abs(move));

		r.velocity = new Vector2(move * maxSpeed, r.velocity.y);

		if (move > 0 && !facingRight)
			Flip();
		else if (move< 0 && facingRight)
			Flip();
	}

	public void Update() {

		if (grounded && Input.GetAxisRaw("Jump") == 1){
			anim.SetBool("ground", false);
			r.AddForce(new Vector2(0, jumpForce));
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
