using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class halfLapCompleteAI2 : MonoBehaviour {

	public GameObject halfLapCompleteAI2_deactivate;
	public GameObject AI1LapCOmplete;
	public GameObject AI2LapCOmplete;
	public GameObject AI3LapCOmplete;
	// Use this for initialization
	void Start () {
		AI1LapCOmplete.SetActive(false);
		AI2LapCOmplete.SetActive(false);
		AI3LapCOmplete.SetActive(false);
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(){
		AI1LapCOmplete.SetActive(true);
		AI2LapCOmplete.SetActive(true);
		AI3LapCOmplete.SetActive(true);
	}
}
