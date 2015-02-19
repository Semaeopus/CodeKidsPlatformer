using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject cameraTarget;

	public Vector3 newCameraPos;

	// Use this for initialization
	void Start () {

		cameraTarget = GameObject.FindGameObjectWithTag("Player");
	}


	// Update is called once per frame
	void LateUpdate () {

		newCameraPos = new Vector3(cameraTarget.transform.position.x,
			             						cameraTarget.transform.position.y, 
			             							this.transform.position.z);

		this.transform.position = newCameraPos;
	
	}
}
