using UnityEngine;
using System.Reflection;
using System.Collections;
using System;
using UnityEngine.Events;

public class RotationControl : MonoBehaviour
{
    private Vector2 _speed;
	private bool IsPaused = false;
    [Tooltip("The maximum speed at which the world should rotate")]
    public float
        Speed = 1;
    [Tooltip("What axes should the world rotate around when the mouse is dragged horizontally or vertically?")]
    public RotationMode
        RotationMode = RotationMode.XZ;
    public float RotationDecay = 1;

    [Tooltip("The GameObjects to be notified when the user changes the rotation mode. Each GameObject must have a" + 
             " method called \"OnRotationModeChanged(string, RotationMode, RotationMode)\".")]
 
    public RotationModeChangedEvent OnRotationModeChanged;

    void FixedUpdate ()
    {
        if (Input.GetButton ("Fire1")) {
            float h = Input.GetAxis ("Mouse X");
            float v = Input.GetAxis ("Mouse Y");
            this._speed.x = Mathf.Clamp (h * -Speed, -Speed, Speed);
            this._speed.y = Mathf.Clamp (v * Speed, -Speed, Speed);
        } else {
            this._speed = Vector2.Lerp (this._speed, Vector2.zero, Time.deltaTime * RotationDecay);
        }

        this.transform.RotateAround (
                Vector3.zero, 
                this.RotationMode.HorizontalAxis (Camera.main.transform), 
                this._speed.x
        );


        this.transform.RotateAround (
                Vector3.zero, 
                this.RotationMode.VerticalAxis (Camera.main.transform),
                this._speed.y
        );
    }

    void Update ()
    {
        if (Input.GetButtonDown ("Fire2")) {
            RotationMode old = this.RotationMode;
            this.RotationMode = this.RotationMode.Next ();
            this.OnRotationModeChanged.Invoke(old, this.RotationMode);
        }
    }

	void OnPauseGame() {
		IsPaused = true;
	}
}

[Serializable]
public class RotationModeChangedEvent : UnityEvent<RotationMode, RotationMode> {}
