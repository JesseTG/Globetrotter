using UnityEngine;
using UnityEngine.Events;
using System;

public class ChangeDirectionPanel : MonoBehaviour
{

    [Tooltip("The direction the player should start walking in (regardless of which way he is already)")]
    public PlayerDirection
        Direction = PlayerDirection.North;
    public string PlayerTag = "Player";
    public ChangeDirectionEvent OnWalkedOnChangeDirectionPanel;

    void Start ()
    {
    
    }
    
    // Update is called once per frame
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == PlayerTag) {
            PlayerMotion motion = other.gameObject.GetComponent<PlayerMotion> ();

            if (motion.Direction != this.Direction) {
                this.OnWalkedOnChangeDirectionPanel.Invoke (motion.Direction, this.Direction);
            }
        }
    }

}

[Serializable]
public class ChangeDirectionEvent : UnityEvent<PlayerDirection, PlayerDirection>
{
}