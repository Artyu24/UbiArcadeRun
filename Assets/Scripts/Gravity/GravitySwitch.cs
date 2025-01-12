using DG.Tweening;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    [System.Serializable]
    private struct Lanes
    {
        [SerializeField]
        private Transform m_firstLane, m_secondLane;
    }

    [Header("Lane's position the player go to")]
    [SerializeField]
    private Lanes m_upLanes;

    [SerializeField]
    private Lanes m_downLanes;

    [SerializeField]
    private Lanes m_leftLanes;

    [SerializeField]
    private Lanes m_rightLanes;

    [Header("Parameters")]
    [SerializeField]
    private float m_timeChangingLane = .5f;
    [SerializeField]
    private float m_timeRotating = .5f;
    
    [SerializeField]
    private bool isChangingLane;

    //Temporary Movement
    private void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Time.deltaTime * 5);
        if(Input.GetKey(KeyCode.DownArrow))this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Time.deltaTime * 5);
    }

    public void GoToLane(Transform lane, Vector3 rotation)
    {
        if (isChangingLane) return;
        isChangingLane = true;
        StartCoroutine(ChangingLane(lane, rotation));
    }

    private IEnumerator ChangingLane(Transform lane, Vector3 rotation)
    {
        this.transform.DOMove(lane.position, m_timeChangingLane);
        this.transform.DORotate(rotation, m_timeRotating);

        while(Vector3.Distance(this.transform.position, lane.position) > .1f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
        }
        isChangingLane = false;
        
    }
}
