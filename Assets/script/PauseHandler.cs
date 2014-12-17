using UnityEngine;
using System.Collections;

public class PauseHandler : MonoBehaviour {
	
	bool isPaused = false;
	public GameObject menu;
	
	// Use this for initialization
	void Start () {
		menu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p") || Input.GetKeyDown (KeyCode.Escape)){
			isPaused = !isPaused;
			if(isPaused){
				menu.SetActive(true);
				Time.timeScale = 0;
			}else{
				menu.SetActive(false);
				Time.timeScale = 1;
			}
		}
		
	}
	
	public void Resume() {
		Debug.Log ("resume");
		isPaused = false;
		Time.timeScale = 1;
		menu.SetActive(false);
	}

	public void LevelSelect() {
		// TODO: Add levels

	}

	public void Settings() {
		// TODO: Come up with settings
	}

	public void Controls() {
		// TODO: Come up with controls
	}

	public void Exit() {
		Application.Quit();
	}
}
