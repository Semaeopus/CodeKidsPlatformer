using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public GameObject codeView;

	public void ToggleCodeView(bool enabled) {
		codeView.SetActive (enabled);
	}



}
