using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


//public delegate void metodoDelegado (int paramentro);


public class ScoreScuare : MonoBehaviour {


	public static ScoreScuare instance;
	public int count;
	//public event metodoDelegado Evento;
	//	private Score score;
	// Use this for initialization

	void Awake() {}

	void Start () {instance = this;}
	
	// Update is called once per frame
	void Update () {}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Score") {
			GanarPuntos ();
		}
		if (c.gameObject.tag == "Fire") {
			PerderPuntos ();
		}
	}


	void GanarPuntos(){
		count++;
		Debug.Log ("Tienes " + count + " puntos.");
		//count += recolecta;
	}

	void PerderPuntos(){
		count = 0;
		Debug.Log ("Tienes " + count + " puntos.");
	}

}
