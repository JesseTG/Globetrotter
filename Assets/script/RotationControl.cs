using UnityEngine;
using System.Collections;

public class RotationControl : MonoBehaviour
{
    private Vector3 _mouseDown;
    private Vector3 _worldClick;

    [Tooltip("The maximum speed at which the world should rotate")]
    public float Speed = 1;
    [Tooltip("What axes should the world rotate around when the mouse is dragged horizontally or vertically?")]
    public RotationMode
        RotationMode = RotationMode.XY;

    void OnMouseDown ()
    {
        _mouseDown = Input.mousePosition;
        _worldClick = Camera.main.ScreenToWorldPoint (Input.mousePosition);
    }

    void OnMouseUp ()
    {
        _mouseDown.Set (float.NaN, float.NaN, float.NaN);
        _worldClick = _mouseDown;
    }

    void Update ()
    {
        if (Input.GetMouseButton (0)) {
            float h = Input.GetAxis ("Mouse X");
            float v = Input.GetAxis ("Mouse Y");
            this.transform.RotateAround (
                Vector3.zero, 
                this.RotationMode.HorizontalAxis (Camera.main.transform), 
                h * -Speed * Time.deltaTime
            );


            this.transform.RotateAround (
                Vector3.zero, 
                this.RotationMode.VerticalAxis (Camera.main.transform),
                v * Speed * Time.deltaTime
            );

        }
    }
}
