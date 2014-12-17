using UnityEngine;
using System.Collections;

public class JumpPanel : MonoBehaviour
{
    public float JumpForce = 10;
    public string PlayerTag = "Player";

    // Use this for initialization
    void Start ()
    {
    
    }
    
    // Update is called once per frame
    void Update ()
    {
    
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == PlayerTag) {
#if UNITY_EDITOR
            Debug.Log ("Boing!", this);
#endif
            other.rigidbody.AddRelativeForce (0, this.JumpForce, 0, ForceMode.Impulse);
        }
    }
}
