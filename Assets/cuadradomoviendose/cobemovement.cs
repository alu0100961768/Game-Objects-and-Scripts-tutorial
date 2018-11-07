using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cobemovement : MonoBehaviour {

	public KeyCode moveForward;
	public KeyCode moveBack;
	public KeyCode moveLeft;
	public KeyCode moveRight;

	public int speed;

	////////////////////////////////////////////////////////////////////////////////

	public Material colorEstatico;
	public Material colorColision;

	public GameObject Object;

	void OnCollisionEnter(Collision c){
		Object.GetComponent<MeshRenderer> ().material = colorColision;
	}

	void OnCollisionExit(Collision c){
		Object.GetComponent<MeshRenderer> ().material = colorEstatico;
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (moveForward))
			transform.Translate(Vector3.forward * Time.deltaTime *speed);

		if (Input.GetKey (moveBack))
			transform.Translate(Vector3.back * Time.deltaTime *speed);

		if (Input.GetKey (moveLeft))
			transform.Translate(Vector3.left * Time.deltaTime *speed);

		if (Input.GetKey (moveRight))
			transform.Translate (Vector3.right * Time.deltaTime *speed);

	}
}