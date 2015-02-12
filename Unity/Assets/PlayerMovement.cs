using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Vector3 velocity = Vector3.zero;
	public Vector3 gravity;
	public Vector3 moveLeftVel;
	public float maxSpeed;

	bool moveLeft = false;
	
	// Use this for initialization
	void Start () {
	
	}

	// Do Input and Graphics updates here
	void Update(){
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			moveLeft = true;
		}
	}

	
	// Do physics engine updates here
	void FixedUpdate () {

		velocity += gravity * Time.deltaTime;

		if(moveLeft == true){
			moveLeft = false;
			velocity += moveLeftVel;
		}

		velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

		transform.position += velocity * Time.deltaTime;



	
	}
}
