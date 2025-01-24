using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHit : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _dist = 1f;
    [SerializeField, Min(1)] private int _scoreHit = 5;
    
    [Header("Player Life")]
    [SerializeField, Min(1)] private int _lifeGainPlayer = 1;
    public void LaunchHit(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.DrawRay(transform.position + (Vector3.forward / 2), Vector3.forward * _dist, Color.cyan, 0.5f);
            RaycastHit hit;
            if (Physics.Raycast(transform.position + (Vector3.forward / 2), Vector3.forward, out hit, _dist))
            {
                IDestructible objectHit = hit.transform.GetComponent<IDestructible>();
                if (objectHit != null)
                {
                    objectHit.Destroy();
                    ScoreSystem.AddToScore(_scoreHit);
                    PlayerHP.HealPlayer(_lifeGainPlayer);
                }
            }
        }
    }
}
