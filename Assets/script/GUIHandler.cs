using UnityEngine;
using System.Collections;

public class GUIHandler : MonoBehaviour {
	private bool IsPaused = false;
	private GameObject PauseMenu;

	// Use this for initialization
	void Awake () {
		PauseMenu = GameObject.FindWithTag("PauseScreen");
		PauseMenu.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		// Pause when escape key is pressed
		if (Input.GetKeyDown(KeyCode.Escape) && !IsPaused) {
			IsPaused = true;
			Object[] objects = FindObjectsOfType (typeof(GameObject));
			foreach (GameObject go in objects) {
				go.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);

			}
			PauseMenu.SetActive(true);
		}
	}
}
