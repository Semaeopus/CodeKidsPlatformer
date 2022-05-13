using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : LuaController {


	public delegate void ChangeGameState();
	public static event ChangeGameState OnPauseGame;
	public static event ChangeGameState OnUnPauseGame;

	public GameObject SpeechBubblePrefab;
	private GameObject speechBubble;

	private QuestController quest;

	public override void Init () {
		quest = GetComponent<QuestController> ();
		lua["world"] = this;
		lua.DoString ("Start()");
	}

	public override void Reset() {
	}

	public void RestartLevel() {
		Debug.Log ("Reload level");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void SetGravity(float gravity) {
		Debug.Log ("Changed global gravity to " + gravity);
		Physics2D.gravity = new Vector2 (0f, -gravity);
	}

	public void SetPauseGame(bool pause) {
		if (pause) {
			//Time.timeScale = 0;
			OnPauseGame();
		}
		else {
			//Time.timeScale = 1f;
			OnUnPauseGame();
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag("Player")) {
			speechBubble = Instantiate(SpeechBubblePrefab) as GameObject;
			speechBubble.transform.SetParent(this.gameObject.transform);
			string hint = quest.GetNextHint();
			speechBubble.GetComponent<SpeechBubbleController>().DisplayText(this.gameObject.transform, hint);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag("Player")) {
			speechBubble.GetComponent<SpeechBubbleController>().HideText();
		}
	}

	public override void MouseClick() {
		string hint = quest.GetNextHint();
		if (!string.IsNullOrEmpty(hint)) {
			if (!speechBubble) {
				speechBubble = Instantiate(SpeechBubblePrefab) as GameObject;
				speechBubble.transform.SetParent(this.gameObject.transform);
			}
			speechBubble.GetComponent<SpeechBubbleController>().DisplayText(this.gameObject.transform, hint);
		}
		else {
			speechBubble.GetComponent<SpeechBubbleController>().HideText();
		}


	}


}
