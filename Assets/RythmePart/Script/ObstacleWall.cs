using DG.Tweening;
using UnityEngine;

public class ObstacleWall : RythmeObject,IDestructible
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [field:SerializeField]public Transform TargetPosition {  get; set; }
    Vector3 _posoffset = Vector3.zero;
    //private Song _currentSong;

    void Start()
    {
        Metronome.instance.OnMusicStart.AddListener(SubToBeat);
        SubToBeat(Metronome.instance._currentSong);
        Metronome.instance.OnMusicStop.AddListener(UnSubToBeat);
    }
     
    public override void Tick()
    {
        transform.DOMoveX(transform.position.x + 5, 0.5f);
        transform.DOPunchScale(new Vector3(1.1f, 1.1f, 1.1f), 0.2f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public override void SubTick()
    {
        
    }
    //public void SubToBeat(Song song)
    //{
    //    _currentSong = song;
    //    _currentSong.Beat1.AddListener(Tick);
    //    _currentSong.Beat2.AddListener(SubTick);
    //}

}
