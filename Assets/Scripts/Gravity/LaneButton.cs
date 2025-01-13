using UnityEngine;

public class LaneButton : MonoBehaviour
{
    [Header("Target Lane & Rotation to have")]
    [SerializeField]
    private Transform m_targetLane;
    [SerializeField]
    private SOLaneData m_targetRotation;

    private GravitySwitch m_playerGravitySwitch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        m_playerGravitySwitch = GameObject.FindWithTag("Player").GetComponent<GravitySwitch>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        m_playerGravitySwitch.GoToLane(m_targetLane, m_targetRotation.GetRotation);
    }


}
