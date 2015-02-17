using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed;
	bool facingRight = true;

	Animator anim;

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

		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat("Speed", Mathf.Abs(move));

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
