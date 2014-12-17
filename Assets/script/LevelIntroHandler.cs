using UnityEngine;
using System.Collections;

public class LevelIntroHandler : MonoBehaviour {

	public GameObject player, level, introText;
	private bool playIntro = false;

	// Use this for initialization
	void Start () {
		OnLevelWasLoaded (-1);
	}

	void OnLevelWasLoaded(int level) {
		IntroStart ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void IntroStart() {
		SetPlayIntro(true);
		introText.GetComponent<IntroTextControl>().ChangeLevel(Application.loadedLevelName);
	}
	public void IntroEnd() {
		SetPlayIntro(false);
		introText.SetActive(false);
	}


	private void SetPlayIntro(bool value) {
		playIntro = value;
		introText.SetActive(true);
		player.GetComponent<PlayerMotion>().PauseMotion(playIntro);
		level.GetComponent<RotationControl>().PauseMotion(playIntro);
	}
}
