using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carControlManager : MonoBehaviour {

	public GameObject carMovement;
	GameObject dummy;
	public GameObject[] allCarsUnfreez;
	// Use this for initialization
	void Start () {
		carMovement.GetComponent<MovementControls>().enabled = true;
		for(int i = 0; i < allCarsUnfreez.Length; i++){
			allCarsUnfreez[i].GetComponent<groundCheck>().rb.isKinematic = false;
			allCarsUnfreez[i].GetComponent<groundCheck>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
