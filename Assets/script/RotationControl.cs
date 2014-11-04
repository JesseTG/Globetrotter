using UnityEngine;
using System.Collections;

public class RotationControl : MonoBehaviour
{
    private Vector2 _speed;
    [Tooltip("The maximum speed at which the world should rotate")]
    public float
        Speed = 1;
    [Tooltip("What axes should the world rotate around when the mouse is dragged horizontally or vertically?")]
    public RotationMode
        RotationMode = RotationMode.XY;
    public float RotationDecay = 1;

    void FixedUpdate ()
    {
        if (Input.GetButton ("Fire1")) {
            float h = Input.GetAxis ("Mouse X");
            float v = Input.GetAxis ("Mouse Y");
            this._speed.x = h * -Speed;
            this._speed.y = v * Speed;
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
            this.RotationMode = this.RotationMode.Next ();
        }
    }
}
