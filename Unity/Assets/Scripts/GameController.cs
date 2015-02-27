using UnityEngine;
using System.Collections;

public class GameController : LuaController {

	public override void Init () {
		lua["world"] = this;
		lua.DoString ("Start()");
	}

	public override void Reset() {
	}

	public void RestartLevel() {
		Debug.Log ("Reload level");
		Application.LoadLevel(Application.loadedLevelName);
	}

	public void SetGravity(float gravity) {
		Debug.Log ("Changed global gravity to " + gravity);
		Physics2D.gravity = new Vector2 (0f, -gravity);
	}

}
