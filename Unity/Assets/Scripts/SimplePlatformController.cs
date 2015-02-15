using UnityEngine;
using System.Collections;
using LuaInterface;

public class SimplePlatformController : MonoBehaviour {

	public bool movePlatform = true;
	public float moveSpeed = 1.0f;
	public float moveDistance = 1.0f;
	public float waitLength = 2.0f;

	private Vector2 nextPosition;
	private bool atTarget = true;

	public string luaFile = "";
	private Lua lua;
	private LuaTable luaInstructions;

	void Start () {
		lua = new Lua();
		lua.DoFile(Application.streamingAssetsPath+"/"+luaFile);
		InitOptionsFromLua();
		luaInstructions = lua.GetTable("instructions");
		nextPosition = transform.position;
		StartCoroutine("MovePlatform");

	}
	
	void Update () {
		if ((Vector2)transform.position == nextPosition) {
			atTarget = true;
		}
		else {
			transform.position = Vector3.MoveTowards(transform.position, nextPosition, Time.deltaTime * moveSpeed);
		}
	}

	private void InitOptionsFromLua() {
		LuaTable luaOptions = lua.GetTable("options");
		moveSpeed = (float)(double)luaOptions["moveSpeed"];
		moveDistance = (float)(double)luaOptions["moveDistance"];
		waitLength = (float)(double)luaOptions["waitTime"];
	}


	private IEnumerator MovePlatform() {

		string[] instructions = new string[luaInstructions.Values.Count];// = (string[])luaInstructions.Values;
		luaInstructions.Values.CopyTo(instructions, 0);

		//Debug.Log(instructions.Length);
		int nextInstructionIndex = 0;
		float wait = 0;

		while (movePlatform) {

			if (atTarget) {
				yield return new WaitForSeconds(wait);

				string nextInstruction =  instructions[nextInstructionIndex];
				//Debug.Log ("<color=green>Next instruction:</color> " + nextInstruction);

				switch (nextInstruction) {
				case "up":
					nextPosition = transform.position + Vector3.up * moveDistance;
					wait = 0f;
					break;
				case "down":
					nextPosition = transform.position - Vector3.up * moveDistance;
					wait = 0f;
					break;
				case "right":
					nextPosition = transform.position + Vector3.right * moveDistance;
					wait = 0f;
					break;
				case "left":
					nextPosition = transform.position - Vector3.right * moveDistance;
					wait = 0f;
					break;
				case "wait":
					nextPosition = transform.position;
					wait = waitLength;
					break;
				}
				nextInstructionIndex++;
				if (nextInstructionIndex >= instructions.Length) {
					nextInstructionIndex = 0;
				}
				atTarget = false;
			}
			else {
				yield return null;
			}

		}

	}

}
