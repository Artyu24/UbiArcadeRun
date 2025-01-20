using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float m_playerMaxHP = 100;
    [SerializeField]
    private float m_playerHP;

    private bool m_isDead;
    public bool IsDead {  get { return m_isDead; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_playerHP = m_playerMaxHP;
    }

    public void TakeDamage(float damage)
    {
        m_playerHP -= damage;
        if (m_playerHP > 0) return;
        m_isDead = true;
        Debug.Log("You Lose !");
    }

    public void Heal(float heal)
    {
        m_playerHP = Mathf.Clamp(m_playerHP + heal, 0, m_playerMaxHP);
    }
}
