using UnityEngine;
using System.Collections;

public class EnterPipe : LuaController {

    public int nextLevel = 1;


	public override void Init() {
		lua["pipe"] = this;
	}

	public override void Reset() {
	
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        //TODO stop character controller
        //TODO animate player going down pipe
        //TODO play pipe sound

        // wait .. seconds and load level
        Debug.Log("loading next level");

        //Invoke("LoadNextLevel", 1);
		lua.DoString("PlayerEnterPipe()");
       

    }

    void LoadNextLevel() { Application.LoadLevel(nextLevel); }
}
