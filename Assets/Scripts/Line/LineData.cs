using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public struct LineData
{
    [FormerlySerializedAs("cardinalPoint")] public CardinalPoint cardinalPoint;
    public Vector3 rotation;
    [Tooltip("The LEFT lane in the same direction of rotation as the line"), SerializeField]
    private Transform leftLane;
    [Tooltip("The RIGHT lane in the same direction of rotation as the line"), SerializeField]
    private Transform rightLane;

    public Transform GetLaneTransform(bool isLeft)
    {
        if (isLeft)
            return leftLane;

        return rightLane;
    }
}

public enum CardinalPoint
{
    NORTH,
    SOUTH,
    EAST,
    WEST
}
