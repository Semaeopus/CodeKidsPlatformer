using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public CodeViewController codeView;

	public void ToggleCodeView(bool enabled) {
		codeView.gameObject.SetActive (enabled);
	}



}
