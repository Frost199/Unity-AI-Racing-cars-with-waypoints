using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingDistance : MonoBehaviour {

	public GameObject aicarMovement;
	public float ai1_speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ai1_speed = aicarMovement.GetComponent<CarEngine>().aiCurrentSpeed;
	}
}
