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
        if (Input.GetMouseButton (0)) {
            float h = Input.GetAxis ("Mouse X");
            float v = Input.GetAxis ("Mouse Y");
            this._speed.x = h * -Speed * Time.deltaTime;
            this._speed.y = v * Speed * Time.deltaTime;
        } else {
            this._speed = Vector2.Lerp (this._speed, Vector2.zero, Time.deltaTime * RotationDecay);
        }

        // TODO: Store the speed, affect the speed in here
        // Apply the speed regardless, but affect the speed in the get mouse block
        // Lerp the speed to zero
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
}
