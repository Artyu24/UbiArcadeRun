using System.Collections;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private int m_score;
    
    [SerializeField]
    private int m_scoreMultiplier = 1;

    public void SetMultiplier(int multiplierValue) => m_scoreMultiplier = multiplierValue;
    public void ResetMultiplier(int multiplierValue) => m_scoreMultiplier = 1;
    public void AddMultiplier(int multiplierValue, float multiplierTime) => StartCoroutine(MultiplierTimer(multiplierValue, multiplierTime));
    public void AddMultiplier(float multiplierTime) => StartCoroutine(MultiplierTimer(1, multiplierTime));

    private IEnumerator MultiplierTimer(int multiplierAddedValue, float multiplierTime)
    {
        //Debug.Log("Added " +  multiplierAddedValue + " multiplier for " + multiplierTime + " seconds !");
        m_scoreMultiplier += multiplierAddedValue;
        yield return new WaitForSeconds(multiplierTime);
        if(m_scoreMultiplier > 1) m_scoreMultiplier -= multiplierAddedValue;
    }
    
}
