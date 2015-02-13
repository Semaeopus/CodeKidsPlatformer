using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {



	public void RestartLevel() {
		Debug.Log ("Reload level");
		Application.LoadLevel(Application.loadedLevelName);
	}

}
