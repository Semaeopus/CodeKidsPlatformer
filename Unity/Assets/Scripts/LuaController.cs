using UnityEngine;
using System.Collections;
using LuaInterface;

/*
	Base class for all objects that run Lua scripts
	Handles exposing the script to UI and initilaizes the Lua machine
*/

public abstract class LuaController : MonoBehaviour {

	public string luaFile = "";
	[HideInInspector]
	public string customLua = string.Empty;
	public Lua lua;

	private CodeViewController codeView;
	private UIController uiControl;


	public void Start() {
		uiControl = FindObjectOfType<UIController> ();
		codeView = uiControl.codeView;
		lua = new Lua();
		lua.DoString("UnityEngine = luanet.UnityEngine");
		lua.DoString("System = luanet.System");
		lua["gameObject"] = this.gameObject;
		lua.DoFile(Application.streamingAssetsPath+"/"+luaFile);
		Init ();
	}

	public void OnMouseEnter() {
		Debug.Log("Mouse over editable item");
	}

	public void OnMouseExit() {
		Debug.Log("Mouse left editable item");
	}

	public void OnMouseDown() {
		uiControl.ToggleCodeView (true);
		codeView.OpenObjectCode (gameObject);
	}

	public virtual void RunNewLua(string code) {
		customLua = code;
		lua.DoString(customLua);
		Init ();
	}

	public abstract void Init();
}
