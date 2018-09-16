using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelected : MonoBehaviour {

	public GameObject selectorPanel;
	public GameObject quitPanel;

	// Use this for initialization
	void Start () {
		selectorPanel.SetActive(false);
		quitPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadTimeChallenge(){
		SceneManager.LoadScene("timeChallenge");
	}

	public void LoadSecondBestTimeChallenge(){
		SceneManager.LoadScene("bestTimeAttackNew");
	}

	public void LoadBestTimeChallenge(){
		SceneManager.LoadScene("bestTimeAttack");
	}

	public void SelectorPanelActivator(){
		selectorPanel.SetActive(true);
	}

	public void CancelPanelActivator(){
		selectorPanel.SetActive(false);
	}

	public void QuitPanelActivator(){
		quitPanel.SetActive(true);
	}

	public void Quit(){
		Application.Quit();
	}

	public void NotQuiting(){
		quitPanel.SetActive(false);
	}
}
