using UnityEngine;

[CreateAssetMenu(fileName = "SOLaneData", menuName = "Scriptable Objects/SOLaneData")]
public class SOLaneData : ScriptableObject
{
    [SerializeField]
    private Vector3 m_rotation;

    public Vector3 GetRotation { get { return m_rotation; } }
}
