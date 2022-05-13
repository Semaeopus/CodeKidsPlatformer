using UnityEngine;
using System.Collections;

public class MouseCursor : MonoBehaviour {

	public enum CursorModes {
		Normal,
		Edit,
	}

	private Vector3 mouse;
	private Animator mouseAnimator;

	void Start() {
		Cursor.visible = false;
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
			mouseAnimator.SetTrigger("DefaultCursor");
			break;
		case CursorModes.Edit:
			mouseAnimator.SetTrigger("EditCursor");
			break;
		default:
			mouseAnimator.SetTrigger("DefaultCursor");
			break;
		}
	}



}
