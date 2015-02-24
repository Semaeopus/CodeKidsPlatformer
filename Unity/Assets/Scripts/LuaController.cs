using UnityEngine;
using System.Collections;
using LuaInterface;

public virtual class LuaController : MonoBehaviour {


	public string luaFile = "";
	public string customLua = string.Empty;
	private Lua lua;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RunNewLua(string code) {
		customLua = code;
		lua.DoString(code);
	}


}
