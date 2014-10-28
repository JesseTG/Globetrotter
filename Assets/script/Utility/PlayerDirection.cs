using UnityEngine;
using System.Collections;

public enum PlayerDirection
{
    North,
    South,
    East,
    West
}

public static class PlayerDirectionExtensions
{
    public static Vector3 DirectionVector (this PlayerDirection direction, Transform transform)
    {
        switch (direction) {
        case PlayerDirection.North:
            return transform.forward;
        case PlayerDirection.South:
            return transform.forward * -1;
        case PlayerDirection.East:
            return transform.right;
        case PlayerDirection.West:
            return transform.right * -1;
        default:
            return transform.forward;
        }
    }
}