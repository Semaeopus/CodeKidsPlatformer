using UnityEngine;
using System.Collections;
using LuaInterface;

public class LuaCharacterController : MonoBehaviour {

	public string luaFile = "";
	private Lua lua;

	private float maxHorizontalVelocity = 1.0f;
	private Vector2 movement;

	private Vector3 startPosition;

	public bool grounded = false;
	public LayerMask groundLayers;
	public LayerMask movingPlatformLayers;
	public bool onMovingPlatform = false;
	private Vector3 lastPlatformPosition;
	private Vector3 deltaPlatformPosition;

	private Animator animator;

	#region UNITY FUNCTIONS
	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator>();
		startPosition = transform.position;
		lua = new Lua();
		lua.DoString("UnityEngine = luanet.UnityEngine");
		lua.DoString("System = luanet.System");
		lua["gameObject"] = this.gameObject;
		lua["character"] = this;
		lua.DoFile(Application.streamingAssetsPath+"/"+luaFile);
		lua.DoString("Start()");
		maxHorizontalVelocity = (float)(double)lua.GetNumber("maxSpeed");
		gameObject.GetComponent<Rigidbody2D>().mass = (float)(double)lua.GetNumber("weight");
	}
	
	// Update is called once per frame
	void Update() {

		lua.DoString(string.Format("Update({0})", Time.deltaTime));

		if (Input.GetKeyDown(KeyCode.UpArrow)){
			lua.DoString(string.Format("KeyDown(\"{0}\")", "UpArrow"));
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			lua.DoString(string.Format("KeyDown(\"{0}\")", "LeftArrow"));
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			lua.DoString(string.Format("KeyDown(\"{0}\")", "RightArrow"));
		}

		if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {
			lua.DoString(string.Format("KeyUp(\"{0}\")", "RightArrow"));
		}

		if (!GetComponentInChildren<SpriteRenderer>().isVisible) {
			transform.position = startPosition;
		}

	}

	void FixedUpdate() {

		// Check for ground:
		grounded = Physics2D.OverlapCircle(transform.position, 0.12f, groundLayers);

		// Apply movement:
		if (movement != Vector2.zero) {
			if ( ((movement.x < 0) && (gameObject.rigidbody2D.velocity.x <= -maxHorizontalVelocity)) || ((movement.x > 0) && (gameObject.rigidbody2D.velocity.x >= maxHorizontalVelocity)) ) {
				movement.x = 0;
			}
			gameObject.rigidbody2D.AddForce(new Vector2(movement.x, movement.y), ForceMode2D.Impulse);
		}
		movement = Vector2.zero;

		// Travel with moving platforms:
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.12f, movingPlatformLayers);
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
