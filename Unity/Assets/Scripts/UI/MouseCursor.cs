using UnityEngine;
using System.Collections;

public class MouseCursor : MonoBehaviour {

	public Sprite normalCursor;
	public Sprite editCursor;

	public enum CursorModes {
		Normal,
		Edit,
	}

	private Vector3 mouse;
	private SpriteRenderer cursorRenderer;
	private Animator mouseAnimator;

	void Start() {
		Screen.showCursor = false;
		cursorRenderer = GetComponent<SpriteRenderer> ();
		mouseAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mouse.z = 0f;
		transform.position = new Vector3 (mouse.x, mouse.y, transform.position.z);
	}

	public void SetCursor(CursorModes newMode) {
		switch (newMode) {
		case CursorModes.Normal:
			//cursorRenderer.sprite = normalCursor;
			mouseAnimator.SetTrigger("DefaultCursor");
			break;
		case CursorModes.Edit:
			//cursorRenderer.sprite = editCursor;
			mouseAnimator.SetTrigger("EditCursor");
			break;
		default:
			//cursorRenderer.sprite = normalCursor;
			mouseAnimator.SetTrigger("DefaultCursor");
			break;
		}
	}



}
