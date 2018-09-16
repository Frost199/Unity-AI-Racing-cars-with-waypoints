using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetIndividualLap : MonoBehaviour {

	public static int lapdone;
	public int cloneLapDone;
	// Use this for initialization
	void Start () {
		cloneLapDone = lapdone;
		if(gameObject.tag == "playerCar"){
			LapComplete.lapdone_Human = lapdone;
		}else if(gameObject.tag == "AI_1"){
			LapComplete.lapdone_AI1 = lapdone;
		}else if(gameObject.tag == "AI_2"){
			LapComplete.lapdone_AI2 = lapdone;
		}else if(gameObject.tag == "AI_3"){
			LapComplete.lapdone_AI3 = lapdone;
		}
	}
	
	// Update is called once per frame
	void Update () {
		cloneLapDone = lapdone;
		if(gameObject.tag == "playerCar"){
			LapComplete.lapdone_Human = lapdone;
		}else if(gameObject.tag == "AI_1"){
			LapComplete.lapdone_AI1 = lapdone;
		}else if(gameObject.tag == "AI_2"){
			LapComplete.lapdone_AI2 = lapdone;
		}else if(gameObject.tag == "AI_3"){
			LapComplete.lapdone_AI3 = lapdone;
		}
	}
}
