using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	float dir = 0f;
	float lift = 0f;
	Rigidbody2D rigidbodyObject;

	void Awake () {
		rigidbodyObject = GetComponent<Rigidbody2D> ();

		//alterar o centro de massa
		// o (0,0) eh relativo ao objeto que tem o rigidbody
		//ele nao pega relativo ao global
		//o 0,0 eh o pivot do objeto que tem o rigidbody
		rigidbodyObject.centerOfMass = new Vector2 (0, 0);
	}
	
	void Update () {
		dir = Input.GetAxis ("Horizontal");
		lift += Input.GetAxis ("Vertical");

		//limita o valor do lift
		lift = Mathf.Clamp (lift, 9f, 11f);
	}

	void FixedUpdate(){
		//rigidbodyObject.AddForce(new Vector2(0,lift));

		//pega a relacao da direcao com o helicoptero, e nao com o global
		//ex.: se o helicoptero inclinar pra frente apertar pra cima fara ele ir pra frente
		rigidbodyObject.AddRelativeForce(new Vector2(0,lift));

		//addtorque adiciona forca de giro
		//rigidbodyObject.AddTorque (-dir);

		//ve inclinacao em comparacao com o mundo
		//maior que 90 inclinado pra frente
		//menor que 90 inclinado pra tras
		float ang = Vector2.Angle (transform.right, Vector2.up);

		//aumentar angular drap pra nao balancar aqui
		rigidbodyObject.AddTorque((-dir)+((ang-90)*0.025f));
	}

}
