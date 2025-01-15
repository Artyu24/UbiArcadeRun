using DG.Tweening;
using UnityEngine;

public class BackGroundRythme : RythmeObject
{
    public void SubTick()
    {
        
    }

    public override void Tick()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScaleY(10, _currentSong.BPM[_mainBeatIndex]/2));
        mySequence.Append(transform.DOScaleY(5, _currentSong.BPM[_mainBeatIndex] / 2));
    }

}
