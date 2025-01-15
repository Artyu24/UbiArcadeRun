using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;





public class Metronome : MonoBehaviour
{ //en gros avec ce script j'assaie de trouver un moyen de lié les trucs en rythmes
    public static Metronome instance;
    [field: SerializeField] public AudioSource Source { get; private set; }


    [field: SerializeField] public List<Song> Songs { get; private set; } = new List<Song>();
    public Song _currentSong;
    private int _songIndex=0;
    //[SerializeField] private float _tickInterval;
    [SerializeField] private bool _isTicking;
    [SerializeField] private bool _tickSound;
    [SerializeField] private List<List<ITickable>> Container;
    [field: SerializeField] public List<ITickable> ToTick1 = new List<ITickable>();
    [field: SerializeField] public List<ITickable> ToTick2 = new List<ITickable>();
    [SerializeField] private AudioClip _ticksound, _subtickSound;

    public UnityEvent<Song> OnMusicStart;
    public UnityEvent OnMusicStop;

    private List<Coroutine> _coroutines = new List<Coroutine>();
    public void Awake()
    {
        //Container.Add(ToTick1);

        if (instance == null)
            instance = this;
        else
            Destroy(this);

        _currentSong = Songs[0];
        //StartSound();
        
    }
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        StartSound();
        //_currentSong=Songs[0];
        //StartSound();

        ////_currentSong.StartSound();
        ///*foreach (var bpm in Songs[0].BPM)
        //{
        //    _coroutines.Add(StartCoroutine(Tick(bpm)));
        //    Source.Play();
        //}*/
        ////_coroutines.Add(StartCoroutine(Tick(Songs[0].BPM[0], ToTick1)));
        //Source.Play();
    }
    IEnumerator musicDuration()
    {
        yield return new WaitForSeconds(_currentSong.Duration);
        Stopsound();
        if(_songIndex<Songs.Count-1)
            _songIndex++;
        else
            _songIndex=0;
        _currentSong = Songs[_songIndex];
        StartSound();
    }
    void TickAllObjectInList(List<ITickable> totick)
    {

        foreach (var t in totick)
            t.Tick();
    }
    public void StartSound()
    {
        StartCoroutine(musicDuration());
        Source.resource = _currentSong.Music;
        Source.Play();
        OnMusicStart.Invoke(_currentSong);
        if (_currentSong.BPM.Length > 0) _currentSong._beatCoroutines.Add(StartCoroutine(_currentSong.Beat(_currentSong.BPM[0], _currentSong.Beat1)));
        if (_currentSong.BPM.Length > 1) _currentSong._beatCoroutines.Add(StartCoroutine(_currentSong.Beat(_currentSong.BPM[1], _currentSong.Beat2)));
        if (_currentSong.BPM.Length > 2) _currentSong._beatCoroutines.Add(StartCoroutine(_currentSong.Beat(_currentSong.BPM[2], _currentSong.Beat3)));
    }
    private void Stopsound()
    {
        foreach (var coroutine in _currentSong._beatCoroutines)
        {
            if (coroutine != null) StopCoroutine(coroutine);
        }
        Source.Stop();
    }
    //void SubTickAllObjectInList()
    //{

    //    foreach (var t in ToTick)
    //        t.SubTick();
    //}
    /*IEnumerator Tick(float _tickInterval, List<ITickable> toTick)
    {
        while (true)
        {
            //yield return new WaitForSeconds(_tickInterval / 2);
            //SubTickAllObjectInList();
            //if (_tickSound)
                //Source.PlayOneShot(_subtickSound);
            yield return new WaitForSeconds(_tickInterval);
            
            //TickAllObjectInList(toTick);
            //SubTickAllObjectInList();
            //if (_tickSound)
            //Source.PlayOneShot(_ticksound);
            //TickAllObjectInList();
        }

    }*/

}