using UnityEngine;

public class LaneButton : MonoBehaviour
{
    [Header("Target Lane & Rotation to have")]
    [SerializeField]
    private CardinalPoint m_cardinalLine;

    [SerializeField]
    private bool m_isLeftLane;

    private PlayerMovement m_playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        m_playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        m_playerMovement.GoToLane(m_cardinalLine, m_isLeftLane);
    }


}
