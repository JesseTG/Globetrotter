using UnityEngine;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotion : MonoBehaviour
{
	public float Acceleration = 20;
	public PlayerDirection InitialDirection = PlayerDirection.North;
	public string WallTag = "Wall";
	private bool isPaused = false;
	
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
		this.transform.Rotate(this.transform.up, 90);
		// I don't know why I need to rotate 90 degrees on startup; it apparently
		// has to do with the way I set the orientation each physics step
	}
	
	void FixedUpdate ()
	{
		this.transform.up = this.transform.position.normalized;
		if(isPaused)
			return;
		Vector3 accel = this.gameObject.transform.forward * this.Acceleration;
		
		this.rigidbody.AddRelativeForce(0, 0, this.Acceleration, ForceMode.Acceleration);
		
		#if UNITY_EDITOR
		
		Debug.DrawRay (
			this.transform.position, 
			this.transform.forward * Vector3.Dot (rigidbody.velocity, accel), 
			Color.red,
			0, 
			false
			);
		
		Debug.DrawRay(this.transform.position, this.rigidbody.velocity, Color.cyan, 0, false);
		Debug.DrawRay(this.transform.position, accel, Color.green, 0, false);
		#endif
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == WallTag) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
	
	public void ChangeDirection (PlayerDirection old, PlayerDirection new_)
	{
		this.Direction = new_;
	}
	
	
	// For player travelling up walls: Slant the walls towards the player slightly (or at least the colliders)
	// Also, try putting the beginning of the capsule slope right at the surface
	
	public void PauseMotion (bool pause) {
		isPaused = pause;
	}
}

