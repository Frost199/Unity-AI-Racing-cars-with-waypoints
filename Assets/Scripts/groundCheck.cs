using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour {
	RaycastHit hit;
	public Rigidbody rb;
	float range = 1f;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		checkGround();
	}
	
	// Update is called once per frame
	void Update () {
		checkGround();
	}

	void checkGround(){
		Ray ray = new Ray(transform.position, -transform.up);
		if(Physics.Raycast(ray, out hit, range)){
			if(hit.collider.tag == "ground"){
				rb.isKinematic = true;
			}else{
				rb.isKinematic = false;
			}
		}
		Debug.DrawRay(transform.position, -transform.up * range, Color.green);
	}
}
