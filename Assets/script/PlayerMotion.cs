using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotion : MonoBehaviour
{

    public float Speed = 1;
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

        Vector3 r = Vector3.Cross (Vector3.zero, this.transform.position);
//        this.rigidbody.position += this.Direction.DirectionVector (this.transform) * Speed * Time.deltaTime;
        this.rigidbody.velocity = this.Direction.DirectionVector (this.transform) * Speed;
    }

    // For player travelling up walls: Slant the walls towards the player slightly (or at least the colliders)
    // Also, try putting the beginning of the capsule slope right at the surface
}
