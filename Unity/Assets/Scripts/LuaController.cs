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

	public bool paused = false;	

	public void OnEnable() {
		GameController.PauseGame += PauseGame;
		GameController.UnPauseGame += UnPauseGame;
	}

	public void OnDisable() {
		GameController.PauseGame -= PauseGame;
		GameController.UnPauseGame -= UnPauseGame;
	}

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
		GameObject.FindObjectOfType<MouseCursor> ().SetCursor (MouseCursor.CursorModes.Edit);
	}

	public void OnMouseExit() {
		Debug.Log("Mouse left editable item");
		GameObject.FindObjectOfType<MouseCursor> ().SetCursor (MouseCursor.CursorModes.Normal);
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

	public abstract void Reset();

	public void PauseGame() {
		paused = true;
	}
	public void UnPauseGame() {
		paused = false;
	}
}
