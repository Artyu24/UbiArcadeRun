using UnityEngine;

public class ObstacleHurtPlayer : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damagePlayer = 5;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("TRIGGER");

        if (other.CompareTag("Player")) 
        {
            PlayerHP.DamagePlayer(_damagePlayer);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.LogWarning("COLLISION");
        
        if (other.transform.CompareTag("Player")) 
        {
            PlayerHP.DamagePlayer(_damagePlayer);
        }
    }
}
