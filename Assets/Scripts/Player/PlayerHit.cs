using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHit : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _dist = 1f;
    [SerializeField, Min(1)] private int _scoreHit = 5;
    [SerializeField] private float _cooldown = 2;
    [SerializeField] private float _asyncCheckinterval = .1f;
    [SerializeField] private int _asyncCheckNumber = 3;
    private float _timer;

    [Header("Player Life")]
    [SerializeField, Min(1)] private int _lifeGainPlayer = 1;

    private void Update()
    {
        if (_timer < _cooldown)
            _timer += Time.deltaTime;
    }
    
    public void LaunchHit(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if(_timer < _cooldown)
                return;
            _timer = 0;

            StartCoroutine(AsyncHit());
        }
    }
    IEnumerator AsyncHit()//laisse au joueur une marche d'erreur en tirant plusieur fois
    {
        for (int i = 0; i < _asyncCheckNumber; i++)
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
                    break;//quand un tire marche on break
                }
            }
            yield return new WaitForSeconds(_asyncCheckinterval);
        }
        
    }
}
