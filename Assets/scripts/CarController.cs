using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	public WheelJoint2D wheelFrontal;
	public WheelJoint2D wheelTraseira;

	float acel;
	JointMotor2D motorTraseiro;

	void Awake(){
		motorTraseiro = new JointMotor2D();
		motorTraseiro.maxMotorTorque = 10000f;
	}

		
	void Update () {
		acel = Input.GetAxis ("Horizontal");

		if(acel == 0 && (wheelFrontal.useMotor || wheelTraseira.useMotor)){
			wheelFrontal.useMotor = false;
			wheelTraseira.useMotor = false;
		}
		if(acel != 0 && (!wheelFrontal.useMotor || !wheelTraseira.useMotor)){
			wheelFrontal.useMotor = true;
			wheelTraseira.useMotor = true;
		}
		if(acel != 0){
			motorTraseiro.motorSpeed = - (acel * 1000f);
			wheelTraseira.motor = motorTraseiro;
			wheelFrontal.motor = motorTraseiro;
		}
	}
}
