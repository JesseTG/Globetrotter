using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PointGravity : MonoBehaviour {
	[Tooltip("The point in the world this object will gravitate towards")]
	public Vector3 Center;

	private float _gravity;

	void Start() {
		_gravity = Physics.gravity.magnitude;
	}

	void FixedUpdate() {
		this.rigidbody.AddForce((this.Center - this.transform.position).normalized * _gravity * this.rigidbody.mass);
	}
}
