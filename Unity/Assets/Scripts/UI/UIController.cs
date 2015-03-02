using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public CodeViewController codeView;
	private GameController gameController;
	private Animator uiAnimator;

	public void Start() {
		uiAnimator = GetComponent<Animator> ();
		gameController = FindObjectOfType<GameController> ();
	}

	public void ToggleCodeView(bool enabled) {
		uiAnimator.SetBool ("EditCode", enabled);
		//codeView.gameObject.SetActive (enabled);
		gameController.SetPauseGame (enabled);
	}



}
