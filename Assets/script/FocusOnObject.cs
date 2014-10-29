using UnityEngine;
using System.Collections;

public class FocusOnObject : MonoBehaviour
{
    private Vector3 _rotation;
    [Tooltip("The game object this camera should follow")]
    public Transform
        Target;

    void Start ()
    {
    }
    
    void Update ()
    {
        this.transform.position = Vector3.Lerp (
            this.transform.position, 
            this.Target.position, 
            Time.deltaTime
        );

        this.transform.LookAt (Vector3.zero);
    }
}
