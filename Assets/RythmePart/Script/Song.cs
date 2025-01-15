using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
[Serializable]
public class Song
{
    [field: SerializeField] public AudioClip Music { get; set; }
    [Tooltip("more than 3 won't work")]
    [field: SerializeField] public float[] BPM = {0, 0, 0};
    [field: SerializeField] public float Duration { get; set; }

    public List<Coroutine> _beatCoroutines = new List<Coroutine>();
    public UnityEvent Beat1;
    public UnityEvent Beat2;
    public UnityEvent Beat3;

    
    
    public IEnumerator Beat(float interval, UnityEvent beatEvent)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            beatEvent.Invoke();
        }
    }
}
