using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroTextControl : MonoBehaviour {

	public GameObject levelText;
	public GameObject gameManager;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void IntroEnd() {
		gameManager.GetComponent<LevelIntroHandler>().IntroEnd();
	}

	public void ChangeLevel(string level) {
		levelText.GetComponent<Text>().text = level;
	}

	
}
