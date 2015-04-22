using UnityEngine;
using System.Collections;

public class aviao3d : MonoBehaviour {

	float dir=0f;
	float lift=0f;
	Rigidbody rBody;

	void Awake () {
		rBody = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		dir = Input.GetAxis ("Horizontal");
		lift = Input.GetAxis ("Vertical");
	}

	void FixedUpdate(){
		//aqui adicionar um drag pra ter algum atrito
		rBody.AddRelativeForce (Vector3.forward * 200);
		rBody.AddRelativeForce (Vector3.up * rBody.velocity.sqrMagnitude * 0.1f);

		rBody.drag = rBody.velocity.sqrMagnitude * 0.001f;

		rBody.AddRelativeTorque (new Vector3(lift,0,-dir)*10);
	}
}
