using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {

	public HingeJoint[] rodasD;
	public HingeJoint[] rodasE;
	public Transform centrodemassa;

	void Awake () {
		rigidbody.centerOfMass = centrodemassa.localPosition;
	}
	JointMotor motorD;
	JointMotor motorE;
	// Update is called once per frame
	void FixedUpdate () {
		
		float acel = Input.GetAxis ("Vertical");
		float diff = Input.GetAxis ("Horizontal");
		motorD.force = 100;
		motorD.targetVelocity = acel * 1000+diff*-1000;
		motorE.force = 100;
		motorE.targetVelocity = acel * -1000+diff*-1000;
		
		foreach (HingeJoint joint in rodasD) {
			joint.motor=motorD;
			
		}
		foreach (HingeJoint joint in rodasE) {
			joint.motor=motorE;
			
		}
		
	}
}
