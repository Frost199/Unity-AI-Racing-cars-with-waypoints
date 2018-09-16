using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPosition : MonoBehaviour {

	//public variables
	public int checkpointID;
	public int totalCheckpointInGame;
	public int humanpositionMAgnitude = 0;
	public int AI1positionMAgnitude = 0;
	public int AI2positionMAgnitude = 0;
	public int AI3positionMAgnitude = 0;
	public List<int> valuesToCompare = new List<int>();
	public int currentLapHuman = LapComplete.lapdone_Human;
	public int currentLapAI1 = LapComplete.lapdone_AI1;
	public int currentLapAI2 = LapComplete.lapdone_AI2;
	public int currentLapAI3 = LapComplete.lapdone_AI3;
	public List<Transform> currentCheckpoint = CheckpointsMarkers.checkpointNodes;


	// Use this for initialization
	void Start () {
		valuesToCompare.Add(humanpositionMAgnitude);
		valuesToCompare.Add(AI1positionMAgnitude);
		valuesToCompare.Add(AI2positionMAgnitude);
		valuesToCompare.Add(AI3positionMAgnitude);

		for(int i = 0; i < currentCheckpoint.Count; i++){
			if(currentCheckpoint[i] == this.gameObject.transform){
				checkpointID = currentCheckpoint.IndexOf(currentCheckpoint[i]) + 1;
			}
			totalCheckpointInGame = i + 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		valuesToCompare.Sort();
		valuesToCompare.Reverse();
	}

	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "playerCar"){
			
			humanpositionMAgnitude = currentLapHuman * totalCheckpointInGame + checkpointID;
			Debug.Log(humanpositionMAgnitude);
			//updating a list item
			for(int i = 0; i < valuesToCompare.Count; ++i ){
				if(valuesToCompare[i] == humanpositionMAgnitude){
					valuesToCompare[i] = valuesToCompare[i] + humanpositionMAgnitude;
				}
			}

		}else if(other.gameObject.tag == "AI_1"){
			
			AI1positionMAgnitude = currentLapAI1 * totalCheckpointInGame + checkpointID;
			Debug.Log(AI1positionMAgnitude);
			//updating a list item
			for(int i = 0; i < valuesToCompare.Count; ++i ){
				if(valuesToCompare[i] == AI1positionMAgnitude){
					valuesToCompare[i] = valuesToCompare[i] + AI1positionMAgnitude;
				}
			}

		}else if(other.gameObject.tag == "AI_2"){
			
			AI2positionMAgnitude = currentLapAI2 * totalCheckpointInGame + checkpointID;
			Debug.Log(AI2positionMAgnitude);
			//Updating a list item
			for(int i = 0; i < valuesToCompare.Count; ++i ){
				if(valuesToCompare[i] == AI2positionMAgnitude){
					valuesToCompare[i] = valuesToCompare[i] + AI2positionMAgnitude;
				}
			}

		}else if(other.gameObject.tag == "AI_3"){
			
			AI3positionMAgnitude = currentLapAI3 * totalCheckpointInGame + checkpointID;
			Debug.Log(AI3positionMAgnitude);
			for(int i = 0; i < valuesToCompare.Count; ++i ){
				if(valuesToCompare[i] == AI3positionMAgnitude){
					valuesToCompare[i] = valuesToCompare[i] + AI3positionMAgnitude;
				}
			}

		}

	}

}
