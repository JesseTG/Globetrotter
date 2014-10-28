using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	bool isPaused = false;
	bool isBeginning = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isBeginning == true){
			Time.timeScale = 0;
			if (Input.GetKeyDown ("space")){
				isBeginning = false;
				Time.timeScale = 1;
			}
			return;
		}
		if (Input.GetKeyDown ("p")){
			isPaused = !isPaused;

			if(isPaused)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
		}
	
	}


	void OnGUI(){
		if(isPaused)
			GUI.Label(new Rect(Screen.width/3,0,Screen.width,Screen.height),"resume\nlevel select\nsettings\ncontrols\nexit");
		if(isBeginning)
			GUI.Label(new Rect(Screen.width/3,Screen.height/3,Screen.width,Screen.height),"RUN THE WORLD\n\npress space bar to continue");

	}
}
