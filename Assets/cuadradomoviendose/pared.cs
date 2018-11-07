using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pared : MonoBehaviour {

	public Material Color;

	public delegate void metodoDelegado ();
	public static event metodoDelegado Evento;


	void OnTriggerEnter(Collider c){
		Evento ();
	}
		
	void cambiarcolor(){
		this.gameObject.GetComponent<MeshRenderer> ().material = Color;
	}

	// Use this for initialization
	void Start () {
		//metodoDelegado = cambiarcolor ();
	}
	
	// Update is called once per frame
	void OnEnable(){
		Evento += cambiarcolor;
	}

	void OnDisable()
	{
		Evento -= cambiarcolor;
	}

}
