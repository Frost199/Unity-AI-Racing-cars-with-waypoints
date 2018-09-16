using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPointTrigger : MonoBehaviour {

	public GameObject LapCompleteTrig;
	public GameObject HalfLapTrig;
	public GameObject lastPoint;
	public GameObject AI1LapCOmplete;
	public GameObject AI2LapCOmplete;
	public GameObject AI3LapCOmplete;


	void Start(){
		LapCompleteTrig.SetActive (false);
		lastPoint.SetActive(false);
		AI1LapCOmplete.SetActive(false);
		AI2LapCOmplete.SetActive(false);
		AI3LapCOmplete.SetActive(false);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "playerCar"){
		LapCompleteTrig.SetActive (true);
		lastPoint.SetActive(true);
		AI1LapCOmplete.SetActive(true);
		AI2LapCOmplete.SetActive(true);
		AI3LapCOmplete.SetActive(true);
		}
	}
}
