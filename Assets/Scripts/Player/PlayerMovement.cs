using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Component Needed")] 
    [SerializeField] private LineManager _lineManager;

    [FormerlySerializedAs("_movementSpeed")]
    [Header("Player Data")] 
    [SerializeField, Range(0.1f, 2)] private float _movementDuration = 1;
    private LineData _actualLine;
    private bool _isLeftLane;

    [Header("Parameters Gravity Movement")]
    [SerializeField]
    private float m_timeChangingLane = .5f;
    [SerializeField]
    private float m_timeRotating = .5f;

    [SerializeField]
    private bool isChangingLane;

    public UnityEvent<LineData> OnLeaveLine;
    public UnityEvent<LineData> OnLandLine;
    private void Start()
    {
        if(!DebugHelper.IsNull(_lineManager, name, nameof(PlayerMovement)))
            return;

        _actualLine = _lineManager.GetLineData(CardinalPoint.SOUTH);
    }

    public void PlayerMove(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (isChangingLane) return;
            
            //Switch Lane
            _isLeftLane = !_isLeftLane;

            // transform.position = Vector3.MoveTowards(transform.position, _actualLine.GetLaneTransform(_isLeftLane).position, _movementSpeed);
            transform.DOMove(_actualLine.GetLaneTransform(_isLeftLane).position, _movementDuration).SetEase(Ease.OutSine);
        }
    }


    public void GoToLane(CardinalPoint targetLane, bool isLeftLane)
    {
        if (isChangingLane) return;
        isChangingLane = true;
        //event when player leave its lane
        LineData targetLine = _lineManager.GetLineData(targetLane);
        Transform targetLanePos = targetLine.GetLaneTransform(isLeftLane);
        _isLeftLane = isLeftLane;
        OnLeaveLine.Invoke(_actualLine);
        StartCoroutine(ChangingLane(targetLine, targetLanePos));
    }

    private IEnumerator ChangingLane(LineData targetLine, Transform targetLanePos)
    {
        this.transform.DOMove(targetLanePos.position, m_timeChangingLane);
        this.transform.DORotate(targetLine.rotation, m_timeRotating);

        while (Vector3.Distance(this.transform.position, targetLanePos.position) > .1f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
        }
        isChangingLane = false;

        //event when player land on new lane
        OnLandLine.Invoke(targetLine);
        _actualLine = targetLine;
    }
}
