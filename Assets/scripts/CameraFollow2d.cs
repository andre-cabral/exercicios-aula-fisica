using UnityEngine;
using System.Collections;

public class CameraFollow2d : MonoBehaviour {
	public Transform objectToFollow;
	public bool followY = true;

	void Awake(){

	}

	void Update () {
		if (followY) {
			gameObject.transform.position = new Vector3 (objectToFollow.transform.position.x, objectToFollow.position.y, gameObject.transform.position.z);
		}else{
			gameObject.transform.position = new Vector3 (objectToFollow.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		}
	}
}
