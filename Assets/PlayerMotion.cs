using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotion : MonoBehaviour {

    public float Speed = 1;

	void FixedUpdate () {
	    this.transform.up = this.transform.position.normalized;

        Vector3 r = Vector3.Cross(Vector3.zero, this.transform.position);
        this.rigidbody.position += this.transform.forward * Speed * Time.deltaTime;
	}
}
