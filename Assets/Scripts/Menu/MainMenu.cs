using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public InputField nameCollector;
	public Text displayText;
	public string fieldInfo;
	public string savedFieldInfo;
	public string loadSavedFieldInfo;
	public GameObject infoContainer;
	public GameObject infoCollected;

	// Use this for initialization
	void Start () {

		loadSavedFieldInfo = PlayerPrefs.GetString("NameCollected");
		Debug.Log(loadSavedFieldInfo);
		if(loadSavedFieldInfo != ""){
			infoCollected.SetActive(true);
			infoContainer.SetActive(false);
			displayText.text = loadSavedFieldInfo;
		}else if(loadSavedFieldInfo == ""){
			infoCollected.SetActive(false);
			infoContainer.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CollectedInfo(){
		savedFieldInfo = nameCollector.text.ToString();
		fieldInfo = nameCollector.text;
		if(savedFieldInfo == "" && fieldInfo == ""){
			return;
		}else{
			PlayerPrefs.SetString("NameCollected", savedFieldInfo);
			displayText.text = fieldInfo;
			infoContainer.SetActive(false);
			infoCollected.SetActive(true);
		}
	}

	public void NextScene(){
		SceneManager.LoadScene("ModeSelection");
	}
}
