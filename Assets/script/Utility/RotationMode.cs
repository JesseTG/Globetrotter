using System;
using UnityEngine;

/// <summary>
/// Represents what axes the game world should rotate on when the user drags the mouse horizontally or vertically.
/// </summary>
[Serializable]
public enum RotationMode
{
    XY,
    XZ,
    YZ,
}

static class RotationModeExtensions
{
    /// <summary>
    /// Given a Transform, returns the vector that the world should rotate around 
    /// </summary>
    /// <returns>The axis.</returns>
    /// <param name="mode">The RotationMode that's active</param>
    /// <param name="transform">The Transform whose up, forward, or right vector should be returned</param>
    public static Vector3 HorizontalAxis (this RotationMode mode, Transform transform)
    {
        switch (mode) {
        case RotationMode.XY:
            return transform.up;
        case RotationMode.XZ:
            return transform.up;
        case RotationMode.YZ:
            return transform.forward;
        default:
            return transform.right;
        }
    }

    public static Vector3 VerticalAxis (this RotationMode mode, Transform transform)
    {
        switch (mode) {
        case RotationMode.XY:
            return transform.right;
        case RotationMode.XZ:
            return transform.forward;
        case RotationMode.YZ:
            return transform.right;
        default:
            return transform.right;
        }
    }
}