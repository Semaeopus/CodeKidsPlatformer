using UnityEngine;
using System.Collections;
using LuaInterface;

public class LuaCharacterController : LuaController {

	private float maxHorizontalVelocity = 1.0f;
	private Vector2 movement;

	private Vector3 startPosition;

	public bool grounded = false;
	private float groundCheckRadius = 0.5f;
	public LayerMask groundLayers;
	public LayerMask movingPlatformLayers;
	public bool onMovingPlatform = false;
	private Vector3 lastPlatformPosition;
	private Vector3 deltaPlatformPosition;

	private Animator animator;

	#region UNITY FUNCTIONS

	// This will run automatically in Start():
	public override void Init() {
		animator = GetComponentInChildren<Animator>();
		groundCheckRadius = GetComponent<CircleCollider2D> ().radius;
		startPosition = transform.position;
		lua["character"] = this;
		maxHorizontalVelocity = (float)(double)lua.GetNumber("maxSpeed");
		gameObject.GetComponent<Rigidbody2D>().gravityScale = (float)(double)lua.GetNumber("weight");
	}

	public override void Reset() {
		// Reset object to start position & settings.
	}
	
	// Update is called once per frame
	void Update() {
		if (!paused) {
			lua.DoString (string.Format ("Update({0})", Time.deltaTime));

			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				lua.DoString (string.Format ("KeyDown(\"{0}\")", "UpArrow"));
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				lua.DoString (string.Format ("KeyDown(\"{0}\")", "LeftArrow"));
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				lua.DoString (string.Format ("KeyDown(\"{0}\")", "RightArrow"));
			}

			if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
				lua.DoString (string.Format ("KeyUp(\"{0}\")", "RightArrow"));
			}

			if (!GetComponentInChildren<SpriteRenderer> ().isVisible) {
				transform.position = startPosition;
			}
		}

	}

	void FixedUpdate() {

		// Check for ground:
		grounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayers);

		// Apply movement:
		if (movement != Vector2.zero) {
			if ( ((movement.x < 0) && (gameObject.rigidbody2D.velocity.x <= -maxHorizontalVelocity)) || ((movement.x > 0) && (gameObject.rigidbody2D.velocity.x >= maxHorizontalVelocity)) ) {
				movement.x = 0;
			}
			gameObject.rigidbody2D.AddForce(new Vector2(movement.x, movement.y), ForceMode2D.Impulse);
		}
		movement = Vector2.zero;

		// Travel with moving platforms:
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, groundCheckRadius, movingPlatformLayers);
		if (colliders.Length > 0) {
			if (onMovingPlatform) {
				deltaPlatformPosition = colliders[0].transform.position - lastPlatformPosition;
				float friction = colliders[0].sharedMaterial.friction;
				gameObject.transform.position += new Vector3(deltaPlatformPosition.x * friction, 0f, 0f);
			}
			lastPlatformPosition = colliders[0].transform.position;
			onMovingPlatform = true;

		}
		else {
			onMovingPlatform = false;
		}
	}
	#endregion

	#region LUA INTERFACE
	private void AddForce(float x, float y) {
		movement = new Vector2(x,y);
	}

	private void SetAnimation(string state) {
		switch (state) {
		case "Idle":
			animator.SetTrigger("Idle");
			break;
		case "Run":
			animator.SetTrigger("Run");
			break;
		case "Jump":
			animator.SetTrigger("Jump");
			break;
		}
	}

	#endregion





}
