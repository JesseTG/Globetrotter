using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class LevelExit : MonoBehaviour {
    public string NextLevel;
    public string PlayerTag = "Player";

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == PlayerTag) {
            Application.LoadLevel (NextLevel);
        }
    }
}
