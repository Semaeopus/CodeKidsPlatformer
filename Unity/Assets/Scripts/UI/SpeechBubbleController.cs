using UnityEngine;
using System.Collections;

public class SpeechBubbleController : MonoBehaviour {

	private UnityEngine.UI.Text bubbleText;
	private RectTransform bubbleTransform;
	private Animator bubbleAnimator;

	public void OnEnable() {
		bubbleText = GetComponentInChildren<UnityEngine.UI.Text> ();
		bubbleTransform = gameObject.GetComponent<RectTransform> ();
		bubbleAnimator = gameObject.GetComponent<Animator> ();
	}


	public void DisplayText(Transform target, string text) {
//		Vector2 objectViewPos = Camera.main.WorldToViewportPoint (target.position);
//		bubbleTransform.anchorMin = objectViewPos;
//		bubbleTransform.anchorMax = objectViewPos;
		transform.position = target.position;
		bubbleText.text  = text;
		bubbleAnimator.SetBool ("Visible", true);
	}

	public void HideText() {
		bubbleAnimator.SetBool ("Visible", false);
		Invoke ("Destroy", 1.0f);
	}

	private void Destroy() {
		Destroy (this.gameObject);
	}

}
