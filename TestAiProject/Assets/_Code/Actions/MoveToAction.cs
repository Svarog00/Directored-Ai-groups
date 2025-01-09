using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using UnityEngine;

public class MoveToAction : AgentAction, IAgentStateable
{
    public CharacterState State => _characterState;

    private CharacterState _characterState;
    private CharacterController _characterController;
    private Vector3 _targetPosition;

    public MoveToAction(CharacterState state, Vector3 position, CharacterController characterController, ComppositeAgentCondition condition) : base(condition)
    {
        _characterState = state;
        _characterController = characterController;
        _targetPosition = position;
    }

    public override void ForceEnd()
    {

    }

    public float GetGoalChange(Goal goal)
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
        if (_characterState.CurrentPosition == new System.Numerics.Vector3(_targetPosition.x, _targetPosition.y, _targetPosition.z))
        {
            OnCompleted?.Invoke();
        }
    }

    public override IAgentState GetNewState()
    {
        var state = new CharacterState();
        state.SetPosition(_targetPosition);
        return state;
    }
}