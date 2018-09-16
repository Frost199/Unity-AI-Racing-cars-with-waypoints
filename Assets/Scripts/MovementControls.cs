using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class MovementControls : MonoBehaviour {
	 //Private variables//
	Rigidbody rbody;

	//Public Variables
	public WheelCollider[] wc;
	public Transform[] tires;
	public float mTorque = 2500f;
	public float mSteer = 25f;
	public float mBrake = 10000f;
	public float mDecelerationSpeed = 1000f;
	public int wcTorqueLength;
	public int wcDecelerationSpeedLength;
	public Vector3 cOfMass = new Vector3(0, 0.7f, 0);
	public bool brakeAllowed;
	public bool turning;
	public float currentSpeed;
	public float mSpeed;
	public float mMagnitude;
	public Light leftSpotLight;
	public Light leftPointLight;
	public Light rightSpotLight;
	public Light rightPointLight;

	AudioSource audioSource;
	public int[] gearRatio;

	// Use this for initialization
	void Start () {
		rbody = gameObject.GetComponent<Rigidbody>();
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.Play();
		rbody.centerOfMass = cOfMass;
	}
	void Update(){
		LapCompleteHuman.currentSpeed = currentSpeed;
		EngineSound();
		HandBrake();
		RotatingTires();
	}

	// Update is called once per frame
	void FixedUpdate () {
		CarMovement();
		DecelerationSpeed();
	}

	void CarMovement(){
		currentSpeed = wc[2].radius * wc[2].rpm * 60/1000 * Mathf.PI;
		currentSpeed = Mathf.Round(currentSpeed);
		if(currentSpeed < mSpeed && rbody.velocity.magnitude <= mMagnitude){
			for(int i = 0; i < wcTorqueLength; i++){
				wc[i].motorTorque = CrossPlatformInputManager.GetAxis("Vertical") * mTorque;
				leftPointLight.intensity = 0f;
				rightPointLight.intensity = 0f;
			}
		}else{
			currentSpeed = mSpeed;
		}
		wc[0].steerAngle = CrossPlatformInputManager.GetAxis("Horizontal") * mSteer;
		wc[1].steerAngle = CrossPlatformInputManager.GetAxis("Horizontal") * mSteer;
		Debug.Log("wc[0].steerAngle: " + wc[0].steerAngle);
		Debug.Log("wc[1].steerAngle: " + wc[1].steerAngle);
		if(wc[0].steerAngle < 0 && wc[1].steerAngle < 0 && CrossPlatformInputManager.GetAxis("Horizontal") == -1){
			rightPointLight.intensity = 20f;
		}else if(wc[0].steerAngle > 0 && wc[1].steerAngle > 0 && CrossPlatformInputManager.GetAxis("Horizontal") == 1){
			leftPointLight.intensity = 20f;
		}
	}

	void DecelerationSpeed(){
		if(!brakeAllowed && CrossPlatformInputManager.GetAxis("Vertical") != 1){
			for(int i = 0; i < wcDecelerationSpeedLength; i++){
				wc[i].brakeTorque = mDecelerationSpeed;
				wc[i].motorTorque = 0;
				leftPointLight.intensity = 20f;
				rightPointLight.intensity = 20f;
			}
		}
		if(CrossPlatformInputManager.GetAxis("Horizontal") != 0){
			turning = true;
			if(CrossPlatformInputManager.GetAxis("Horizontal") == -1){
				float floor = 0f;
				float ceil = 20f;
				float emission = floor + Mathf.PingPong(Time.deltaTime*2f, ceil - floor);
				rightPointLight.intensity = emission;
			}else if(CrossPlatformInputManager.GetAxis("Horizontal") == 1){
				float floor = 0f;
				float ceil = 20f;
				float emission = floor + Mathf.PingPong(Time.deltaTime*2f, ceil - floor);
				leftPointLight.intensity = emission;
			}
		}else{
			turning = false;
			leftPointLight.intensity = 20f;
			rightPointLight.intensity = 20f;
		}
	}

	void HandBrake(){
		if(CrossPlatformInputManager.GetAxis("Vertical") == -1){
			brakeAllowed = true;
		}else{
			brakeAllowed = false;
		}

		if(rbody.velocity.magnitude <= 10f && brakeAllowed && turning){
			mBrake = 20f;
		}else if(brakeAllowed){
			for(int i = 0; i < wcTorqueLength; i++){
				wc[i].brakeTorque = mBrake;
				wc[i].motorTorque = 0f;
				leftPointLight.intensity = 20f;
				rightPointLight.intensity = 20f;
			}
			rbody.drag = 0.4f;
		}else if(!brakeAllowed && CrossPlatformInputManager.GetAxis("Vertical") == 1){
			
			for(int i = 0; i < wcTorqueLength; i++){
				wc[i].brakeTorque = 0;
				wc[i].motorTorque = mTorque;
				leftPointLight.intensity = 0f;
				rightPointLight.intensity = 0f;
			}
			rbody.drag = 0.1f;
		}
	}

	void RotatingTires(){
		//Spinning Tires
		for(int i = 0; i < wcTorqueLength; i++){
			tires[i].Rotate(wc[i].rpm/60 * 360 * Time.deltaTime, 0f, 0f);
		}
		//Steering Tires
		for(int i = 0; i < 2; i++){
			tires[i].localEulerAngles = new Vector3(tires[i].localEulerAngles.x, wc[i].steerAngle - tires[i].localEulerAngles.z, tires[i].localEulerAngles.z);
		}
	}

	void EngineSound(){
		float pitch = 0f;

		pitch = (float)((currentSpeed/mSpeed) + 0.4);
		if(pitch >= 1.4f){
			pitch = 0.9f;
		}
		audioSource.pitch = pitch;
	}
}
