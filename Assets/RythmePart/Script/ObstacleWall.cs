using DG.Tweening;
using UnityEngine;
using NaughtyAttributes;
public class ObstacleWall : RythmeObject,IDestructible,Ipoolable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [field:SerializeField]public Transform TargetPosition {  get; set; }
    [SerializeField] private GameObject _rotOnDestroy;
    [SerializeField] private GameObject _toDesactivate;
    Vector3 _posoffset = Vector3.zero;
    private bool _isTicking;
    //private Song _currentSong;

    private void Awake()
    {
        //UnPool();
    }
    void Start()
    {
        Metronome.instance.OnMusicStart.AddListener(SubToBeat);
        SubToBeat(Metronome.instance._currentSong);
        Metronome.instance.OnMusicStop.AddListener(UnSubToBeat);

    }
    
    public override void Tick()
    {
        if (!_isTicking)
            return;
        transform.DOMoveX(transform.position.x + 5, 0.5f);
        transform.DOPunchScale(new Vector3(1.1f, 1.1f, 1.1f), 0.2f);

    }
    // Update is called once per frame
    void Update()
    {

    }
    [Button]
    public void Destroy()
    {
        _toDesactivate.GetComponent<MeshRenderer>().enabled = false;
        _rotOnDestroy.transform.DOLocalRotate(new Vector3(133.474f, 0, 0), 0.2f).SetEase(Ease.OutBounce);
        //Destroy(gameObject);
    }
    public void UnPool()
    {
        _isTicking=true;
        transform.localScale = Vector3.one;
    }
    public void Pool()
    {
        _toDesactivate.GetComponent<MeshRenderer>().enabled = true;
        _rotOnDestroy.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f).SetEase(Ease.OutBounce);
        _isTicking = false;
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
