using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class halfLapCompleteAI3 : MonoBehaviour {

	public GameObject halfLapCompleteAI3_deactivate;
	public GameObject AI2LapCOmplete;

	// Use this for initialization
	void Start () {
		AI2LapCOmplete.SetActive(false);
		halfLapCompleteAI3_deactivate.SetActive(true);
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "AI3"){
			halfLapCompleteAI3_deactivate.SetActive (false);
			AI2LapCOmplete.SetActive(true);
		}
	}
}
