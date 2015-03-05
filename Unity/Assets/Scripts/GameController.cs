﻿using UnityEngine;
using System.Collections;

public class GameController : LuaController {


	public delegate void ChangeGameState();
	public static event ChangeGameState OnPauseGame;
	public static event ChangeGameState OnUnPauseGame;

	public GameObject SpeechBubblePrefab;
	private GameObject speechBubble;

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
			speechBubble.GetComponent<SpeechBubbleController>().DisplayText(this.gameObject.transform, "Hello there!");
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag("Player")) {
			speechBubble.GetComponent<SpeechBubbleController>().HideText();
		}
	}


}
