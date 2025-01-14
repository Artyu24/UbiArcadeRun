using DG.Tweening;
using UnityEngine;
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
            //Switch Lane
            _isLeftLane = !_isLeftLane;

            // transform.position = Vector3.MoveTowards(transform.position, _actualLine.GetLaneTransform(_isLeftLane).position, _movementSpeed);
            transform.DOMove(_actualLine.GetLaneTransform(_isLeftLane).position, _movementDuration).SetEase(Ease.OutSine);
        }
    }
}
