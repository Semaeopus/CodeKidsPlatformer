using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Vector3 velocity = Vector3.zero;
	public Vector3 gravity;
	public Vector3 moveLeftVel;
	public Vector3 moveRightVel;
	public Vector3 jumpHeight;
	public float maxSpeed;

	bool moveLeft = false;
	bool moveRight = false;
	bool jump = false;
	
	// Use this for initialization
	void Start () {
	
	}

	// Do Input and Graphics updates here
	void Update(){
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			moveLeft = true;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			moveRight = true;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			jump = true;
		}
	}

	
	// Do physics engine updates here
	void FixedUpdate () {

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



	
	}
}
