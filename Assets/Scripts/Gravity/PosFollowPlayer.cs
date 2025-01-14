using UnityEngine;

public class PosFollowPlayer : MonoBehaviour
{
    private GameObject m_player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, m_player.transform.position.z);
    }
}
