using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	public float turnSpeed = 4.0f;

	// Use this for initialization
	void Start () {
		//offset = new Vector3 (player.transform.position.x + 2.0f, player.transform.position.y + 8.0f, player.transform.position.z + 7.0f);
		offset = transform.position - player.transform.position;
		//offset = transform.TransformPoint (Vector3.back * 2);
		//Instantiate (player, offset, player.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		//offset = Quaternion.AngleAxis (Input.GetAxis ("Horizontal") * turnSpeed, Vector3.back) * offset;
		transform.position = Vector3.Lerp (transform.position, player.transform.TransformPoint(offset), turnSpeed * Time.deltaTime);
		//transform.position = player.transform.position + offset;
		transform.LookAt (player.transform);
		//transform.eulerAngles = new Vector3 (transform.eulerAngles.x, 0, 0);
	}
}
