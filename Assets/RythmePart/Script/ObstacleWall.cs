using DG.Tweening;
using UnityEngine;

public class ObstacleWall : MonoBehaviour,ITickable,IDestructible
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [field:SerializeField]public Transform TargetPosition {  get; set; }
    Vector3 _posoffset = Vector3.zero;
    void Start()
    {
        Metronome.instance.ToTick.Add(this);
    }
     
    public void Tick()
    {
        transform.DOMoveX(transform.position.x + 5, 0.5f);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void SubTick()
    {
        transform.DOPunchScale(new Vector3(1.1f, 1.1f, 1.1f), 0.2f);
    }
}
