using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIcarControlManager : MonoBehaviour {

	public GameObject[] aiCarMovement;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < aiCarMovement.Length; i++){
			aiCarMovement[i].GetComponent<CarEngine>().enabled = true;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
