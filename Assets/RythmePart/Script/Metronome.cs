using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{ //en gros avec ce script j'assaie de trouver un moyen de lié les trucs en rythmes
    public static Metronome instance;
    [field:SerializeField] public AudioSource Source { get; private set; }
    
    [SerializeField] private float _tickInterval;
    [SerializeField] private bool _isTicking;
    [field: SerializeField] public List<ITickable> ToTick = new List<ITickable>();
    [SerializeField] private AudioClip _ticksound, _subtickSound;
    public void Awake()
    {
        if(instance == null)
            instance = this;
        else 
            Destroy(this);
              
    }
    void Start()
    {
        StartCoroutine(Tick());
        Source.Play();
    }
    void TickAllObjectInList()
    {
        
        foreach (var t in ToTick)
            t.Tick();
    }
    void SubTickAllObjectInList()
    {
        
        foreach (var t in ToTick)
            t.SubTick();
    }
    IEnumerator Tick()
    {
        while (true)
        {
            yield return new WaitForSeconds(_tickInterval/2);
            SubTickAllObjectInList();
            Source.PlayOneShot(_subtickSound);
            yield return new WaitForSeconds(_tickInterval / 2);
            SubTickAllObjectInList();
            Source.PlayOneShot(_ticksound);
            TickAllObjectInList();
        }
        
    }
}
