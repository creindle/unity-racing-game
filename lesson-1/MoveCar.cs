using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour {

	public float speed;

	public float angularSpeed = 2f;

	private Rigidbody rb;

	Vector3 rotationY;
	Vector3 movement;

	float newNumber;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
		
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertically = Input.GetAxis ("Vertical");

		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertically);

		MoveForward (moveVertically);
		SteerCar (moveHorizontal);

		//rb.AddForce (Vector3.forward * speed);
	}

	void SteerCar (float moveHorizontal) {
		rotationY.Set (0f, moveHorizontal, 0f);
		rotationY = rotationY.normalized * angularSpeed;

		newNumber = rb.rotation.eulerAngles.y;

		newNumber += moveHorizontal;

		rb.MoveRotation(Quaternion.Euler(0, newNumber, 0));
	}

	void MoveForward (float moveVertically){
		if (moveVertically > 0) {
			movement = transform.forward;
			movement = movement.normalized * speed * Time.deltaTime;
			rb.MovePosition (rb.position + movement);
		}
		else if (moveVertically < 0) {
			movement = transform.forward * -1;
			movement = movement.normalized * (speed/2) * Time.deltaTime;
			rb.MovePosition(rb.position + movement);
		}
	}
}
