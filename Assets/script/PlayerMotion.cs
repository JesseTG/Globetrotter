using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotion : MonoBehaviour
{
    public float Speed = 1;
    public string WallTag = "Wall";
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
        this.Direction = PlayerDirection.North;
    }

    void FixedUpdate ()
    {
        this.transform.up = this.transform.position.normalized;

        this.rigidbody.velocity = this.Direction.DirectionVector (this.transform) * Speed;
        // TODO: Make this play nicely with gravity
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == WallTag) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    // For player travelling up walls: Slant the walls towards the player slightly (or at least the colliders)
    // Also, try putting the beginning of the capsule slope right at the surface
}
