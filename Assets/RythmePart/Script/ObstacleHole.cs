using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class ObstacleHole : RythmeObject,IDestructible
{
    [SerializeField] private GameObject _plank;
    [SerializeField] private GameObject _holeObject;
    private Vector3 _PlankScale;

    
    [Button]
    public void Destroy()
    {
        _plank.transform.DOScale(_PlankScale,0.5f).SetEase(Ease.OutBounce);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _PlankScale = _plank.transform.localScale;
        _plank.transform.localScale = Vector3.zero;
    }

    void Start()
    {
        Metronome.instance.OnMusicStart.AddListener(SubToBeat);
        SubToBeat(Metronome.instance._currentSong);
        Metronome.instance.OnMusicStop.AddListener(UnSubToBeat);
    }

    public override void Tick()
    {
        transform.DOMoveX(transform.position.x + 5, 0.5f);
        _holeObject.transform.DOPunchScale(new Vector3(1.1f, 0f, 1.1f), 0.2f);
    }
}
