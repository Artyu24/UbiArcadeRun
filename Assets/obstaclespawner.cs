using UnityEngine;

public class obstaclespawner : MonoBehaviour,ITickable
{

    [field:SerializeField] public int BeatBeforeSpawn {  get; private set; }
    [field: SerializeField] public GameObject obstacle {  get; private set; }
    private int _currentBeatsLast;
    private Song _currentSong;
    void Awake()
    {
        _currentBeatsLast = BeatBeforeSpawn;
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
        if (_currentBeatsLast <= 0) 
        {
            GameObject newobstacle= Instantiate(obstacle,transform.position,Quaternion.identity);
            _currentBeatsLast = BeatBeforeSpawn;
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
