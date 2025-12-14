using UnityEngine;

public class ObstacleHurtPlayer : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damagePlayer = 5;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            PlayerHP.DamagePlayer(_damagePlayer);
        }
    }
}
