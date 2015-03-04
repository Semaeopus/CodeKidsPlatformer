using UnityEngine;
using System.Collections;

public class SpeechBubbleController : MonoBehaviour {

	private UnityEngine.UI.Text bubbleText;
	private RectTransform bubbleTransform;

	public void Start() {
		bubbleText = GetComponentInChildren<UnityEngine.UI.Text> ();
		bubbleTransform = gameObject.GetComponent<RectTransform> ();
	}


	public void DisplayText(Transform target, string text) {
		Vector2 objectViewPos = Camera.main.WorldToViewportPoint (target.position);
		bubbleTransform.anchorMin = objectViewPos;
		bubbleTransform.anchorMax = objectViewPos;
		bubbleText.text  = text;
	}

}
