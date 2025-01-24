using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private int m_score;
    
    [SerializeField]
    private int m_scoreMultiplier = 1;

    [SerializeField]
    private TextMeshProUGUI m_scoreUI;

    [SerializeField]
    private TextMeshProUGUI m_scoreComboUI;

    public static ScoreSystem Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public static void AddToScore(int score) => Instance?.AddScore(score);
    
    public void AddScore(int score)
    {
        m_score += score * m_scoreMultiplier;
        UpdateScore();
    }

    //Update score & combo
    private void UpdateScore()
    {
        m_scoreUI.text = "Score : " + m_score;
        UpdateComboUI();
    }
    
    //Update combo only
    private void UpdateComboUI() => m_scoreComboUI.text = "Combo x" + m_scoreMultiplier;

    public void SetMultiplier(int multiplierValue) => m_scoreMultiplier = multiplierValue;
    public void ResetMultiplier(int multiplierValue) => m_scoreMultiplier = 1;
    public void AddMultiplier(int multiplierValue, float multiplierTime) => StartCoroutine(MultiplierTimer(multiplierValue, multiplierTime));
    public void AddMultiplier(float multiplierTime) => StartCoroutine(MultiplierTimer(1, multiplierTime));

    private IEnumerator MultiplierTimer(int multiplierAddedValue, float multiplierTime)
    {
        //Debug.Log("Added " +  multiplierAddedValue + " multiplier for " + multiplierTime + " seconds !");
        m_scoreMultiplier += multiplierAddedValue;
        yield return new WaitForSeconds(multiplierTime);
        if (m_scoreMultiplier <= 1) yield break;
        m_scoreMultiplier -= multiplierAddedValue;
        UpdateComboUI();
    }
    
}
