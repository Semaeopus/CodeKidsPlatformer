using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed;
	bool facingRight = true;

	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public float jumpForce = 100f;

	bool doubleJumpUsed = false;

	public Vector3 velocity = Vector3.zero;
	public Vector3 gravity;
	public Vector3 moveLeftVel;
	public Vector3 moveRightVel;
	public Vector3 jumpHeight;


	bool moveLeft = false;
	bool moveRight = false;
	bool jump = false;
	
	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator>();

	}

	// Do Input and Graphics updates here
	void Update()
	{
		if((grounded || !doubleJumpUsed) && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Grounded", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));

			if (!doubleJumpUsed && !grounded)
			{ doubleJumpUsed = true; }
		}
		/*
		 * Old movement code
		 *

				if (Input.GetKeyDown(KeyCode.LeftArrow)){
					moveLeft = true;
				}
				if (Input.GetKeyDown(KeyCode.RightArrow)){
					moveRight = true;
				}
				if (Input.GetKeyDown(KeyCode.UpArrow)){
					jump = true;
				}

		*/

	}

	
	// Do physics engine updates here
	void FixedUpdate () 
	{
		// if result is true we are on ground, if not we are not on ground
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		// set the animator parameter 'Grounded' to match bool grounded above)
		anim.SetBool("Grounded", grounded);

		if(grounded){doubleJumpUsed = false;}

		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);

		// Check horizontal axis input and save to float 'move'
		float move = Input.GetAxis ("Horizontal");
		// set the animator parameter 'Speed' to match float 'move' above)
		anim.SetFloat("Speed", Mathf.Abs(move));

		// make the rigid body's velocity match move and cap it at MaxSpeed, and set the y axis to stay at the current position
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		if (move > 0 && !facingRight)
		{
			Flip();
		}
		else if (move < 0 && facingRight)
		{
			Flip();
		}

/*
 * Old movement code
 * 

		velocity += gravity * Time.deltaTime;

		if(moveLeft == true){
			moveLeft = false;
			velocity += moveLeftVel;
		}

		if(moveRight == true){
			moveLeft = false;
			velocity += moveRightVel;
		}

		if(moveRight == true){
			moveLeft = false;
			velocity += jumpHeight;
			audio.Play();
		}

		velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

		transform.position += velocity * Time.deltaTime;

*/



	
	}

	void Flip (){

		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}
}
