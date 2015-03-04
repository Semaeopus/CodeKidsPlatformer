using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public CodeViewController codeView;
	public SpeechBubbleController speechBubble;
	private GameController gameController;
	private Animator uiAnimator;

	public void Start() {
		uiAnimator = GetComponent<Animator> ();
		gameController = FindObjectOfType<GameController> ();
	}

	public void ToggleCodeView(bool enabled) {
		uiAnimator.SetBool ("EditCode", enabled);
		gameController.SetPauseGame (enabled);
	}

	public void  DisplaySpeechBubble(Transform target, string text) {
		speechBubble.DisplayText (target, text);
		uiAnimator.SetBool ("SpeechBubble", true);
	}

	public void HideSpeechBubble() {
		uiAnimator.SetBool ("SpeechBubble", false);
	}



}
