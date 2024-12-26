using InteractableGroupsAi;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using UnityEngine;

public class MoveToAction : AgentAction
{
    private CharacterState _characterState;
    private CharacterController _characterController;
    private Vector3 _targetPosition;

    public MoveToAction(CharacterState state, Vector3 position, CharacterController characterController, CompositeCondition condition) : base(condition)
    {
        _characterState = state;
        _targetPosition = position;
    }

    public override void ForceEnd()
    {

    }

    public override float GetGoalChange(Goal goal)
    {
        return 1f;
    }

    public override void OnBegin()
    {
        _characterController.MoveTo(_targetPosition);
    }

    public override void OnEnd()
    {
        _characterController.StopMove();
    }

    public override void TryExecute()
    {

    }

    public override void Update()
    {
        if (_characterState.CurrentPosition == _targetPosition)
        {
            OnCompleted?.Invoke();
        }
    }
}