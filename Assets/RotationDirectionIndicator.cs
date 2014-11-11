using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(Graphic))]
public class RotationDirectionIndicator : MonoBehaviour
{
    public RotationMode RotationMode;
    [Tooltip("The material used to render this graphics when its rotation mode is being used")]
    public Material
        Selected;
    [Tooltip("The material used to render this graphics when its rotation mode is NOT being used")]
    public Material
        NotSelected;
    private Image _image;

    void Awake ()
    {
        this._image = this.GetComponent<Image> ();
    }

    public void OnRotationModeChanged (RotationMode old, RotationMode current)
    {
        this._image.material = (current == this.RotationMode) ? this.Selected : this.NotSelected;
    }
}
