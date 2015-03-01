using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public CodeViewController codeView;
	private GameController gameController;

	public void Start() {
		gameController = FindObjectOfType<GameController> ();
	}

	public void ToggleCodeView(bool enabled) {
		codeView.gameObject.SetActive (enabled);
		gameController.SetPauseGame (enabled);
	}



}
