using UnityEngine;
using System.Collections;

public class BreakHinge2d : MonoBehaviour {

	public HingeJoint2D hingeJoint2d;
	public float breakingForce;
	private bool hingeDestroyed = false;

	void FixedUpdate () {
		if(!hingeDestroyed && hingeJoint2d.GetReactionForce(Time.deltaTime).magnitude >= breakingForce){
			Destroy(hingeJoint2d);
			hingeDestroyed = true;
		}
	}
}
