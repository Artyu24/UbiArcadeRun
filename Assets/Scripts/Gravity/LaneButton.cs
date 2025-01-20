using UnityEngine;

public class LaneButton : MonoBehaviour
{
    [Header("Button Spawn Location")]
    [SerializeField]
    private CardinalPoint m_buttonCardinalLine;

    private CardinalPoint m_targetCardinalPoint;
    [SerializeField]
    private bool m_isLeftLane;

    private PlayerMovement m_playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        m_playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        SetButtonCardinalPoint(m_buttonCardinalLine, m_isLeftLane);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        m_playerMovement.GoToLane(m_targetCardinalPoint, !m_isLeftLane);
    }

    //Use after spawning button to know current button location
    public void SetButtonCardinalPoint(CardinalPoint cardinalPoint, bool isLeft)
    {
        m_buttonCardinalLine = cardinalPoint;
        m_isLeftLane = isLeft;
        AssignTargetLine();
    }

    //assign target line depending on button location
    private void AssignTargetLine()
    {
        switch (m_buttonCardinalLine)
        {
            case CardinalPoint.NORTH:
                if (m_isLeftLane) m_targetCardinalPoint = CardinalPoint.EAST;
                else m_targetCardinalPoint = CardinalPoint.WEST;
                break;

            case CardinalPoint.SOUTH:
                if (m_isLeftLane) m_targetCardinalPoint = CardinalPoint.WEST;
                else m_targetCardinalPoint = CardinalPoint.EAST;
                break;

            case CardinalPoint.EAST:
                if (m_isLeftLane) m_targetCardinalPoint = CardinalPoint.SOUTH;
                else m_targetCardinalPoint = CardinalPoint.NORTH;
                break;

            case CardinalPoint.WEST:
                if (m_isLeftLane) m_targetCardinalPoint = CardinalPoint.NORTH;
                else m_targetCardinalPoint = CardinalPoint.SOUTH;
                break;
        }
    }


}
