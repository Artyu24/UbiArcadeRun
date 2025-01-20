using SMP_LIG;
using UnityEngine;

public class Test : MonoBehaviour
{
    public ScoreManagerArcade test;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            //test.gameObject.SetActive(true);
            ScoreManagerArcade.SaveScore(10);
        } 
    }
}
