using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsMarkers : MonoBehaviour {

	[SerializeField]
	public static List<Transform> checkpointNodes = new List<Transform>();
	public List<int> checkpointIdToInt = new List<int>();
	[SerializeField]
	public static int totalCheckPoints;

	// Use this for initialization
	void Start () {
		Transform[] checkpointTransforms = GetComponentsInChildren<Transform>();
		checkpointNodes = new List<Transform>();
		checkpointIdToInt = new List<int>();

		for(int i = 0; i < checkpointTransforms.Length; i++){
			if(checkpointTransforms[i] != transform){
				checkpointNodes.Add(checkpointTransforms[i]);
			}
		}
		for(int i = 0; i < checkpointNodes.Count; i++){
			checkpointIdToInt.Add(checkpointNodes.IndexOf(checkpointNodes[i]));
		}

		for(int i = 0; i < checkpointIdToInt.Count; i++){
			totalCheckPoints = i + 1;
		}
	}

}
