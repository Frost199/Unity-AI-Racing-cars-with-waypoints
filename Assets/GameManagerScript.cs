using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour {

	//public static GameManagerScript instance;
	public GameObject pauseCountDown;
	public GameObject pausePanel;
	public GameObject[] CarControlsPause;
	public GameObject lapTimerInGame;
	public GameObject ConfirmationPanel;
	public GameObject ConfirmationPanelRestart;

	void Awake(){
		pausePanel.SetActive(false);
		ConfirmationPanel.SetActive(false);
		ConfirmationPanelRestart.SetActive(false);
		//MakingSingleton();
	}

	/*void MakingSingleton(){
		if(instance != null){
			Destroy(gameObject);
		}else{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}*/

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PauseGame(){
		pausePanel.SetActive(true);
		Time.timeScale = 0;
	}

	public void ResumeGame(){
		pausePanel.SetActive(false);
		Time.timeScale = 1;
	}

	public void RestartCurrentLevel(){
		pausePanel.SetActive(false);
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);	
		Time.timeScale = 1;
		/*SceneManager.LoadScene("bestTimeAttack");
		Time.timeScale = 1;*/
		LapComplete.lapdone_Human = 1;
		LapTimeManager.MinuteCount = 0;
		LapTimeManager.SecondCount = 0;
		LapTimeManager.MilliCount = 0;
		LapTimeManager.rawTime = 0;
	}

	public void RestartCurrentLevelTimeChallenge(){
		pausePanel.SetActive(false);
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);	
		Time.timeScale = 1;
		/*SceneManager.LoadScene("bestTimeAttack");
		Time.timeScale = 1;*/
		LapTimeManager.MinuteCount = 0;
		LapTimeManager.SecondCount = 0;
		LapTimeManager.MilliCount = 0;
		LapTimeManager.rawTime = 0;
	}

	public void MainMenu(){
		ConfirmationPanel.SetActive(true);
	}

	public void MainMenuRestart(){
		ConfirmationPanelRestart.SetActive(true);
	}

	public void Validate(){
		SceneManager.LoadScene("ModeSelection");
		Time.timeScale = 1;
	}

	public void invalidatePause(){
		ConfirmationPanel.SetActive(false);
		ResumeGame();
	}

	public void invalidateRestart(){
		ConfirmationPanelRestart.SetActive(false);
	}

}
