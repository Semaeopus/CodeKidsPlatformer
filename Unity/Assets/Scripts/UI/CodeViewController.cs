using UnityEngine;
using System.Collections;
using System.IO;

public class CodeViewController : MonoBehaviour {

	public UIController uiControl;
	public GameObject target;
	
	public UnityEngine.UI.InputField codeView;
	public UnityEngine.UI.Text objectNameText;

	public void DisplayLuaCode(string code, string objectName) {
		Debug.Log ("DisplayLuaCode");
		objectNameText.text = objectName;
		codeView.text = code;
	}

	public void OpenObjectCode(GameObject targetObject) {
		target = targetObject;
		LuaController controller = target.GetComponent<LuaController> ();
		string code = "";
		if (string.IsNullOrEmpty(controller.customLua)) {
			code = File.ReadAllText(Application.streamingAssetsPath+"/"+controller.luaFile);
		}
		else {
			code = controller.customLua;
		}
		DisplayLuaCode (code, target.name);
	}

	public void OpenCharacterScript(GameObject character) {
		Debug.Log ("DisplayCharacterCode");
		target = character;
		LuaCharacterController controller = target.GetComponent<LuaCharacterController> ();
		string code = "";
		if (string.IsNullOrEmpty(controller.customLua)) {
			code = File.ReadAllText(Application.streamingAssetsPath+"/"+controller.luaFile);
		}
		else {
			code = controller.customLua;
		}
		DisplayLuaCode (code, target.name);
	}

	public void CommitNewLua() {
		LuaController controller = target.GetComponent<LuaController> ();
		controller.RunNewLua (codeView.text);
		uiControl.ToggleCodeView (false);
	}
		
}
