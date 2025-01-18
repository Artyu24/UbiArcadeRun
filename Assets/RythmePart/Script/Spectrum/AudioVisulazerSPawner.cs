using NaughtyAttributes;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioVisulazerSPawner : MonoBehaviour
{
    [SerializeField] private bool _isMirroring;

    [SerializeField] private float _maxBias;
    
    public GameObject Visualiazer;
    [SerializeField]private int numberToDisplay;

    private List<GameObject> spawned = new List<GameObject>();
    private List<Vector3> pos = new List<Vector3>();
    [SerializeField] private Vector3 offset;
    private Vector3 currentOfset;
    [SerializeField]private Vector3 _scale=Vector3.one;
    [SerializeField] private Vector3 _Beatscale = new Vector3(1,5,5);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Button]
    public void SpawnVisualizer()
    {
        float biasToAttribute= _maxBias/numberToDisplay;
        float curBias = biasToAttribute;
        for (int i = 0; i < numberToDisplay; i++)
        {
            GameObject go = Instantiate(Visualiazer, transform.position + currentOfset,transform.rotation);
            GameObject go2 = Instantiate(Visualiazer, transform.position - currentOfset, transform.rotation);
            if (go.TryGetComponent(out AudioSync sync))
            {
                sync.bias = curBias;
                go.transform.localScale=_scale;
                go.GetComponent<ScaleOnSpectrum>().restScale=_scale;
                go.GetComponent<ScaleOnSpectrum>().beatScale = _Beatscale;
            }
            if (go2.TryGetComponent(out AudioSync sync2))
            {
                sync2.bias = curBias;
                go2.transform.localScale = _scale;
                go2.GetComponent<ScaleOnSpectrum>().restScale = _scale;
                go2.GetComponent<ScaleOnSpectrum>().beatScale = _Beatscale;
            }
            //Gizmos.DrawCube(transform.position + currentOfset, Visualiazer.transform.localScale);
            currentOfset = currentOfset + offset;
            curBias += biasToAttribute;
        }
        currentOfset = Vector3.zero;

    }
    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < numberToDisplay; i++)
        {
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            Gizmos.DrawMesh(Visualiazer.GetComponentInChildren<MeshFilter>().sharedMesh, 0, transform.position + currentOfset,transform.rotation, _scale);
            //Gizmos.DrawMesh(transform.position+ currentOfset, Visualiazer.transform.localScale);
            if(_isMirroring)
                Gizmos.DrawMesh(Visualiazer.GetComponentInChildren<MeshFilter>().sharedMesh, 0, transform.position - currentOfset, transform.rotation, _scale);
            currentOfset = currentOfset + offset;
        }
        currentOfset = Vector3.zero;
    }
}
