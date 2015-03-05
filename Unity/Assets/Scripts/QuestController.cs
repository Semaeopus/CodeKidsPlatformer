using UnityEngine;
using System.Collections;
using LuaInterface;

public class QuestController : MonoBehaviour {


	public string luaFile = "";
	public Lua lua;

	private UIController uiControl;
	private GameController gameControl;

	// Use this for initialization
	void Start () {
		uiControl = FindObjectOfType<UIController> ();
		gameControl = FindObjectOfType<GameController> ();
		lua = new Lua();
		lua.DoString("UnityEngine = luanet.UnityEngine");
		lua.DoString("System = luanet.System");
		lua["questControl"] = this.gameObject;
		lua.DoFile(Application.streamingAssetsPath+"/"+luaFile);
		lua.DoString ("Start()");
	}

	public string GetNextHint() {
		lua.DoString ("GetQuestHint()");
		string nextHint = (string)lua.GetString ("hint");
		return nextHint;
	}

	public void CompleteCurrentQuest() {
		lua.DoString ("CompleteQuest()");
	}
	

}
