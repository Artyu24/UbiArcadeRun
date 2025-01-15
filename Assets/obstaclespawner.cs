using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class obstaclespawner : MonoBehaviour, ITickable
{

    [field: SerializeField] public int BeatBeforeSpawnMin { get; set; }
    [field: SerializeField] public int BeatBeforeSpawnMax { get; private set; }
    [field: SerializeField] public List<GameObject> obstacles { get;  set; }
    

    [field: SerializeField] public bool IsFocused { get; private set; }

    [SerializeField]private Transform pos1, pos2;
    private int _currentBeatsLast;
    private Song _currentSong;
    void Awake()
    {
        _currentBeatsLast = Random.Range(BeatBeforeSpawnMin, BeatBeforeSpawnMax+1);
    }
    void Start()
    {
        Metronome.instance.OnMusicStart.AddListener(SubToBeat);
        Metronome.instance.OnMusicStop.AddListener(UnSubToBeat);
        
        Metronome.instance.ToTick1.Add(this);
    }

    public void Tick()
    {
        _currentBeatsLast--;
        if (_currentBeatsLast <= 0&& IsFocused) 
        {
            int indexRand = Random.Range(0, 2);
            GameObject newobstacle = Instantiate(obstacles[Random.Range(0,obstacles.Count)], indexRand == 0 ? pos1.position : pos2.position, Quaternion.identity);
            _currentBeatsLast = Random.Range(BeatBeforeSpawnMin, BeatBeforeSpawnMax + 1);
        }
    }
    public void SubTick()
    {
        
    }


    public void SubToBeat(Song song)
    {
        _currentSong=song;
        _currentSong.Beat1.AddListener(Tick);
    }

    public void UnSubToBeat()
    {
        _currentSong.Beat1.RemoveListener(Tick);
    }
}
