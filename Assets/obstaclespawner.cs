using UnityEngine;

public class obstaclespawner : MonoBehaviour,ITickable
{

    [field:SerializeField] public int BeatBeforeSpawn {  get; private set; }
    [field: SerializeField] public GameObject obstacle {  get; private set; }
    private int _currentBeatsLast;
    private void Awake()
    {
        _currentBeatsLast= BeatBeforeSpawn;
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
    void Start()
    {
        Metronome.instance.ToTick.Add(this);
    }
     

}
