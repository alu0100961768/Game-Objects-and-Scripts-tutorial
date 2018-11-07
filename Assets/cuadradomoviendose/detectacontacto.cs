using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectacontacto : MonoBehaviour {

	public Material ColorOnEnter;
	public Material ColorOnStay;
	public Material ColorOnExit;

	public Material ColorOnEnterE;
	public Material ColorOnStayE;
	public Material ColorOnExitE;

	public GameObject Object;

	void OnTriggerEnter(Collider c){
		if (c.gameObject.name == "ThirdPersonController") {
			Debug.Log ("Ethan ha entrado en contacto con el cilindro " + Object.name + ".");
			Object.GetComponent<MeshRenderer> ().material = ColorOnEnterE;
		}
		else {
			Debug.Log (c.gameObject.name + " ha entrado en contacto con el cilindro " + Object.name + ".");
			Object.GetComponent<MeshRenderer> ().material = ColorOnEnter;
		}
	}

	void OnTriggerStay(Collider c){
		if (c.gameObject.name == "ThirdPersonController") {
			Debug.Log ("Ethan está en contacto con el cilindro " + Object.name + ".");
			Object.GetComponent<MeshRenderer> ().material = ColorOnStayE;
		}
		else {
			Debug.Log (c.gameObject.name +" está en contacto con el cilindro " + Object.name + ".");
			Object.GetComponent<MeshRenderer> ().material = ColorOnStay;
		}
	}
		
	void OnTriggerExit(Collider c){
		if (c.gameObject.name == "ThirdPersonController") {
			Debug.Log ("Ethan ha dejado de estar en contacto con el cilindro " + Object.name + ".");
			Object.GetComponent<MeshRenderer> ().material = ColorOnExitE;
		}
		else {
			Debug.Log (c.gameObject.name + " ha dejado de estar en contacto con el cilindro " + Object.name + ".");
			Object.GetComponent<MeshRenderer> ().material = ColorOnExit;
		}
	}

	// Use this for initialization
	void Start () {}

	// Update is called once per frame
	void Update () {}
}
