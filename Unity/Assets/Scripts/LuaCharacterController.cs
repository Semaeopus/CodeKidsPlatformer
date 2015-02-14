using UnityEngine;
using System.Collections;
using LuaInterface;

public class LuaCharacterController : MonoBehaviour {


	public string luaFile = "";
	private Lua lua;

	// Use this for initialization
	void Start () {
		lua = new Lua();
		lua.DoString("UnityEngine = luanet.UnityEngine");
		lua.DoString("System = luanet.System");
		lua["gameObject"] = this.gameObject;
		lua["character"] = this;
		lua.DoFile(Application.streamingAssetsPath+"/"+luaFile);
		lua.DoString("Start()");
	}
	
	// Update is called once per frame
	void Update(){
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			lua.DoString(string.Format("KeyDown(\"{0}\")", "LeftArrow"));
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			lua.DoString(string.Format("KeyDown(\"{0}\")", "RightArrow"));
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			lua.DoString(string.Format("KeyDown(\"{0}\")", "UpArrow"));
		}
	}

	public void AddForce(float x, float y) {
		gameObject.rigidbody2D.AddForce(new Vector2(x,y), ForceMode2D.Impulse);
	}

}
