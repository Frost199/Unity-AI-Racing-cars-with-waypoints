using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour {

	//private Variables
	Rigidbody rbody;
	private List<Transform> nodes;
	private int currentNode = 0;

	//public variables
	public Transform path;
	public Transform[] tyres;
	public float mAISteer = 25f;
	public float mAITorque = 2500f;
	public float mAIDecelerationSpeed = 0f;
	public WheelCollider[] wheelCol;
	public Vector3 cOfMass = new Vector3(0, 0.7f, 0);
	public float aiCurrentSpeed;
	public float mAISpeed;
	public float mAIMagnitude;
	public int wheelColTorqueLength;
	public int wcAIDecelerationSpeedLength;
	public bool aiTurning;
	public bool increment = false;
	/*[Header("Sensors")]
	public float sensorLength = 3f;
	public float frontSensorPos = 0.5f;
	public float frontSideSensorPosition = 0.2f;*/

	// Use this for initialization
	void Start () {
		rbody = gameObject.GetComponent<Rigidbody>();
		rbody.centerOfMass = cOfMass;
		Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
		nodes = new List<Transform>();

		for(int i = 0; i < pathTransforms.Length; i++){
			if(pathTransforms[i] != path.transform){
				nodes.Add(pathTransforms[i]);
			}
		}
	}

	void Update(){
		RotateTires();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//SensorsFunc();
		ApplySteer();
		CarDrive();
		CheckWaypointDistance();
	}

	/*void SensorsFunc(){
		RaycastHit hit;
		Vector3 sensorStartPos = transform.position;
		Debug.Log(sensorStartPos);
		sensorStartPos.z += frontSensorPos;

		//front center sensor
		if(Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength)){
			
		}
		Debug.DrawLine(sensorStartPos, hit.point);

		//front right sensor
		sensorStartPos.x += frontSideSensorPosition;
		if(Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength)){

		}
		Debug.DrawLine(sensorStartPos, hit.point);

		//front left sensor
		sensorStartPos.x -= 2 * frontSideSensorPosition;
		if(Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength)){

		}
		Debug.DrawLine(sensorStartPos, hit.point);
	}*/

	void ApplySteer(){
		Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
		relativeVector /= relativeVector.magnitude; // same thing as relativeVector = relativeVector / relativeVector.magnitude
		float newSteer = (relativeVector.x / relativeVector.magnitude) * mAISteer;
		wheelCol[0].steerAngle = newSteer;
		wheelCol[1].steerAngle = newSteer;
	}

	void CheckWaypointDistance(){
		if(Vector3.Distance(transform.position, nodes[currentNode].position) < 1f){
			if(currentNode == nodes.Count - 1){
				currentNode = 0;
			}else{
				currentNode++;
			}
		}
	}

	void CarDrive(){
		aiCurrentSpeed = wheelCol[2].radius * wheelCol[2].rpm * 60/1000 * Mathf.PI * 2;
		aiCurrentSpeed = Mathf.Round(aiCurrentSpeed);
		if(aiCurrentSpeed < mAISpeed && rbody.velocity.magnitude <= mAIMagnitude){
			for(int i = 0; i < wheelColTorqueLength; i++){
				wheelCol[i].motorTorque = mAITorque;
			}
		}else{
			for(int i = 0; i < wheelColTorqueLength; i++){
				wheelCol[i].motorTorque = 0;
			}
		}
	}

	void RotateTires(){
		//Spinning Tires
		for(int i = 0; i < wheelColTorqueLength; i++){
			tyres[i].Rotate(wheelCol[i].rpm/60 * 360 * Time.deltaTime, 0f, 0f);
		}
		//Steering Tires
		for(int i = 0; i < 2; i++){
			tyres[i].localEulerAngles = new Vector3(tyres[i].localEulerAngles.x, wheelCol[i].steerAngle - tyres[i].localEulerAngles.z, tyres[i].localEulerAngles.z);
		}
	}

	void OnTriggerEnter(Collider other){
		
		if(other.gameObject.tag == "turningPointEntry"){
			increment = true;
			mAISpeed = 120f;
			mAITorque = 500f;
			aiCurrentSpeed = 100f;
			aiTurning = true;
			Debug.Log("Ayaf enter");

		}else if(other.gameObject.tag == "turningPointExit"){
			
			increment = false;
			mAITorque = 2500f;
			for(int i = 0; i < wcAIDecelerationSpeedLength; i++){
				wheelCol[i].motorTorque = mAITorque;
			}
			mAISpeed = 500f;
			aiTurning = false;
			Debug.Log("Ayaf comot");

		}else if(other.gameObject.tag == "finishLine"){
			
			for(int i = 0; i < wheelColTorqueLength; i++){
				wheelCol[i].motorTorque = 500f;
			}
			mAITorque = 2500f;
			mAISpeed = 500f;
			aiCurrentSpeed = 0f;
			Debug.Log("Ayaf enter finish Line o!");
			Debug.Log(aiCurrentSpeed);

		}
		if(increment){
			mAITorque += 300f;
			mAISpeed += 200f;
		}
	}
}
