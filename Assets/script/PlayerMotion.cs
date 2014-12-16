using UnityEngine;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotion : MonoBehaviour
{
    public float Speed = 1;
    public float Acceleration = 20;
    public string WallTag = "Wall";
    public PlayerDirection InitialDirection = PlayerDirection.North;
    private PlayerDirection _direction;

    public PlayerDirection Direction {
        get {
            return _direction;
        }

        set {
            this._direction = value;
            if (value == PlayerDirection.North || value == PlayerDirection.South) {
                this.rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
            } else if (value == PlayerDirection.East || value == PlayerDirection.West) {
                this.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
        }
    }

    void Awake ()
    {
        this.Direction = this.InitialDirection;
    }
    
    void FixedUpdate ()
    {
        this.transform.up = this.transform.position.normalized;
        this.rigidbody.AddForce(this.transform.forward * this.Acceleration * this.rigidbody.mass);
        this.rigidbody.velocity = Vector3.ClampMagnitude(this.rigidbody.velocity, Speed);
        // TODO: Make this play nicely with gravity
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == WallTag) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void ChangeDirection(PlayerDirection old, PlayerDirection new_) {
        this.Direction = new_;
    }
   

    // For player travelling up walls: Slant the walls towards the player slightly (or at least the colliders)
    // Also, try putting the beginning of the capsule slope right at the surface

	void OnPauseGame() {
		Speed = 0;
	}
}


